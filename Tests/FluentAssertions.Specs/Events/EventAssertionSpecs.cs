#if NET47
using System.Reflection.Emit;
#endif

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using FluentAssertions.Events;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using FluentAssertions.Formatting;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Events;

[Collection("EventMonitoring")]
public class EventAssertionSpecs
{
    public class ShouldRaise
    {
        [Fact]
        public async Task When_asserting_an_event_that_doesnt_exist_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitoredSubject = subject.Monitor();

            // Act
            // ReSharper disable once AccessToDisposedClosure
            Action act = () => monitoredSubject.Should().Raise("NonExistingEvent");

            // Assert
            await Expect.That(act).Throws<InvalidOperationException>();
        }

        [Fact]
        public async Task When_asserting_that_an_event_was_not_raised_and_it_doesnt_exist_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();

            // Act
            Action act = () => monitor.Should().NotRaise("NonExistingEvent");

            // Assert
            await Expect.That(act).Throws<InvalidOperationException>();
        }

        [Fact]
        public async Task When_an_event_was_not_raised_it_should_throw_and_use_the_reason()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();

            // Act
            Action act = () => monitor.Should().Raise("PropertyChanged", "{0} should cause the event to get raised", "Foo()");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected object " + Formatter.ToString(subject) +
                " to raise event \"PropertyChanged\" because Foo() should cause the event to get raised, but it did not.").AsWildcard();
        }

        [Fact]
        public async Task When_the_expected_event_was_raised_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithoutSender();

            // Act
            Action act = () => monitor.Should().Raise("PropertyChanged");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_an_unexpected_event_was_raised_it_should_throw_and_use_the_reason()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithoutSender();

            // Act
            Action act = () =>
                monitor.Should().NotRaise("PropertyChanged", "{0} should cause the event to get raised", "Foo()");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected object " + Formatter.ToString(subject) +
                    " to not raise event \"PropertyChanged\" because Foo() should cause the event to get raised, but it did.").AsWildcard();
        }

        [Fact]
        public async Task When_an_unexpected_event_was_not_raised_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();

            // Act
            Action act = () => monitor.Should().NotRaise("PropertyChanged");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_event_sender_is_not_the_expected_object_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithoutSender();

            // Act
            Action act = () => monitor.Should().Raise("PropertyChanged").WithSender(subject);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_event_sender_is_the_expected_object_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSender();

            // Act
            Action act = () => monitor.Should().Raise("PropertyChanged").WithSender(subject);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_WithArgs_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseNonConventionalEvent("first argument", 2, "third argument");

            // Act
            Action act = () => monitor.Should()
                .Raise("NonConventionalEvent")
                .WithArgs<string>(predicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_the_event_parameters_dont_match_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithoutSender();

            // Act
            Action act = () => monitor
                .Should().Raise("PropertyChanged")
                .WithArgs<PropertyChangedEventArgs>(args => args.PropertyName == "SomeProperty");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_event_args_are_of_a_different_type_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName("SomeProperty");

            // Act
            Action act = () => monitor
                .Should().Raise("PropertyChanged")
                .WithArgs<CancelEventArgs>(args => args.Cancel);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_event_parameters_do_match_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName("SomeProperty");

            // Act
            Action act = () => monitor
                .Should().Raise("PropertyChanged")
                .WithArgs<PropertyChangedEventArgs>(args => args.PropertyName == "SomeProperty");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_running_in_parallel_it_should_not_throw()
        {
            // Arrange
            void Action(int _)
            {
                EventRaisingClass subject = new();
                using var monitor = subject.Monitor();
                subject.RaiseEventWithSender();
                monitor.Should().Raise("PropertyChanged");
            }

            // Act
            Action act = () => Enumerable.Range(0, 1000)
                .AsParallel()
                .ForAll(Action);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public void When_a_monitored_class_event_has_fired_it_should_be_possible_to_reset_the_event_monitor()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var eventMonitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName("SomeProperty");

            // Act
            eventMonitor.Clear();

            // Assert
            eventMonitor.Should().NotRaise("PropertyChanged");
        }

        [Fact]
        public async Task When_a_non_conventional_event_with_a_specific_argument_was_raised_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseNonConventionalEvent("first argument", 2, "third argument");

            // Act
            Action act = () => monitor
                .Should().Raise("NonConventionalEvent")
                .WithArgs<string>(args => args == "third argument");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_non_conventional_event_with_many_specific_arguments_was_raised_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseNonConventionalEvent("first argument", 2, "third argument");

            // Act
            Action act = () => monitor
                .Should().Raise("NonConventionalEvent")
                .WithArgs<string>(null, args => args == "third argument");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_predicate_based_parameter_assertion_expects_more_parameters_then_an_event_has_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseNonConventionalEvent("first argument", 2, "third argument");

            // Act
            Action act = () => monitor
                .Should().Raise(nameof(EventRaisingClass.NonConventionalEvent))
                .WithArgs<string>(null, null, null, args => args == "fourth argument");

            // Assert
            await Expect.That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_a_non_conventional_event_with_a_specific_argument_was_not_raised_it_should_throw()
        {
            // Arrange
            const int wrongArgument = 3;
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseNonConventionalEvent("first argument", 2, "third argument");

            // Act
            Action act = () => monitor
                .Should().Raise("NonConventionalEvent")
                .WithArgs<int>(args => args == wrongArgument);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected at least one event with some argument*type*Int32*matches*(args == " + wrongArgument +
                "), but found none.").AsWildcard();
        }

        [Fact]
        public async Task When_a_non_conventional_event_with_many_specific_arguments_was_not_raised_it_should_throw()
        {
            // Arrange
            const string wrongArgument = "not a third argument";
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseNonConventionalEvent("first argument", 2, "third argument");

            // Act
            Action act = () => monitor
                .Should().Raise("NonConventionalEvent")
                .WithArgs<string>(null, args => args == wrongArgument);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected at least one event with some arguments*match*\"(args == \"" + wrongArgument +
                "\")\", but found none.").AsWildcard();
        }

        [Fact]
        public async Task When_a_specific_event_is_expected_it_should_return_only_relevant_events()
        {
            // Arrange
            var observable = new EventRaisingClass();
            using var monitor = observable.Monitor();

            // Act
            observable.RaiseEventWithSpecificSender("Foo");
            observable.RaiseEventWithSpecificSender("Bar");
            observable.RaiseNonConventionalEvent("don't care", 123, "don't care");

            // Assert
            var recording = monitor
                .Should()
                .Raise(nameof(observable.PropertyChanged));

            await Expect.That(recording.EventName).IsEqualTo(nameof(observable.PropertyChanged));
            await Expect.That(recording.EventObject).IsSameAs(observable);
            await Expect.That(recording.EventHandlerType).IsEqualTo(typeof(PropertyChangedEventHandler));
            await Expect.That(recording).HasCount(2).Because("because only two property changed events were raised");
        }

        [Fact]
        public void When_a_specific_sender_is_expected_it_should_return_only_relevant_events()
        {
            // Arrange
            var observable = new EventRaisingClass();
            using var monitor = observable.Monitor();

            // Act
            observable.RaiseEventWithSpecificSender(observable);
            observable.RaiseEventWithSpecificSender(new object());

            // Assert
            var recording = monitor
                .Should()
                .Raise(nameof(observable.PropertyChanged))
                .WithSender(observable);

            recording.Should().ContainSingle().Which.Parameters[0].Should().BeSameAs(observable);
        }

        [Fact]
        public void When_constraints_are_specified_it_should_filter_the_events_based_on_those_constraints()
        {
            // Arrange
            var observable = new EventRaisingClass();
            using var monitor = observable.Monitor();

            // Act
            observable.RaiseEventWithSenderAndPropertyName("Foo");
            observable.RaiseEventWithSenderAndPropertyName("Boo");

            // Assert
            var recording = monitor
                .Should()
                .Raise(nameof(observable.PropertyChanged))
                .WithSender(observable)
                .WithArgs<PropertyChangedEventArgs>(args => args.PropertyName == "Boo");

            recording
                .Should().ContainSingle("because we were expecting a specific property change")
                .Which.Parameters[^1].Should().BeOfType<PropertyChangedEventArgs>()
                .Which.PropertyName.Should().Be("Boo");
        }

        [Fact]
        public async Task When_events_are_raised_regardless_of_time_tick_it_should_return_by_invocation_order()
        {
            // Arrange
            var observable = new TestEventRaisingInOrder();

            using var monitor = observable.Monitor(conf =>
                conf.ConfigureTimestampProvider(() => 11.January(2022).At(12, 00).AsUtc()));

            // Act
            observable.RaiseAllEvents();

            // Assert
            await Expect.That(monitor.OccurredEvents[0].EventName).IsEqualTo(nameof(TestEventRaisingInOrder.InterfaceEvent));
            await Expect.That(monitor.OccurredEvents[0].Sequence).IsEqualTo(0);

            await Expect.That(monitor.OccurredEvents[1].EventName).IsEqualTo(nameof(TestEventRaisingInOrder.Interface2Event));
            await Expect.That(monitor.OccurredEvents[1].Sequence).IsEqualTo(1);

            await Expect.That(monitor.OccurredEvents[2].EventName).IsEqualTo(nameof(TestEventRaisingInOrder.Interface3Event));
            await Expect.That(monitor.OccurredEvents[2].Sequence).IsEqualTo(2);
        }

        [Fact]
        public void When_monitoring_a_class_it_should_be_possible_to_attach_to_additional_interfaces_on_the_same_object()
        {
            // Arrange
            var subject = new TestEventRaising();
            using var outerMonitor = subject.Monitor<IEventRaisingInterface>();
            using var innerMonitor = subject.Monitor<IEventRaisingInterface2>();

            // Act
            subject.RaiseBothEvents();

            // Assert
            outerMonitor.Should().Raise("InterfaceEvent");
            innerMonitor.Should().Raise("Interface2Event");
        }
    }

    public class ShouldRaisePropertyChanged
    {
        [Fact]
        public async Task When_a_property_changed_event_was_raised_for_the_expected_property_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName("SomeProperty");
            subject.RaiseEventWithSenderAndPropertyName("SomeOtherProperty");

            // Act
            Action act = () => monitor.Should().RaisePropertyChangeFor(x => x.SomeProperty);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_an_expected_property_changed_event_was_raised_for_all_properties_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName(null);

            // Act
            Action act = () => monitor.Should().RaisePropertyChangeFor(null);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_property_changed_event_for_a_specific_property_was_not_raised_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();

            // Act
            Action act = () => monitor.Should().RaisePropertyChangeFor(x => x.SomeProperty, "the property was changed");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected object " + Formatter.ToString(subject) +
                " to raise event \"PropertyChanged\" for property \"SomeProperty\" because the property was changed, but it did not*").AsWildcard();
        }

        [Fact]
        public async Task When_a_property_agnostic_property_changed_event_for_was_not_raised_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                monitor.Should().RaisePropertyChangeFor(null);
            };

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected object " + Formatter.ToString(subject) +
                " to raise event \"PropertyChanged\" for property <null>, but it did not*").AsWildcard();
        }

        [Fact]
        public async Task When_the_property_changed_event_was_raised_for_the_wrong_property_it_should_throw_and_include_the_actual_properties_raised()
        {
            // Arrange
            var bar = new EventRaisingClass();
            using var monitor = bar.Monitor();
            bar.RaiseEventWithSenderAndPropertyName("OtherProperty1");
            bar.RaiseEventWithSenderAndPropertyName("OtherProperty2");
            bar.RaiseEventWithSenderAndPropertyName("OtherProperty2");

            // Act
            Action act = () => monitor.Should().RaisePropertyChangeFor(b => b.SomeProperty);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void
            The_number_of_property_changed_recorded_for_a_specific_property_matches_the_number_of_times_it_was_raised_specifically()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeProperty));
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeProperty));
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeOtherProperty));

            // Act
            monitor.Should().RaisePropertyChangeFor(x => x.SomeProperty).Should().HaveCount(2);
        }

        [Fact]
        public void
            The_number_of_property_changed_recorded_for_a_specific_property_matches_the_number_of_times_it_was_raised_including_agnostic_property()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeProperty));
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeOtherProperty));
            subject.RaiseEventWithSenderAndPropertyName(null);
            subject.RaiseEventWithSenderAndPropertyName(string.Empty);

            // Act
            monitor.Should().RaisePropertyChangeFor(x => x.SomeProperty).Should().HaveCount(3);
        }

        [Fact]
        public void
            The_number_of_property_changed_recorded_matches_the_number_of_times_it_was_raised()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeProperty));
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeOtherProperty));
            subject.RaiseEventWithSenderAndPropertyName(null);
            subject.RaiseEventWithSenderAndPropertyName(string.Empty);

            // Act
            monitor.Should().RaisePropertyChangeFor(null).Should().HaveCount(4);
        }
    }

    public class ShouldNotRaisePropertyChanged
    {
        [Fact]
        public void When_a_property_changed_event_was_raised_by_monitored_class_it_should_be_possible_to_reset_the_event_monitor()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var eventMonitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName("SomeProperty");

            // Act
            eventMonitor.Clear();

            // Assert
            eventMonitor.Should().NotRaisePropertyChangeFor(e => e.SomeProperty);
        }

        [Fact]
        public async Task When_a_property_changed_event_for_an_unexpected_property_was_raised_it_should_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName("SomeProperty");

            // Act
            Action act = () => monitor.Should().NotRaisePropertyChangeFor(x => x.SomeProperty, "nothing happened");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Did not expect object " + Formatter.ToString(subject) +
                " to raise the \"PropertyChanged\" event for property \"SomeProperty\" because nothing happened, but it did.").AsWildcard();
        }

        [Fact]
        public async Task When_a_property_changed_event_for_another_than_the_unexpected_property_was_raised_it_should_not_throw()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName("SomeOtherProperty");

            // Act
            Action act = () => monitor.Should().NotRaisePropertyChangeFor(x => x.SomeProperty);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Throw_for_an_agnostic_property_when_any_property_changed_is_recorded()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName(nameof(EventRaisingClass.SomeOtherProperty));

            // Act
            Action act = () => monitor.Should().NotRaisePropertyChangeFor(null);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Did not expect object " + Formatter.ToString(subject) +
                " to raise the \"PropertyChanged\" event, but it did.").AsWildcard();
        }

        [Fact]
        public async Task Throw_for_a_specific_property_when_an_agnostic_property_changed_is_recorded()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();
            subject.RaiseEventWithSenderAndPropertyName(null);

            // Act
            Action act = () => monitor.Should().NotRaisePropertyChangeFor(x => x.SomeProperty);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Did not expect object " + Formatter.ToString(subject) +
                " to raise the \"PropertyChanged\" event for property \"SomeProperty\", but it did.").AsWildcard();
        }
    }

    public class PreconditionChecks
    {
        [Fact]
        public async Task When_monitoring_a_null_object_it_should_throw()
        {
            // Arrange
            EventRaisingClass subject = null;

            // Act
            Action act = () => subject.Monitor();

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_nesting_monitoring_requests_scopes_should_be_isolated()
        {
            // Arrange
            var eventSource = new EventRaisingClass();
            using var outerScope = eventSource.Monitor();

            // Act
            using var innerScope = eventSource.Monitor();

            // Assert
            await Expect.That((object)innerScope).IsNotSameAs(outerScope);
        }

        [Fact]
        public async Task When_monitoring_an_object_with_invalid_property_expression_it_should_throw()
        {
            // Arrange
            var eventSource = new EventRaisingClass();
            using var monitor = eventSource.Monitor();
            Func<EventRaisingClass, int> func = e => e.SomeOtherProperty;

            // Act
            Action act = () => monitor.Should().RaisePropertyChangeFor(e => func(e));

            // Assert
            await Expect.That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task Event_assertions_should_expose_the_monitor()
        {
            // Arrange
            var subject = new EventRaisingClass();
            using var monitor = subject.Monitor();

            // Act
            var exposedMonitor = monitor.Should().Monitor;

            // Assert
            await Expect.That((object)exposedMonitor).IsSameAs(monitor);
        }
    }

    /* TODO VAB
    public class Metadata
    {
        [Fact]
        public async Task When_monitoring_an_object_it_should_monitor_all_the_events_it_exposes()
        {
            // Arrange
            var eventSource = new ClassThatRaisesEventsItself();
            using var eventMonitor = eventSource.Monitor();

            // Act
            EventMetadata[] metadata = eventMonitor.MonitoredEvents;

            // Assert
            await Expect.That(metadata).IsEqualTo([
                new
                {
                    EventName = nameof(ClassThatRaisesEventsItself.InterfaceEvent),
                    HandlerType = typeof(EventHandler)
                },
                new
                {
                    EventName = nameof(ClassThatRaisesEventsItself.PropertyChanged),
                    HandlerType = typeof(PropertyChangedEventHandler)
                }
            ]);
        }

        [Fact]
        public async Task When_monitoring_an_object_through_an_interface_it_should_monitor_only_the_events_it_exposes()
        {
            // Arrange
            var eventSource = new ClassThatRaisesEventsItself();
            using var monitor = eventSource.Monitor<IEventRaisingInterface>();

            // Act
            EventMetadata[] metadata = monitor.MonitoredEvents;

            // Assert
            await Expect.That(metadata).IsEqualTo([
                new
                {
                    EventName = nameof(IEventRaisingInterface.InterfaceEvent),
                    HandlerType = typeof(EventHandler)
                }
            ]);
        }

#if NETFRAMEWORK // DefineDynamicAssembly is obsolete in .NET Core
        [Fact]
        public void When_an_object_doesnt_expose_any_events_it_should_throw()
        {
            // Arrange
            object eventSource = CreateProxyObject();

            // Act
            Action act = () => eventSource.Monitor();

            // Assert
            act.Should().Throw<InvalidOperationException>().WithMessage("*not expose any events*");
        }

        [Fact]
        public void When_monitoring_interface_of_a_class_and_no_recorder_exists_for_an_event_it_should_throw()
        {
            // Arrange
            var eventSource = (IEventRaisingInterface)CreateProxyObject();
            using var eventMonitor = eventSource.Monitor();

            // Act
            Action action = () => eventMonitor.GetRecordingFor("SomeEvent");

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage("Not monitoring any events named \"SomeEvent\".");
        }

        private object CreateProxyObject()
        {
            Type baseType = typeof(EventRaisingClass);
            Type interfaceType = typeof(IEventRaisingInterface);

            AssemblyName assemblyName = new() { Name = baseType.Assembly.FullName + ".GeneratedForTest" };

            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName,
                AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, false);
            string typeName = baseType.Name + "_GeneratedForTest";

            TypeBuilder typeBuilder =
                moduleBuilder.DefineType(typeName, TypeAttributes.Public, baseType, [interfaceType]);

            MethodBuilder addHandler = EmitAddRemoveEventHandler("add");
            typeBuilder.DefineMethodOverride(addHandler, interfaceType.GetMethod("add_InterfaceEvent"));
            MethodBuilder removeHandler = EmitAddRemoveEventHandler("remove");
            typeBuilder.DefineMethodOverride(removeHandler, interfaceType.GetMethod("remove_InterfaceEvent"));

            Type generatedType = typeBuilder.CreateType();
            return Activator.CreateInstance(generatedType);

            MethodBuilder EmitAddRemoveEventHandler(string methodName)
            {
                MethodBuilder method =
                    typeBuilder.DefineMethod($"{interfaceType.FullName}.{methodName}_InterfaceEvent",
                        MethodAttributes.Private | MethodAttributes.Virtual | MethodAttributes.Final |
                        MethodAttributes.HideBySig |
                        MethodAttributes.NewSlot);

                method.SetReturnType(typeof(void));
                method.SetParameters(typeof(EventHandler));
                ILGenerator gen = method.GetILGenerator();
                gen.Emit(OpCodes.Ret);
                return method;
            }
        }

#endif

        [Fact]
        public async Task When_event_exists_on_class_but_not_on_monitored_interface_it_should_not_allow_monitoring_it()
        {
            // Arrange
            var eventSource = new ClassThatRaisesEventsItself();
            using var eventMonitor = eventSource.Monitor<IEventRaisingInterface>();

            // Act
            Action action = () => eventMonitor.GetRecordingFor("PropertyChanged");

            // Assert
            await Expect.That(action).Throws<InvalidOperationException>();
        }

        [Fact]
        public async Task When_an_object_raises_two_events_it_should_provide_the_data_about_those_occurrences()
        {
            // Arrange
            DateTime utcNow = 17.September(2017).At(21, 00).AsUtc();

            var eventSource = new EventRaisingClass();
            using var monitor = eventSource.Monitor(opt => opt.ConfigureTimestampProvider(() => utcNow));

            // Act
            eventSource.RaiseEventWithSenderAndPropertyName("theProperty");

            utcNow += 1.Hours();

            eventSource.RaiseNonConventionalEvent("first", 123, "third");

            // Assert
            await Expect.That(monitor.OccurredEvents).IsEqualTo([
                new
                {
                    EventName = "PropertyChanged",
                    TimestampUtc = utcNow - 1.Hours(),
                    Parameters = new object[] { eventSource, new PropertyChangedEventArgs("theProperty") }
                },
                new
                {
                    EventName = "NonConventionalEvent",
                    TimestampUtc = utcNow,
                    Parameters = new object[] { "first", 123, "third" }
                }
            ]);
        }

        [Fact]
        public async Task When_monitoring_interface_with_inherited_event_it_should_not_throw()
        {
            // Arrange
            var eventSource = (IInheritsEventRaisingInterface)new ClassThatRaisesEventsItself();

            // Act
            Action action = () => eventSource.Monitor();

            // Assert
            await Expect.That(action).DoesNotThrow();
        }
    }
    */

    public class WithArgs
    {
        [Fact]
        public async Task One_matching_argument_type_before_mismatching_types_passes()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new B());
            a.OnEvent(new C());

            // Act / Assert
            IEventRecording filteredEvents = aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>();
            await Expect.That(filteredEvents).HasCount(1);
        }

        [Fact]
        public async Task One_matching_argument_type_after_mismatching_types_passes()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new C());
            a.OnEvent(new B());

            // Act / Assert
            IEventRecording filteredEvents = aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>();
            await Expect.That(filteredEvents).HasCount(1);
        }

        [Fact]
        public async Task Throws_when_none_of_the_arguments_are_of_the_expected_type()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new C());
            a.OnEvent(new C());

            // Act
            Action act = () => aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task One_matching_argument_type_anywhere_between_mismatching_types_passes()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new C());
            a.OnEvent(new B());
            a.OnEvent(new C());

            // Act / Assert
            IEventRecording filteredEvents = aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>();
            await Expect.That(filteredEvents).HasCount(1);
        }

        [Fact]
        public async Task One_matching_argument_type_anywhere_between_mismatching_types_with_parameters_passes()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new C());
            a.OnEvent(new B());
            a.OnEvent(new C());

            // Act / Assert
            IEventRecording filteredEvents = aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>(_ => true);
            await Expect.That(filteredEvents).HasCount(1);
        }

        [Fact]
        public async Task Mismatching_argument_types_with_one_parameter_matching_a_different_type_fails()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new C());
            a.OnEvent(new C());

            // Act
            Action act = () => aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>(_ => true);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Mismatching_argument_types_with_two_or_more_parameters_matching_a_different_type_fails()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new C());
            a.OnEvent(new C());

            // Act
            Action act = () => aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>(_ => true, _ => false);

            // Assert
            await Expect.That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task One_matching_argument_type_with_two_or_more_parameters_matching_a_mismatching_type_fails()
        {
            // Arrange
            A a = new();
            using var aMonitor = a.Monitor();

            a.OnEvent(new C());
            a.OnEvent(new B());

            // Act
            Action act = () => aMonitor.GetRecordingFor(nameof(A.Event)).WithArgs<B>(_ => true, _ => false);

            // Assert
            await Expect.That(act).Throws<ArgumentException>();
        }
    }

    public class MonitorDefaultBehavior
    {
        [Fact]
        public void Broken_event_add_accessors_fails()
        {
            // Arrange
            var sut = new TestEventBrokenEventHandlerRaising();

            // Act / Assert
            sut.Invoking(c =>
            {
                using var monitor = c.Monitor<IAddFailingEvent>();
            }).Should().Throw<TargetInvocationException>();
        }

        [Fact]
        public void Broken_event_remove_accessors_fails()
        {
            // Arrange
            var sut = new TestEventBrokenEventHandlerRaising();

            // Act / Assert
            sut.Invoking(c =>
            {
                using var monitor = c.Monitor<IRemoveFailingEvent>();
            }).Should().Throw<TargetInvocationException>();
        }
    }

    public class IgnoreMisbehavingEventAccessors
    {
        [Fact]
        public void Monitoring_class_with_broken_event_add_accessor_succeeds()
        {
            // Arrange
            var classToMonitor = new TestEventBrokenEventHandlerRaising();

            // Act / Assert
            classToMonitor.Invoking(c =>
            {
                using var monitor = c.Monitor<IAddFailingEvent>(opt => opt.IgnoringEventAccessorExceptions());
            }).Should().NotThrow();
        }

        [Fact]
        public void Class_with_broken_event_remove_accessor_succeeds()
        {
            // Arrange
            var classToMonitor = new TestEventBrokenEventHandlerRaising();

            // Act / Assert
            classToMonitor.Invoking(c =>
            {
                using var monitor = c.Monitor<IRemoveFailingEvent>(opt => opt.IgnoringEventAccessorExceptions());
            }).Should().NotThrow();
        }

        [Fact]
        public async Task Recording_event_with_broken_add_accessor_succeeds()
        {
            // Arrange
            var classToMonitor = new TestEventBrokenEventHandlerRaising();

            using var monitor =
                classToMonitor.Monitor<IAddFailingEvent>(opt =>
                    opt.IgnoringEventAccessorExceptions().RecordingEventsWithBrokenAccessor());

            //Act
            classToMonitor.RaiseOkEvent();

            //Assert
            await Expect.That(monitor.MonitoredEvents).HasCount(1);
        }

        [Fact]
        public async Task Ignoring_broken_event_accessor_should_also_not_record_events()
        {
            // Arrange
            var classToMonitor = new TestEventBrokenEventHandlerRaising();

            using var monitor = classToMonitor.Monitor<IAddFailingEvent>(opt => opt.IgnoringEventAccessorExceptions());

            //Act
            classToMonitor.RaiseOkEvent();

            //Assert
            await Expect.That(monitor.MonitoredEvents).IsEmpty();
        }
    }

    private interface IAddOkEvent
    {
        event EventHandler OkEvent;
    }

    private interface IAddFailingRecordableEvent
    {
#pragma warning disable IDE0040 // Add accessibility modifiers
        public event EventHandler AddFailingRecorableEvent;
#pragma warning restore IDE0040 // Add accessibility modifiers
    }

    private interface IAddFailingEvent
    {
#pragma warning disable IDE0040 // Add accessibility modifiers
        public event EventHandler AddFailingEvent;
#pragma warning restore IDE0040 // Add accessibility modifiers
    }

    private interface IRemoveFailingEvent
    {
#pragma warning disable IDE0040 // Add accessibility modifiers
        public event EventHandler RemoveFailingEvent;
#pragma warning restore IDE0040 // Add accessibility modifiers
    }

    private class TestEventBrokenEventHandlerRaising
        : IAddFailingEvent, IRemoveFailingEvent, IAddOkEvent, IAddFailingRecordableEvent
    {
        public event EventHandler AddFailingEvent
        {
            add => throw new InvalidOperationException("Add is failing");
            remove => OkEvent -= value;
        }

        public event EventHandler AddFailingRecorableEvent
        {
            add
            {
                OkEvent += value;
                throw new InvalidOperationException("Add is failing");
            }

            remove => OkEvent -= value;
        }

        public event EventHandler OkEvent;

        public event EventHandler RemoveFailingEvent
        {
            add => OkEvent += value;
            remove => throw new InvalidOperationException("Remove is failing");
        }

        public void RaiseOkEvent()
        {
            OkEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public class A
    {
#pragma warning disable MA0046
        public event EventHandler<object> Event;
#pragma warning restore MA0046

        public void OnEvent(object o)
        {
            Event.Invoke(nameof(A), o);
        }
    }

    public class B;

    public class C;

    public class ClassThatRaisesEventsItself : IInheritsEventRaisingInterface
    {
#pragma warning disable RCS1159
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore RCS1159

        public event EventHandler InterfaceEvent;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected virtual void OnInterfaceEvent()
        {
            InterfaceEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public class TestEventRaising : IEventRaisingInterface, IEventRaisingInterface2
    {
        public event EventHandler InterfaceEvent;

        public event EventHandler Interface2Event;

        public void RaiseBothEvents()
        {
            InterfaceEvent?.Invoke(this, EventArgs.Empty);
            Interface2Event?.Invoke(this, EventArgs.Empty);
        }
    }

    private class TestEventRaisingInOrder : IEventRaisingInterface, IEventRaisingInterface2, IEventRaisingInterface3
    {
        public event EventHandler Interface3Event;

        public event EventHandler Interface2Event;

        public event EventHandler InterfaceEvent;

        public void RaiseAllEvents()
        {
            InterfaceEvent?.Invoke(this, EventArgs.Empty);
            Interface2Event?.Invoke(this, EventArgs.Empty);
            Interface3Event?.Invoke(this, EventArgs.Empty);
        }
    }

    public interface IEventRaisingInterface
    {
        event EventHandler InterfaceEvent;
    }

    public interface IEventRaisingInterface2
    {
        event EventHandler Interface2Event;
    }

    public interface IEventRaisingInterface3
    {
        event EventHandler Interface3Event;
    }

    public interface IInheritsEventRaisingInterface : IEventRaisingInterface;

    public class EventRaisingClass : INotifyPropertyChanged
    {
        public string SomeProperty { get; set; }

        public int SomeOtherProperty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (_, _) => { };

#pragma warning disable MA0046
        public event Action<string, int, string> NonConventionalEvent = (_, _, _) => { };
#pragma warning restore MA0046

        public void RaiseNonConventionalEvent(string first, int second, string third)
        {
            NonConventionalEvent.Invoke(first, second, third);
        }

        public void RaiseEventWithoutSender()
        {
#pragma warning disable AV1235, MA0091 // 'sender' is deliberately null
            PropertyChanged(null, new PropertyChangedEventArgs(""));
#pragma warning restore AV1235, MA0091
        }

        public void RaiseEventWithSender()
        {
            PropertyChanged(this, new PropertyChangedEventArgs(""));
        }

        public void RaiseEventWithSpecificSender(object sender)
        {
#pragma warning disable MA0091
            PropertyChanged(sender, new PropertyChangedEventArgs(""));
#pragma warning restore MA0091
        }

        public void RaiseEventWithSenderAndPropertyName(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

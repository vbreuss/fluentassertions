using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions.Equivalency;
using FluentAssertions.Equivalency.Steps;
using FluentAssertions.Execution;
using JetBrains.Annotations;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Configuration;

public class EquivalencyOptionsSpecs
{
    [Fact]
    public async Task When_injecting_a_null_configurer_it_should_throw()
    {
        // Arrange / Act
        var action = () => AssertionConfiguration.Current.Equivalency.Modify(configureOptions: null);

        // Assert
        await Expect.That(action).ThrowsExactly<ArgumentNullException>();
    }

    [Fact]
    public async Task When_concurrently_getting_equality_strategy_it_should_not_throw()
    {
        // Arrange / Act
        var action = () =>
        {
#pragma warning disable CA1859 // https://github.com/dotnet/roslyn-analyzers/issues/6704
            IEquivalencyOptions equivalencyOptions = new EquivalencyOptions();
#pragma warning restore CA1859

            return () => Parallel.For(0, 10_000, new ParallelOptions { MaxDegreeOfParallelism = 8 },
                _ => equivalencyOptions.GetEqualityStrategy(typeof(IEnumerable))
            );
        };

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Collection("ConfigurationSpecs")]
    public sealed class Given_temporary_global_assertion_options : IDisposable
    {
        /* TODO VAB
        [Fact]
        public async Task When_modifying_global_reference_type_settings_a_previous_assertion_should_not_have_any_effect_it_should_try_to_compare_the_classes_by_member_semantics_and_thus_throw()
        {
            // Arrange
            // Trigger a first equivalency check using the default global settings
            await Expect.That(new MyValueType { Value = 1 }).IsEquivalentTo(new MyValueType { Value = 2 });

            AssertionConfiguration.Current.Equivalency.Modify(o => o.ComparingByMembers<MyValueType>());

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(new MyValueType { Value = 1 }).IsEquivalentTo(new MyValueType { Value = 2 }));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        internal class MyValueType
        {
            [UsedImplicitly]
            public int Value { get; set; }

            public override bool Equals(object obj) => true;

            public override int GetHashCode() => 0;
        }

        [Fact]
        public async Task When_modifying_global_value_type_settings_a_previous_assertion_should_not_have_any_effect_it_should_try_to_compare_the_classes_by_value_semantics_and_thus_throw()
        {
            // Arrange
            // Trigger a first equivalency check using the default global settings
            await Expect.That(new MyClass { Value = 1 }).IsEquivalentTo(new MyClass { Value = 1 });

            AssertionConfiguration.Current.Equivalency.Modify(o => o.ComparingByValue<MyClass>());

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(new MyClass() { Value = 1 }).IsEquivalentTo(new MyClass { Value = 1 }));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        internal class MyClass
        {
            [UsedImplicitly]
            public int Value { get; set; }
        }

        [Fact]
        public async Task When_modifying_record_settings_globally_it_should_use_the_global_settings_for_comparing_records()
        {
            // Arrange
            AssertionConfiguration.Current.Equivalency.Modify(o => o.ComparingByValue(typeof(Position)));

            // Act / Assert
            await Expect.That(new Position(123)).IsEquivalentTo(new Position(123));
        }

        private record Position
        {
            [UsedImplicitly]
            private readonly int value;

            public Position(int value)
            {
                this.value = value;
            }
        }

        [Fact]
        public async Task When_assertion_doubles_should_always_allow_small_deviations_then_it_should_ignore_small_differences_without_the_need_of_local_options()
        {
            // Arrange
            AssertionConfiguration.Current.Equivalency.Modify(options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 0.01))
                .WhenTypeIs<double>());

            var actual = new
            {
                Value = 1D / 3D
            };

            var expected = new
            {
                Value = 0.33D
            };

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsEquivalentTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_local_similar_options_are_used_then_they_should_override_the_global_options()
        {
            // Arrange
            AssertionConfiguration.Current.Equivalency.Modify(options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 0.01))
                .WhenTypeIs<double>());

            var actual = new
            {
                Value = 1D / 3D
            };

            var expected = new
            {
                Value = 0.33D
            };

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsEquivalentTo(expected).Because(options => options
                .Using<double>(ctx => ctx.Subject.Should().Be(ctx.Expectation))
                .WhenTypeIs<double>()));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_local_similar_options_are_used_then_they_should_not_affect_any_other_assertions()
        {
            // Arrange
            AssertionConfiguration.Current.Equivalency.Modify(options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 0.01))
                .WhenTypeIs<double>());

            var actual = new
            {
                Value = 1D / 3D
            };

            var expected = new
            {
                Value = 0.33D
            };

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsEquivalentTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
        */

        public void Dispose() =>
            AssertionConfiguration.Current.Equivalency.Modify(_ => new EquivalencyOptions());
    }

    [Collection("ConfigurationSpecs")]
    public sealed class Given_self_resetting_equivalency_plan : IDisposable
    {
        private static EquivalencyPlan Plan => AssertionConfiguration.Current.Equivalency.Plan;

        [Fact]
        public async Task When_inserting_a_step_then_it_should_precede_all_other_steps()
        {
            // Arrange / Act
            Plan.Insert<MyEquivalencyStep>();

            // Assert
            var addedStep = Plan.LastOrDefault(s => s is MyEquivalencyStep);

            await Expect.That(Plan).StartsWith(addedStep);
        }

        [Fact]
        public void When_inserting_a_step_before_another_then_it_should_precede_that_particular_step()
        {
            // Arrange / Act
            Plan.InsertBefore<DictionaryEquivalencyStep, MyEquivalencyStep>();

            // Assert
            var addedStep = Plan.LastOrDefault(s => s is MyEquivalencyStep);
            var successor = Plan.LastOrDefault(s => s is DictionaryEquivalencyStep);

            Plan.Should().HaveElementPreceding(successor, addedStep);
        }

        [Fact]
        public void When_appending_a_step_then_it_should_precede_the_final_builtin_step()
        {
            // Arrange / Act
            Plan.Add<MyEquivalencyStep>();

            // Assert
            var equivalencyStep = Plan.LastOrDefault(s => s is SimpleEqualityEquivalencyStep);
            var subjectStep = Plan.LastOrDefault(s => s is MyEquivalencyStep);

            Plan.Should().HaveElementPreceding(equivalencyStep, subjectStep);
        }

        [Fact]
        public void When_appending_a_step_after_another_then_it_should_precede_the_final_builtin_step()
        {
            // Arrange / Act
            Plan.AddAfter<DictionaryEquivalencyStep, MyEquivalencyStep>();

            // Assert
            var addedStep = Plan.LastOrDefault(s => s is MyEquivalencyStep);
            var predecessor = Plan.LastOrDefault(s => s is DictionaryEquivalencyStep);

            Plan.Should().HaveElementSucceeding(predecessor, addedStep);
        }

        [Fact]
        public async Task When_appending_a_step_and_no_builtin_steps_are_there_then_it_should_precede_the_simple_equality_step()
        {
            // Arrange / Act
            Plan.Clear();
            Plan.Add<MyEquivalencyStep>();

            // Assert
            var subjectStep = Plan.LastOrDefault(s => s is MyEquivalencyStep);
            await Expect.That(Plan).EndsWith(subjectStep);
        }

        [Fact]
        public async Task When_removing_a_specific_step_then_it_should_precede_the_simple_equality_step()
        {
            // Arrange / Act
            Plan.Remove<SimpleEqualityEquivalencyStep>();

            // Assert
            await Expect.That(Plan).DoesNotContain(s => s is SimpleEqualityEquivalencyStep);
        }

        [Fact]
        public async Task When_removing_a_specific_step_that_doesnt_exist_Then_it_should_precede_the_simple_equality_step()
        {
            // Arrange / Act
            var action = () => Plan.Remove<MyEquivalencyStep>();

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        private class MyEquivalencyStep : IEquivalencyStep
        {
            public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context,
                IValidateChildNodeEquivalency valueChildNodes)
            {
                AssertionChain.GetOrCreate().For(context).FailWith(GetType().FullName);

                return EquivalencyResult.EquivalencyProven;
            }
        }

        public void Dispose() => Plan.Reset();
    }
}

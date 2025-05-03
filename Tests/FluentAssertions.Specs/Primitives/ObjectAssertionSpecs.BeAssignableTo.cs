using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class BeAssignableTo
    {
        [Fact]
        public async Task When_object_type_is_matched_against_null_type_it_should_throw()
        {
            // Arrange
            var someObject = new object();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).Is(null));

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_its_own_type_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).Is<DummyImplementingClass>();
        }

        [Fact]
        public async Task When_its_base_type_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).Is<DummyBaseClass>();
        }

        [Fact]
        public async Task When_an_implemented_interface_type_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).Is<IDisposable>();
        }

        [Fact]
        public async Task When_an_unrelated_type_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).Is<DateTime>().Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_null_instance_is_asserted_to_be_assignableOfT_it_should_fail()
        {
            // Arrange
            object someObject = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(someObject).Is<DateTime>().Because($"because we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_its_own_type_instance_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).Is(typeof(DummyImplementingClass));
        }

        [Fact]
        public async Task When_its_base_type_instance_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).Is(typeof(DummyBaseClass));
        }

        [Fact]
        public async Task When_an_implemented_interface_type_instance_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).Is(typeof(IDisposable));
        }

        [Fact]
        public async Task When_an_implemented_open_generic_interface_type_instance_it_should_succeed()
        {
            // Arrange
            var someObject = new List<string>();

            // Act / Assert
            await Expect.That(someObject).Is(typeof(IList<>));
        }

        [Fact]
        public async Task When_a_null_instance_is_asserted_to_be_assignable_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            object someObject = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(someObject).Is(typeof(DateTime)).Because($"because we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_unrelated_type_instance_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).Is(typeof(DateTime)).Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_unrelated_to_open_generic_type_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).Is(typeof(IList<>)).Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeAssignableTo
    {
        [Fact]
        public async Task When_object_type_is_matched_negatively_against_null_type_it_should_throw()
        {
            // Arrange
            var someObject = new object();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot(null));

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_its_own_type_and_asserting_not_assignable_it_should_fail_with_a_useful_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot<DummyImplementingClass>().Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_its_base_type_and_asserting_not_assignable_it_should_fail_with_a_useful_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot<DummyBaseClass>().Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_implemented_interface_type_and_asserting_not_assignable_it_should_fail_with_a_useful_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot<IDisposable>().Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_unrelated_type_and_asserting_not_assignable_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).IsNot<DateTime>();
        }

        [Fact]
        public async Task When_not_to_the_unexpected_type_and_asserting_not_assignable_it_should_not_cast_the_returned_object_for_chaining()
        {
            // Arrange
            var someObject = new Exception("Actual Message");

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot<DummyImplementingClass>());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_its_own_type_instance_and_asserting_not_assignable_it_should_fail_with_a_useful_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot(typeof(DummyImplementingClass)).Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_its_base_type_instance_and_asserting_not_assignable_it_should_fail_with_a_useful_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot(typeof(DummyBaseClass)).Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_implemented_interface_type_instance_and_asserting_not_assignable_it_should_fail_with_a_useful_message()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot(typeof(IDisposable)).Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_implemented_open_generic_interface_type_instance_and_asserting_not_assignable_it_should_fail_with_a_useful_message()
        {
            // Arrange
            var someObject = new List<string>();

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNot(typeof(IList<>)).Because($"because we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_null_instance_is_asserted_to_not_be_assignable_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            object someObject = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(someObject).IsNot(typeof(DateTime)).Because($"because we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_unrelated_type_instance_and_asserting_not_assignable_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).IsNot(typeof(DateTime)).Because($"because we want to test the failure {"message"}");
        }

        [Fact]
        public async Task When_unrelated_to_open_generic_type_and_asserting_not_assignable_it_should_succeed()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act / Assert
            await Expect.That(someObject).IsNot(typeof(IList<>)).Because($"because we want to test the failure {"message"}");
        }
    }
}

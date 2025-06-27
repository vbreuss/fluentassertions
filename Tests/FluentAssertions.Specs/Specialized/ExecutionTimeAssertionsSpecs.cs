using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using FluentAssertions.Specialized;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Specialized;

public class ExecutionTimeAssertionsSpecs
{
    public class BeLessThanOrEqualTo
    {
        [Fact]
        public async Task When_the_execution_time_of_a_member_is_not_less_than_or_equal_to_a_limit_it_should_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(610)).Should().BeLessThanOrEqualTo(500.Milliseconds(),
                "we like speed");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_a_member_is_less_than_or_equal_to_a_limit_it_should_not_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(0)).Should().BeLessThanOrEqualTo(500.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_not_less_than_or_equal_to_a_limit_it_should_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(510);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThanOrEqualTo(100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_less_than_or_equal_to_a_limit_it_should_not_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(100);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThanOrEqualTo(1.Seconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_action_runs_indefinitely_it_should_be_stopped_and_throw_if_there_is_less_than_or_equal_condition()
        {
            // Arrange
            Action someAction = () =>
            {
                // lets cause a deadlock
                var semaphore = new Semaphore(0, 1); // my weapon of choice is a semaphore
                semaphore.WaitOne(); // oops
            };

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThanOrEqualTo(100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Actions_with_brackets_fail_with_correctly_formatted_message()
        {
            // Arrange
            var subject = new List<object>();

            // Act
            Action act = () =>
                subject.ExecutionTimeOf(s => s.AddRange(new object[] { })).Should().BeLessThanOrEqualTo(1.Nanoseconds());

            // Assert
            await That(act).ThrowsExactly<XunitException>();
        }

        [Fact]
        public void Chaining_after_one_assertion()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act / Assert
            subject.ExecutionTimeOf(s => s.Sleep(0))
                .Should().BeLessThanOrEqualTo(500.Milliseconds())
                .And.BeCloseTo(0.Seconds(), 500.Milliseconds());
        }
    }

    public class BeLessThan
    {
        [Fact]
        public async Task When_the_execution_time_of_a_member_is_not_less_than_a_limit_it_should_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(610)).Should().BeLessThan(500.Milliseconds(),
                "we like speed");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_a_member_is_less_than_a_limit_it_should_not_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(0)).Should().BeLessThan(500.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_not_less_than_a_limit_it_should_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(510);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThan(100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_async_action_is_not_less_than_a_limit_it_should_throw()
        {
            // Arrange
            Func<Task> someAction = () => Task.Delay(TimeSpan.FromMilliseconds(150));

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThan(100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_less_than_a_limit_it_should_not_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(100);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThan(2.Seconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_async_action_is_less_than_a_limit_it_should_not_throw()
        {
            // Arrange
            Func<Task> someAction = () => Task.Delay(TimeSpan.FromMilliseconds(100));

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThan(20.Seconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_action_runs_indefinitely_it_should_be_stopped_and_throw_if_there_is_less_than_condition()
        {
            // Arrange
            Action someAction = () =>
            {
                // lets cause a deadlock
                var semaphore = new Semaphore(0, 1); // my weapon of choice is a semaphore
                semaphore.WaitOne(); // oops
            };

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThan(100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Actions_with_brackets_fail_with_correctly_formatted_message()
        {
            // Arrange
            var subject = new List<object>();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.AddRange(new object[] { })).Should().BeLessThan(1.Nanoseconds());

            // Assert
            await That(act).ThrowsExactly<XunitException>();
        }
    }

    public class BeGreaterThanOrEqualTo
    {
        [Fact]
        public async Task When_the_execution_time_of_a_member_is_not_greater_than_or_equal_to_a_limit_it_should_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(100)).Should().BeGreaterThanOrEqualTo(1.Seconds(),
                "we like speed");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_a_member_is_greater_than_or_equal_to_a_limit_it_should_not_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(100)).Should().BeGreaterThanOrEqualTo(50.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_not_greater_than_or_equal_to_a_limit_it_should_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(100);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeGreaterThanOrEqualTo(1.Seconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_greater_than_or_equal_to_a_limit_it_should_not_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(100);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeGreaterThanOrEqualTo(50.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_action_runs_indefinitely_it_should_be_stopped_and_not_throw_if_there_is_greater_than_or_equal_condition()
        {
            // Arrange
            Action someAction = () =>
            {
                // lets cause a deadlock
                var semaphore = new Semaphore(0, 1); // my weapon of choice is a semaphore
                semaphore.WaitOne(); // oops
            };

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeGreaterThanOrEqualTo(100.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Actions_with_brackets_fail_with_correctly_formatted_message()
        {
            // Arrange
            var subject = new List<object>();

            // Act
            Action act = () =>
                subject.ExecutionTimeOf(s => s.AddRange(new object[] { })).Should().BeGreaterThanOrEqualTo(1.Days());

            // Assert
            await That(act).ThrowsExactly<XunitException>();
        }

        [Fact]
        public void Chaining_after_one_assertion()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act / Assert
            subject.ExecutionTimeOf(s => s.Sleep(100))
                .Should().BeGreaterThanOrEqualTo(50.Milliseconds())
                .And.BeCloseTo(0.Seconds(), 500.Milliseconds());
        }
    }

    public class BeGreaterThan
    {
        [Fact]
        public async Task When_the_execution_time_of_a_member_is_not_greater_than_a_limit_it_should_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(100)).Should().BeGreaterThan(1.Seconds(),
                "we like speed");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_a_member_is_greater_than_a_limit_it_should_not_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(200)).Should().BeGreaterThan(100.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_not_greater_than_a_limit_it_should_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(100);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeGreaterThan(1.Seconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_greater_than_a_limit_it_should_not_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(200);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeGreaterThan(100.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_action_runs_indefinitely_it_should_be_stopped_and_not_throw_if_there_is_greater_than_condition()
        {
            // Arrange
            Action someAction = () =>
            {
                // lets cause a deadlock
                var semaphore = new Semaphore(0, 1); // my weapon of choice is a semaphore
                semaphore.WaitOne(); // oops
            };

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeGreaterThan(100.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Actions_with_brackets_fail_with_correctly_formatted_message()
        {
            // Arrange
            var subject = new List<object>();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.AddRange(new object[] { })).Should().BeGreaterThan(1.Days());

            // Assert
            await That(act).ThrowsExactly<XunitException>();
        }
    }

    public class BeCloseTo
    {
        [Fact]
        public async Task When_asserting_that_execution_time_is_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(200)).Should().BeCloseTo(100.Milliseconds(),
                -1.Ticks());

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_a_member_is_not_close_to_a_limit_it_should_throw()
        {
            // Arrange
            var subject = new SleepingClass();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(200)).Should().BeCloseTo(100.Milliseconds(),
                50.Milliseconds(),
                "we like speed");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_a_member_is_close_to_a_limit_it_should_not_throw()
        {
            // Arrange
            var subject = new SleepingClass();
            var timer = new TestTimer(() => 210.Milliseconds());

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.Sleep(0), () => timer).Should().BeCloseTo(200.Milliseconds(),
                150.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_not_close_to_a_limit_it_should_throw()
        {
            // Arrange
            Action someAction = () => Thread.Sleep(200);

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeCloseTo(100.Milliseconds(), 50.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_execution_time_of_an_action_is_close_to_a_limit_it_should_not_throw()
        {
            // Arrange
            Action someAction = () => { };
            var timer = new TestTimer(() => 210.Milliseconds());

            // Act
            Action act = () => someAction.ExecutionTime(() => timer).Should().BeCloseTo(200.Milliseconds(), 15.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_action_runs_indefinitely_it_should_be_stopped_and_throw_if_there_is_be_close_to_condition()
        {
            // Arrange
            Action someAction = () =>
            {
                // lets cause a deadlock
                var semaphore = new Semaphore(0, 1); // my weapon of choice is a semaphore
                semaphore.WaitOne(); // oops
            };

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeCloseTo(100.Milliseconds(), 50.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Actions_with_brackets_fail_with_correctly_formatted_message()
        {
            // Arrange
            var subject = new List<object>();

            // Act
            Action act = () => subject.ExecutionTimeOf(s => s.AddRange(new object[] { }))
                .Should().BeCloseTo(1.Days(), 50.Milliseconds());

            // Assert
            await That(act).ThrowsExactly<XunitException>();
        }
    }

    public class ExecutingTime
    {
        [Fact]
        public async Task When_action_runs_inside_execution_time_exceptions_are_captured_and_rethrown()
        {
            // Arrange
            Action someAction = () => throw new ArgumentException("Let's say somebody called the wrong method.");

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThan(200.Milliseconds());

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_asserting_on_null_execution_it_should_throw()
        {
            // Arrange
            ExecutionTime executionTime = null;

            // Act
            Func<ExecutionTimeAssertions> act = () => new ExecutionTimeAssertions(executionTime, AssertionChain.GetOrCreate());

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_on_null_action_it_should_throw()
        {
            // Arrange
            Action someAction = null;

            // Act
            Action act = () => someAction.ExecutionTime().Should().BeLessThan(1.Days());

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_on_null_func_it_should_throw()
        {
            // Arrange
            Func<Task> someFunc = null;

            // Act
            Action act = () => someFunc.ExecutionTime().Should().BeLessThan(1.Days());

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_execution_time_of_null_action_it_should_throw()
        {
            // Arrange
            object subject = null;

            // Act
            var act = () => subject.ExecutionTimeOf(s => s.ToString()).Should().BeLessThan(1.Days());

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_execution_time_of_null_it_should_throw()
        {
            // Arrange
            var subject = new object();

            // Act
            Action act = () => subject.ExecutionTimeOf(null).Should().BeLessThan(1.Days());

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_accidentally_using_equals_it_should_throw_a_helpful_error()
        {
            // Arrange
            var subject = new object();

            // Act
            var act = () => subject.ExecutionTimeOf(s => s.ToString()).Should().Equals(1.Seconds());

            // Assert
            await That(act).Throws<NotSupportedException>();
        }
    }

    internal class SleepingClass
    {
        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}

// ReSharper disable AsyncVoidLambda

using System;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
#if NET47
using FluentAssertions.Specs.Common;
#endif
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Exceptions;

public class AsyncFunctionExceptionAssertionSpecs
{
    [Fact]
    public async Task When_getting_the_subject_it_should_remain_unchanged()
    {
        // Arrange
        Func<Task> subject = () => Task.FromResult(42);

        // Act
        Action action = () => subject.Should().Subject.As<object>().Should().BeSameAs(subject);

        // Assert
        await Expect.That(action).DoesNotThrow().Because("the Subject should remain the same");
    }

    [Fact]
    public async Task When_subject_is_null_when_expecting_an_exception_it_should_throw()
    {
        // Arrange
        Func<Task> action = null;

        // Act
        Func<Task> testAction = async () =>
        {
            await Expect.That(action).Throws<ArgumentException>().Because($"because we want to test the failure {"message"}");
        };

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*because we want to test the failure message*was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_subject_is_null_when_not_expecting_a_generic_exception_it_should_throw()
    {
        // Arrange
        Func<Task> action = null;

        // Act
        Func<Task> testAction = async () =>
        {
            using var _ = new AssertionScope();
            await Expect.That(action).DoesNotThrow().Because($"because we want to test the failure {"message"}");
        };

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*because we want to test the failure message*was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_subject_is_null_when_not_expecting_an_exception_it_should_throw()
    {
        // Arrange
        Func<Task> action = null;

        // Act
        Func<Task> testAction = async () =>
        {
            using var _ = new AssertionScope();
            await Expect.That(action).DoesNotThrow().Because($"because we want to test the failure {"message"}");
        };

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*because we want to test the failure message*was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_an_empty_AggregateException_it_should_fail()
    {
        // Arrange
        Func<Task> act = () => throw new AggregateException();

        // Act
        Func<Task> act2 = async () => await Expect.That(act).DoesNotThrow();

        // Assert
        await Expect.That(act2).Throws<XunitException>();
    }

    [Collection("UIFacts")]
    public partial class UIFacts
    {
        [UIFact]
        public async Task When_async_method_throws_an_empty_AggregateException_on_UI_thread_it_should_fail()
        {
            // Arrange
            Func<Task> act = () => throw new AggregateException();

            // Act
            Func<Task> act2 = async () => await Expect.That(act).DoesNotThrow();

            // Assert
            await Expect.That(act2).Throws<XunitException>();
        }
    }

    [Fact]
    public async Task When_async_method_throws_a_nested_AggregateException_it_should_provide_the_message()
    {
        // Arrange
        Func<Task> act = () => throw new AggregateException(new ArgumentException("That was wrong."));

        // Act & Assert
        await Expect.That(act).Throws<AggregateException>().WithMessage("*That was wrong.*").AsWildcard();
    }

    public partial class UIFacts
    {
        [UIFact]
        public async Task When_async_method_throws_a_nested_AggregateException_on_UI_thread_it_should_provide_the_message()
        {
            // Arrange
            Func<Task> act = () => throw new AggregateException(new ArgumentException("That was wrong."));

            // Act & Assert
            await Expect.That(act).Throws<AggregateException>().WithMessage("*That was wrong.*").AsWildcard();
        }
    }

    [Fact]
    public async Task When_async_method_throws_a_flat_AggregateException_it_should_provide_the_message()
    {
        // Arrange
        Func<Task> act = () => throw new AggregateException("That was wrong as well.");

        // Act & Assert
        await Expect.That(act).Throws<AggregateException>().WithMessage("That was wrong as well.").AsWildcard();
    }

    [Fact(Skip= "https://github.com/aweXpect/aweXpect/issues/573")]
    public async Task When_async_method_throws_a_nested_AggregateException_it_should_provide_unwrapped_exception_to_predicate()
    {
        // Arrange
        Func<Task> act = () => throw new AggregateException(new ArgumentException("That was wrong."));

        // Act & Assert
        await Expect.That(act).Throws<ArgumentException>();
    }

    [Fact]
    public async Task When_async_method_throws_a_flat_AggregateException_it_should_provide_it_to_predicate()
    {
        // Arrange
        Func<Task> act = () => throw new AggregateException("That was wrong as well.");

        // Act & Assert
        await Expect.That(act).Throws<AggregateException>();
    }

#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
    [Theory]
    [MemberData(nameof(AggregateExceptionTestData))]
    public async Task When_the_expected_exception_is_not_wrapped_async_it_should_fail<T>(Func<Task> action, T _)
        where T : Exception
    {
        // Act
        Func<Task> act2 = async () => await Expect.That(action).DoesNotThrow();

        // Assert
        await Expect.That(act2).Throws<XunitException>();
    }

    [UITheory]
    [MemberData(nameof(AggregateExceptionTestData))]
    public async Task When_the_expected_exception_is_not_wrapped_on_UI_thread_async_it_should_fail<T>(Func<Task> action, T _)
        where T : Exception
    {
        // Act
        Func<Task> act2 = async () => await Expect.That(action).DoesNotThrow();

        // Assert
        await Expect.That(act2).Throws<XunitException>();
    }
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters

    public static TheoryData<Func<Task>, Exception> AggregateExceptionTestData()
    {
        Func<Task>[] tasks =
        [
            AggregateExceptionWithLeftNestedException,
            AggregateExceptionWithRightNestedException
        ];

        Exception[] types =
        [
            new AggregateException(),
            new ArgumentNullException(),
            new InvalidOperationException()
        ];

        var data = new TheoryData<Func<Task>, Exception>();

        foreach (var task in tasks)
        {
            foreach (var type in types)
            {
                data.Add(task, type);
            }
        }

        data.Add(EmptyAggregateException, new AggregateException());

        return data;
    }

    private static Task AggregateExceptionWithLeftNestedException()
    {
        var ex1 = new AggregateException(new InvalidOperationException());
        var ex2 = new ArgumentNullException();
        var wrapped = new AggregateException(ex1, ex2);

        return FromException(wrapped);
    }

    private static Task AggregateExceptionWithRightNestedException()
    {
        var ex1 = new ArgumentNullException();
        var ex2 = new AggregateException(new InvalidOperationException());
        var wrapped = new AggregateException(ex1, ex2);

        return FromException(wrapped);
    }

    private static Task EmptyAggregateException()
    {
        return FromException(new AggregateException());
    }

    private static Task FromException(AggregateException exception)
    {
        return Task.FromException(exception);
    }

    [Fact]
    public async Task When_subject_throws_subclass_of_expected_exact_exception_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsync<ArgumentNullException>())
            .Should().ThrowExactlyAsync<ArgumentException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected type to be System.ArgumentException because IFoo.Do should do that, but found System.ArgumentNullException.").AsWildcard();
    }

    [Fact]
    public async Task When_subject_ValueTask_throws_subclass_of_expected_exact_exception_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsyncValueTask<ArgumentNullException>())
            .Should().ThrowExactlyAsync<ArgumentException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected type to be System.ArgumentException because IFoo.Do should do that, but found System.ArgumentNullException.").AsWildcard();
    }

    [Fact]
    public async Task When_subject_throws_aggregate_exception_and_not_expected_exact_exception_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAggregateExceptionAsync<ArgumentException>())
            .Should().ThrowExactlyAsync<ArgumentException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected type to be System.ArgumentException because IFoo.Do should do that, but found System.AggregateException.").AsWildcard();
    }

    [Fact]
    public async Task When_subject_throws_aggregate_exception_and_not_expected_exact_exception_through_ValueTask_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAggregateExceptionAsyncValueTask<ArgumentException>())
            .Should().ThrowExactlyAsync<ArgumentException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected type to be System.ArgumentException because IFoo.Do should do that, but found System.AggregateException.").AsWildcard();
    }

    [Fact]
    public async Task When_subject_throws_the_expected_exact_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act / Assert
        await asyncObject
            .Awaiting(x => x.ThrowAsync<ArgumentNullException>())
            .Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task When_subject_throws_the_expected_exact_exception_through_ValueTask_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act / Assert
        await asyncObject
            .Awaiting(x => x.ThrowAsyncValueTask<ArgumentNullException>())
            .Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task When_async_method_throws_expected_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsync<ArgumentException>())
            .Should().ThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_expected_exception_through_ValueTask_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsyncValueTask<ArgumentException>())
            .Should().ThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_subject_is_null_it_should_be_null()
    {
        // Arrange
        Func<Task> subject = null;

        // Act
        Func<Task> action = async () => await Expect.That(subject).DoesNotThrow();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_async_expected_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject.ThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).Throws<ArgumentException>();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_expected_exception_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.SucceedAsync())
            .Should().ThrowAsync<InvalidOperationException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected a <System.InvalidOperationException> to be thrown because IFoo.Do should do that, but no exception was thrown.").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_expected_exception_through_ValueTask_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.SucceedAsyncValueTask())
            .Should().ThrowAsync<InvalidOperationException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected a <System.InvalidOperationException> to be thrown because IFoo.Do should do that, but no exception was thrown.").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_unexpected_exception_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsync<ArgumentException>())
            .Should().ThrowAsync<InvalidOperationException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected a <System.InvalidOperationException> to be thrown because IFoo.Do should do that, but found <System.ArgumentException>*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_unexpected_exception_through_ValueTask_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsyncValueTask<ArgumentException>())
            .Should().ThrowAsync<InvalidOperationException>("because {0} should do that", "IFoo.Do");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected a <System.InvalidOperationException> to be thrown because IFoo.Do should do that, but found <System.ArgumentException>*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_exception_and_that_was_expected_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.SucceedAsync())
            .Should().NotThrowAsync();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_exception_through_ValueTask_and_that_was_expected_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.SucceedAsyncValueTask())
            .Should().NotThrowAsync();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_async_exception_and_that_was_expected_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject.SucceedAsync();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    public partial class UIFacts
    {
        [UIFact]
        public async Task When_async_method_does_not_throw_async_exception_on_UI_thread_and_that_was_expected_it_should_succeed()
        {
            // Arrange
            var asyncObject = new AsyncClass();

            // Act
            Func<Task> action = () => asyncObject.SucceedAsync();

            // Assert
            await Expect.That(action).DoesNotThrow();
        }
    }

    [Fact]
    public async Task When_subject_throws_subclass_of_expected_async_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject.ThrowAsync<ArgumentNullException>();

        // Assert
        await Expect.That(action).Throws<ArgumentException>().Because($"because {"IFoo.Do"} should do that");
    }

    [Fact]
    public async Task When_function_of_task_int_in_async_method_throws_the_expected_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();
        Func<Task<int>> f = () => asyncObject.ThrowTaskIntAsync<ArgumentNullException>(true);

        // Act / Assert
        await Expect.That(f).Throws<ArgumentNullException>();
    }

    [Fact]
    public async Task When_function_of_task_int_in_async_method_throws_not_excepted_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();
        Func<Task<int>> f = () => asyncObject.ThrowTaskIntAsync<InvalidOperationException>(true);

        // Act / Assert
        await Expect.That(f).DoesNotThrow<ArgumentNullException>();
    }

    [Fact]
    public async Task When_subject_is_null_when_expecting_an_exact_exception_it_should_throw()
    {
        // Arrange
        Func<Task> action = null;

        // Act
        Func<Task> testAction = async () =>
        {
            await Expect.That(action).ThrowsExactly<ArgumentException>().Because($"because we want to test the failure {"message"}");
        };

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*because we want to test the failure message*was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_subject_throws_subclass_of_expected_async_exact_exception_it_should_throw()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject.ThrowAsync<ArgumentNullException>();
        Func<Task> testAction = async () => await Expect.That(action).ThrowsExactly<ArgumentException>().Because("ABCDE");

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*ArgumentException*ABCDE*ArgumentNullException*").AsWildcard();
    }

    [Fact]
    public async Task When_subject_throws_aggregate_exception_instead_of_exact_exception_it_should_throw()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject.ThrowAggregateExceptionAsync<ArgumentException>();
        Func<Task> testAction = async () => await Expect.That(action).ThrowsExactly<ArgumentException>().Because("ABCDE");

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*ArgumentException*ABCDE*AggregateException*").AsWildcard();
    }

    [Fact]
    public async Task When_subject_throws_expected_async_exact_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject.ThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).ThrowsExactly<ArgumentException>().Because($"because {"IFoo.Do"} should do that");
    }

    public partial class UIFacts
    {
        [UIFact]
        public async Task When_subject_throws_on_UI_thread_expected_async_exact_exception_it_should_succeed()
        {
            // Arrange
            var asyncObject = new AsyncClass();

            // Act
            Func<Task> action = () => asyncObject.ThrowAsync<ArgumentException>();

            // Assert
            await Expect.That(action).ThrowsExactly<ArgumentException>().Because($"because {"IFoo.Do"} should do that");
        }
    }

    [Fact]
    public async Task When_async_method_throws_exception_and_no_exception_was_expected_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsync<ArgumentException>())
            .Should().NotThrowAsync();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect any exception, but found System.ArgumentException*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_exception_through_ValueTask_and_no_exception_was_expected_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsyncValueTask<ArgumentException>())
            .Should().NotThrowAsync();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect any exception, but found System.ArgumentException*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_exception_and_expected_not_to_throw_another_one_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsync<ArgumentException>())
            .Should().NotThrowAsync<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task
        When_async_method_throws_exception_through_ValueTask_and_expected_not_to_throw_another_one_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsyncValueTask<ArgumentException>())
            .Should().NotThrowAsync<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_exception_and_expected_not_to_throw_async_another_one_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject.ThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).DoesNotThrow<InvalidOperationException>();
    }

    [Fact]
    public async Task When_async_method_succeeds_and_expected_not_to_throw_particular_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(_ => asyncObject.SucceedAsync())
            .Should().NotThrowAsync<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task
        When_async_method_succeeds_and_expected_not_to_throw_particular_exception_through_ValueTask_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(_ => asyncObject.SucceedAsyncValueTask())
            .Should().NotThrowAsync<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_exception_expected_not_to_be_thrown_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsync<ArgumentException>())
            .Should().NotThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect System.ArgumentException, but found*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_exception_expected_through_ValueTask_not_to_be_thrown_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowAsyncValueTask<ArgumentException>())
            .Should().NotThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect System.ArgumentException, but found*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_of_T_succeeds_and_expected_not_to_throw_particular_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(_ => asyncObject.ReturnTaskInt())
            .Should().NotThrowAsync<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_ValueTask_async_method_of_T_succeeds_and_expected_not_to_throw_particular_exception_it_should_succeed()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(_ => asyncObject.ReturnValueTaskInt())
            .Should().NotThrowAsync<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_of_T_throws_exception_expected_not_to_be_thrown_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowTaskIntAsync<ArgumentException>(true))
            .Should().NotThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect System.ArgumentException, but found System.ArgumentException*").AsWildcard();
    }

    [Fact]
    public async Task When_ValueTask_async_method_of_T_throws_exception_expected_not_to_be_thrown_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();

        // Act
        Func<Task> action = () => asyncObject
            .Awaiting(x => x.ThrowValueTaskIntAsync<ArgumentException>(true))
            .Should().NotThrowAsync<ArgumentException>();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect System.ArgumentException, but found System.ArgumentException*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_throws_the_expected_inner_exception_it_should_succeed()
    {
        // Arrange
        Func<Task> task = () => Throw.Async(new AggregateException(new InvalidOperationException()));

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<AggregateException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_the_expected_inner_exception_from_argument_it_should_succeed()
    {
        // Arrange
        Func<Task> task = () => Throw.Async(new AggregateException(new InvalidOperationException()));

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<AggregateException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_the_expected_inner_exception_exactly_it_should_succeed()
    {
        // Arrange
        Func<Task> task = () => Throw.Async(new AggregateException(new ArgumentException()));

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<AggregateException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_the_expected_inner_exception_exactly_defined_in_arguments_it_should_succeed()
    {
        // Arrange
        Func<Task> task = () => Throw.Async(new AggregateException(new ArgumentException()));

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<AggregateException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_aggregate_exception_containing_expected_exception_it_should_succeed()
    {
        // Arrange
        Func<Task> task = () => Throw.Async(new AggregateException(new InvalidOperationException()));

        // Act
        Func<Task> action = () => task
            .Should().ThrowAsync<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_throws_the_expected_exception_it_should_succeed()
    {
        // Arrange
        Func<Task> task = () => Throw.Async<InvalidOperationException>();

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<InvalidOperationException>();

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_the_expected_inner_exception_it_should_fail()
    {
        // Arrange
        Func<Task> task = () => Throw.Async(new AggregateException(new ArgumentException()));

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<AggregateException>().WithInner<InvalidOperationException>();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*InvalidOperation*Argument*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_the_expected_inner_exception_from_argument_it_should_fail()
    {
        // Arrange
        Func<Task> task = () => Throw.Async(new AggregateException(new ArgumentException()));

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<AggregateException>().WithInner(typeof(InvalidOperationException));

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*InvalidOperation*Argument*").AsWildcard();
    }

    [Fact]
    public async Task When_async_method_does_not_throw_the_expected_exception_it_should_fail()
    {
        // Arrange
        Func<Task> task = () => Throw.Async<ArgumentException>();

        // Act
        Func<Task> action = async () => await Expect.That(task).Throws<InvalidOperationException>();

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*InvalidOperation*Argument*").AsWildcard();
    }

#pragma warning disable MA0147
    [Fact]
    public async Task When_asserting_async_void_method_should_throw_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();
        Action asyncVoidMethod = async () => await asyncObject.IncompleteTask();

        // Act
        Func<Task> action = async () => await Expect.That(asyncVoidMethod).Throws<ArgumentException>();

        // Assert
        await Expect.That(action).Throws<InvalidOperationException>().Because("*async*void*");
    }

    [Fact]
    public async Task When_asserting_async_void_method_should_throw_exactly_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();
        Action asyncVoidMethod = async () => await asyncObject.IncompleteTask();

        // Act
        Func<Task> action = async () => await Expect.That(asyncVoidMethod).ThrowsExactly<ArgumentException>();

        // Assert
        await Expect.That(action).Throws<InvalidOperationException>().Because("*async*void*");
    }

    [Fact]
    public async Task When_asserting_async_void_method_should_not_throw_it_should_fail()
    {
        // Arrange
        var asyncObject = new AsyncClass();
        Action asyncVoidMethod = async () => await asyncObject.IncompleteTask();

        // Act
        Func<Task> action = async () => await Expect.That(asyncVoidMethod).DoesNotThrow();

        // Assert
        await Expect.That(action).Throws<InvalidOperationException>().Because("*async*void*");
    }

#pragma warning restore MA0147

    [Fact]
    public async Task When_a_method_throws_with_a_matching_parameter_name_it_should_succeed()
    {
        // Arrange
        Func<Task> task = () => new AsyncClass().ThrowAsync(new ArgumentNullException("someParameter"));

        // Act
        Func<Task> act = async () => await Expect.That(task).Throws<ArgumentException>();

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_a_method_throws_with_a_non_matching_parameter_name_it_should_fail_with_a_descriptive_message()
    {
        // Arrange
        Func<Task> task = () => new AsyncClass().ThrowAsync(new ArgumentNullException("someOtherParameter"));

        // Act
        Func<Task> act = async () => await Expect.That(task).Throws<ArgumentException>().WithParamName("someParameter");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    #region NotThrowAfterAsync

    [Fact]
    public async Task When_wait_time_is_zero_for_async_func_executed_with_wait_it_should_not_throw()
    {
        // Arrange
        var waitTime = 0.Milliseconds();
        var pollInterval = 10.Milliseconds();

        var clock = new FakeClock();
        var asyncObject = new AsyncClass();
        Func<Task> someFunc = () => asyncObject.SucceedAsync();

        // Act
        Func<Task> act = () => someFunc.Should(clock).NotThrowAfterAsync(waitTime, pollInterval);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_poll_interval_is_zero_for_async_func_executed_with_wait_it_should_not_throw()
    {
        // Arrange
        var waitTime = 10.Milliseconds();
        var pollInterval = 0.Milliseconds();

        var clock = new FakeClock();
        var asyncObject = new AsyncClass();
        Func<Task> someFunc = () => asyncObject.SucceedAsync();

        // Act
        Func<Task> act = () => someFunc.Should(clock).NotThrowAfterAsync(waitTime, pollInterval);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_subject_is_null_for_async_func_it_should_throw()
    {
        // Arrange
        var waitTime = 0.Milliseconds();
        var pollInterval = 0.Milliseconds();
        Func<Task> action = null;

        // Act
        Func<Task> testAction = async () =>
        {
            using var _ = new AssertionScope();

            await action.Should().NotThrowAfterAsync(waitTime, pollInterval,
                "because we want to test the failure {0}", "message");
        };

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*because we want to test the failure message*found <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_wait_time_is_negative_for_async_func_it_should_throw()
    {
        // Arrange
        var waitTime = -1.Milliseconds();
        var pollInterval = 10.Milliseconds();

        var asyncObject = new AsyncClass();
        Func<Task> someFunc = () => asyncObject.SucceedAsync();

        // Act
        Func<Task> act = () => someFunc.Should().NotThrowAfterAsync(waitTime, pollInterval);

        // Assert
        await Expect.That(act).Throws<ArgumentOutOfRangeException>().WithMessage("*must be non-negative*").AsWildcard();
    }

    [Fact]
    public async Task When_poll_interval_is_negative_for_async_func_it_should_throw()
    {
        // Arrange
        var waitTime = 10.Milliseconds();
        var pollInterval = -1.Milliseconds();

        var asyncObject = new AsyncClass();
        Func<Task> someFunc = () => asyncObject.SucceedAsync();

        // Act
        Func<Task> act = () => someFunc.Should().NotThrowAfterAsync(waitTime, pollInterval);

        // Assert
        await Expect.That(act).Throws<ArgumentOutOfRangeException>().WithMessage("*must be non-negative*").AsWildcard();
    }

    [Fact]
    public async Task When_no_exception_should_be_thrown_for_null_async_func_after_wait_time_it_should_throw()
    {
        // Arrange
        var waitTime = 2.Seconds();
        var pollInterval = 10.Milliseconds();

        Func<Task> func = null;

        // Act
        Func<Task> action = () => func.Should()
            .NotThrowAfterAsync(waitTime, pollInterval, "we passed valid arguments");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*but found <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_no_exception_should_be_thrown_for_async_func_after_wait_time_but_it_was_it_should_throw()
    {
        // Arrange
        var waitTime = 2.Seconds();
        var pollInterval = 10.Milliseconds();

        var clock = new FakeClock();
        var timer = clock.StartTimer();
        clock.CompleteAfter(waitTime);

        Func<Task> throwLongerThanWaitTime = async () =>
        {
            if (timer.Elapsed <= waitTime.Multiply(1.5))
            {
                throw new ArgumentException("An exception was forced");
            }

            await Task.Yield();
        };

        // Act
        Func<Task> action = () => throwLongerThanWaitTime.Should(clock)
            .NotThrowAfterAsync(waitTime, pollInterval, "we passed valid arguments");

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect any exceptions after 2s because we passed valid arguments*").AsWildcard();
    }

    public partial class UIFacts
    {
        [UIFact]
        public async Task
            When_no_exception_should_be_thrown_on_UI_thread_for_async_func_after_wait_time_but_it_was_it_should_throw()
        {
            // Arrange
            var waitTime = 2.Seconds();
            var pollInterval = 10.Milliseconds();

            var clock = new FakeClock();
            var timer = clock.StartTimer();
            clock.CompleteAfter(waitTime);

            Func<Task> throwLongerThanWaitTime = async () =>
            {
                if (timer.Elapsed <= waitTime.Multiply(1.5))
                {
                    throw new ArgumentException("An exception was forced");
                }

                await Task.Yield();
            };

            // Act
            Func<Task> action = () => throwLongerThanWaitTime.Should(clock)
                .NotThrowAfterAsync(waitTime, pollInterval, "we passed valid arguments");

            // Assert
            await Expect.That(action).Throws<XunitException>().WithMessage("Did not expect any exceptions after 2s because we passed valid arguments*").AsWildcard();
        }
    }

    [Fact]
    public async Task When_no_exception_should_be_thrown_for_async_func_after_wait_time_and_none_was_it_should_not_throw()
    {
        // Arrange
        var waitTime = 6.Seconds();
        var pollInterval = 10.Milliseconds();

        var clock = new FakeClock();
        var timer = clock.StartTimer();
        clock.Delay(waitTime);

        Func<Task> throwShorterThanWaitTime = async () =>
        {
            if (timer.Elapsed <= waitTime.Divide(12))
            {
                throw new ArgumentException("An exception was forced");
            }

            await Task.Yield();
        };

        // Act
        Func<Task> act = () => throwShorterThanWaitTime.Should(clock).NotThrowAfterAsync(waitTime, pollInterval);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    public partial class UIFacts
    {
        [UIFact]
        public async Task
            When_no_exception_should_be_thrown_on_UI_thread_for_async_func_after_wait_time_and_none_was_it_should_not_throw()
        {
            // Arrange
            var waitTime = 6.Seconds();
            var pollInterval = 10.Milliseconds();

            var clock = new FakeClock();
            var timer = clock.StartTimer();
            clock.Delay(waitTime);

            Func<Task> throwShorterThanWaitTime = async () =>
            {
                if (timer.Elapsed <= waitTime.Divide(12))
                {
                    throw new ArgumentException("An exception was forced");
                }

                await Task.Yield();
            };

            // Act
            Func<Task> act = () => throwShorterThanWaitTime.Should(clock).NotThrowAfterAsync(waitTime, pollInterval);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }

    #endregion
}

internal class AsyncClass
{
    public Task ThrowAsync<TException>()
        where TException : Exception, new() =>
        ThrowAsync(new TException());

    public Task ThrowAsync(Exception exception) =>
        Throw.Async(exception);

    public ValueTask ThrowAsyncValueTask<TException>()
        where TException : Exception, new() =>
        Throw.AsyncValueTask(new TException());

    public Task ThrowAggregateExceptionAsync<TException>()
        where TException : Exception, new() =>
        Throw.Async(new AggregateException(new TException()));

    public ValueTask ThrowAggregateExceptionAsyncValueTask<TException>()
        where TException : Exception, new() =>
        Throw.AsyncValueTask(new AggregateException(new TException()));

    public async Task SucceedAsync()
    {
        await Task.FromResult(0);
    }

    public async ValueTask SucceedAsyncValueTask()
    {
        await Task.FromResult(0);
    }

    public Task<int> ReturnTaskInt()
    {
        return Task.FromResult(0);
    }

    public ValueTask<int> ReturnValueTaskInt()
    {
        return new ValueTask<int>(0);
    }

    public Task IncompleteTask()
    {
        return new TaskCompletionSource<bool>().Task;
    }

    public async Task<int> ThrowTaskIntAsync<TException>(bool throwException)
        where TException : Exception, new()
    {
        await Task.Yield();

        if (throwException)
        {
            throw new TException();
        }

        return 123;
    }

    public async ValueTask<int> ThrowValueTaskIntAsync<TException>(bool throwException)
        where TException : Exception, new()
    {
        await Task.Yield();

        if (throwException)
        {
            throw new TException();
        }

        return 123;
    }
}

internal static class Throw
{
    public static Task Async<TException>()
        where TException : Exception, new() =>
        Async(new TException());

    public static async Task Async(Exception expcetion)
    {
        await Task.Yield();
        throw expcetion;
    }

    public static async ValueTask AsyncValueTask(Exception expcetion)
    {
        await Task.Yield();
        throw expcetion;
    }
}

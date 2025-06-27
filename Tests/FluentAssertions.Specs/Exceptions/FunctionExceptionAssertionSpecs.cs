using System;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
#if NET47
using FluentAssertions.Specs.Common;
#endif
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Exceptions;

public class FunctionExceptionAssertionSpecs
{
    [Fact]
    public async Task When_subject_is_null_when_not_expecting_an_exception_it_should_throw()
    {
        // Arrange
        Func<int> action = null;

        // Act
        Func<Task> testAction = async () =>
        {
            await Expect.That(action).DoesNotThrow().Because($"because we want to test the failure {"message"}");
        }
        ;

        // Assert
        await Expect.That(testAction).Throws<XunitException>().WithMessage("*because we want to test the failure message*it was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_method_throws_an_empty_AggregateException_it_should_fail()
    {
        // Arrange
        Func<int> act = () => throw new AggregateException();

        // Act
        Action act2 = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(act).DoesNotThrow());

        // Assert
        await Expect.That(act2).Throws<XunitException>();
    }

    public static TheoryData<Func<int>, Exception> AggregateExceptionTestData()
    {
        Func<int>[] tasks =
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

        var data = new TheoryData<Func<int>, Exception>();

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

    private static int AggregateExceptionWithLeftNestedException()
    {
        var ex1 = new AggregateException(new InvalidOperationException());
        var ex2 = new ArgumentNullException();
        var wrapped = new AggregateException(ex1, ex2);

        throw wrapped;
    }

    private static int AggregateExceptionWithRightNestedException()
    {
        var ex1 = new ArgumentNullException();
        var ex2 = new AggregateException(new InvalidOperationException());
        var wrapped = new AggregateException(ex1, ex2);

        throw wrapped;
    }

    private static int EmptyAggregateException()
    {
        throw new AggregateException();
    }

    #region Throw

    [Fact]
    public async Task When_subject_is_null_when_an_exception_should_be_thrown_it_should_throw()
    {
        // Arrange
        Func<int> act = null;

        // Act
        Func<Task> action = async () =>
        {
            await Expect.That(act).Throws<ArgumentNullException>().Because($"because we want to test the failure {"message"}");
        };

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*because we want to test the failure message*it was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_function_throws_the_expected_exception_it_should_succeed()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act / Assert
        await Expect.That(f).Throws<ArgumentNullException>();
    }

    [Fact]
    public async Task When_function_throws_subclass_of_the_expected_exception_it_should_succeed()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act / Assert
        await Expect.That(f).Throws<ArgumentException>();
    }

    [Fact]
    public async Task When_function_does_not_throw_expected_exception_it_should_fail()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).Throws<InvalidCastException>());

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected*InvalidCastException*but*ArgumentNullException*").AsWildcard();
    }

    [Fact]
    public async Task When_function_does_not_throw_any_exception_it_should_fail()
    {
        // Arrange
        Func<int> f = () => 12;

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).Throws<InvalidCastException>().Because($"that's what I {"said"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected*InvalidCastException*that's what I said*but*not*any exception*").AsWildcard();
    }

    #endregion

    #region ThrowExactly

    [Fact]
    public async Task When_subject_is_null_when_an_exact_exception_should_be_thrown_it_should_throw()
    {
        // Arrange
        Func<int> act = null;

        // Act
        Func<Task> action = async () =>
        {
            await Expect.That(act).ThrowsExactly<ArgumentNullException>().Because($"because we want to test the failure {"message"}");
        };

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*because we want to test the failure message*it was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_function_throws_the_expected_exact_exception_it_should_succeed()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act / Assert
        await Expect.That(f).ThrowsExactly<ArgumentNullException>();
    }

    [Fact]
    public async Task When_function_throws_aggregate_exception_with_inner_exception_of_the_expected_exact_exception_it_should_fail()
    {
        // Arrange
        Func<int> f = () => throw new AggregateException(new ArgumentException());

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).ThrowsExactly<ArgumentException>());

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected*ArgumentException*but*AggregateException*").AsWildcard();
    }

    [Fact]
    public async Task When_function_throws_subclass_of_the_expected_exact_exception_it_should_fail()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).ThrowsExactly<ArgumentException>());

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected*ArgumentException*but*ArgumentNullException*").AsWildcard();
    }

    [Fact]
    public async Task When_function_does_not_throw_expected_exact_exception_it_should_fail()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).ThrowsExactly<InvalidCastException>());

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected*InvalidCastException*but*ArgumentNullException*").AsWildcard();
    }

    [Fact]
    public async Task When_function_does_not_throw_any_exception_when_expected_exact_it_should_fail()
    {
        // Arrange
        Func<int> f = () => 12;

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).ThrowsExactly<InvalidCastException>().Because($"that's what I {"said"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("Expected*InvalidCastException*that's what I said*but*not*any exception*").AsWildcard();
    }

    #endregion

    #region NotThrow

    [Fact]
    public async Task When_subject_is_null_when_an_exception_should_not_be_thrown_it_should_throw()
    {
        // Arrange
        Func<int> act = null;

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(act).DoesNotThrow().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*because we want to test the failure message*it was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_subject_is_null_when_a_generic_exception_should_not_be_thrown_it_should_throw()
    {
        // Arrange
        Func<int> act = null;

        // Act
        Func<Task> action = async () =>
        {
            await Expect.That(act).DoesNotThrow<ArgumentNullException>().Because($"because we want to test the failure {"message"}");
        };

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*because we want to test the failure message*it was <null>*").AsWildcard();
    }

    [Fact]
    public async Task When_function_does_not_throw_exception_and_that_was_expected_it_should_succeed_then_continue_assertion()
    {
        // Arrange
        Func<int> f = () => 12;

        // Act / Assert
        await Expect.That(f).DoesNotThrow().AndWhoseResult.IsEqualTo(12);
    }

    [Fact]
    public async Task When_function_throw_exception_and_that_was_not_expected_it_should_fail()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).DoesNotThrow().Because($"that's what he {"told me"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*no*exception*that's what he told me*but*ArgumentNullException*").AsWildcard();
    }

    #endregion

    #region NotThrow<T>

    [Fact]
    public async Task When_function_does_not_throw_at_all_when_some_particular_exception_was_not_expected_it_should_succeed_but_then_cannot_continue_assertion()
    {
        // Arrange
        Func<int> f = () => 12;

        // Act / Assert
        await Expect.That(f).DoesNotThrow<ArgumentException>();
    }

    [Fact]
    public async Task When_function_does_throw_exception_and_that_exception_was_not_expected_it_should_fail()
    {
        // Arrange
        Func<int> f = () => throw new InvalidOperationException("custom message");

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).DoesNotThrow<InvalidOperationException>().Because($"it was so {"fast"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>().WithMessage("*InvalidOperationException*because it was so fast*InvalidOperationException:*custom message*").AsWildcard();
    }

    [Fact]
    public async Task When_function_throw_one_exception_but_other_was_not_expected_it_should_succeed()
    {
        // Arrange
        Func<int> f = () => throw new ArgumentNullException();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(f).DoesNotThrow<InvalidOperationException>());

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    #endregion
}

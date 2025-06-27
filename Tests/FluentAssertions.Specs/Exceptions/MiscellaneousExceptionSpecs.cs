using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Exceptions;

public class MiscellaneousExceptionSpecs
{
    [Fact]
    public async Task When_getting_value_of_property_of_thrown_exception_it_should_return_value_of_property()
    {
        // Arrange
        const string SomeParamNameValue = "param";
        Does target = Does.Throw(new ExceptionWithProperties(SomeParamNameValue));

        // Act
        Action act = target.Do;

        // Assert
        await Expect.That(act).Throws<ExceptionWithProperties>().Whose(x => x.Property, it => it.IsEqualTo(SomeParamNameValue));
    }

    [Fact]
    public void When_validating_a_subject_against_multiple_conditions_it_should_support_chaining()
    {
        // Arrange
        Does testSubject = Does.Throw(new InvalidOperationException("message", new ArgumentException("inner message")));

        // Act / Assert
        testSubject
            .Invoking(x => x.Do())
            .Should().Throw<InvalidOperationException>()
            .WithInnerException<ArgumentException>()
            .WithMessage("inner message");
    }

    [Fact]
    public async Task When_a_yielding_enumerable_throws_an_expected_exception_it_should_not_throw()
    {
        // Act
        Func<IEnumerable<char>> act = () => MethodThatUsesYield("aaa!aaa");

        // Assert
        await That(act).Throws<Exception>();
    }

    private static IEnumerable<char> MethodThatUsesYield(string bar)
    {
        foreach (var character in bar)
        {
            if (character.Equals('!'))
            {
                throw new Exception("No exclamation marks allowed.");
            }

            yield return char.ToUpperInvariant(character);
        }
    }

    [Fact]
    public async Task When_a_2nd_condition_is_not_met_it_should_throw()
    {
        // Arrange
        Action act = () => throw new ArgumentException("Fail");

        try
        {
            // Act
            await Expect.That(act).Throws<ArgumentException>().WithMessage("Error");

            throw new InvalidOperationException("This point should not be reached");
        }
        catch (XunitException exc)
        {
            // Assert
            await Expect.That(exc.Message).StartsWith("Expected");
        }
    }

    [Fact]
    public async Task When_custom_condition_is_met_it_should_not_throw()
    {
        // Arrange / Act
        Action act = () => throw new ArgumentException("");

        // Assert
        await Expect.That(act).Throws<ArgumentException>();
    }

    [Fact]
    public async Task When_an_exception_of_a_different_type_is_thrown_it_should_include_the_type_of_the_thrown_exception()
    {
        // Arrange
        Action throwException = () => throw new ExceptionWithEmptyToString();

        // Act
        Action act =
            () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(throwException).Throws<ArgumentNullException>());

        // Assert
        await Expect.That(act).Throws<XunitException>().WithMessage($"*ArgumentNullException*{typeof(ExceptionWithEmptyToString)}*").AsWildcard();
    }

    [Fact]
    public async Task When_a_method_throws_with_a_matching_parameter_name_it_should_succeed()
    {
        // Arrange
        Action throwException = () => throw new ArgumentNullException("someParameter");

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(throwException).Throws<ArgumentException>());

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_a_method_throws_with_a_non_matching_parameter_name_it_should_fail_with_a_descriptive_message()
    {
        // Arrange
        Action throwException = () => throw new ArgumentNullException("someOtherParameter");

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(throwException).Throws<ArgumentException>().WithParamName("someParameter").Because("we want to test the failure message"));

        // Assert
        await Expect.That(act).Throws<XunitException>().WithMessage("*with ParamName \"someParameter\"*we want to test the failure message*\"someOtherParameter\"*").AsWildcard();
    }
}

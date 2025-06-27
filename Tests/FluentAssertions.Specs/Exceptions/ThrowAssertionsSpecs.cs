using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Exceptions;

public class ThrowAssertionsSpecs
{
    [Fact]
    public async Task When_subject_throws_expected_exception_it_should_not_do_anything()
    {
        // Arrange
        Does testSubject = Does.Throw<InvalidOperationException>();

        // Act / Assert
        await That(() => testSubject.Do()).Throws<InvalidOperationException>();
    }

    [Fact]
    public async Task When_func_throws_expected_exception_it_should_not_do_anything()
    {
        // Arrange
        Does testSubject = Does.Throw<InvalidOperationException>();

        // Act / Assert
        await That(() => testSubject.Return()).Throws<InvalidOperationException>();
    }

    [Fact]
    public async Task When_action_throws_expected_exception_it_should_not_do_anything()
    {
        // Arrange
        var act = new Action(() => throw new InvalidOperationException("Some exception"));

        // Act / Assert
        await That(act).Throws<InvalidOperationException>();
    }

    [Fact]
    public async Task When_subject_does_not_throw_exception_but_one_was_expected_it_should_throw_with_clear_description()
    {
        try
        {
            Does testSubject = Does.NotThrow();

            await That(() => testSubject.Do()).Throws<Exception>();

            throw new XunitException("Should().Throw() did not throw");
        }
        catch (XunitException ex)
        {
            await That(ex.Message).IsNotEqualTo("Should().Throw() did not throw");
        }
    }

    [Fact]
    public async Task When_func_does_not_throw_exception_but_one_was_expected_it_should_throw_with_clear_description()
    {
        try
        {
            Does testSubject = Does.NotThrow();

            await That(() => testSubject.Return()).Throws<Exception>();


            throw new XunitException("Should().Throw() did not throw");
        }
        catch (XunitException ex)
        {
            await That(ex.Message).IsNotEqualTo("Should().Throw() did not throw");
        }
    }

    [Fact]
    public async Task When_func_does_not_throw_it_should_be_chainable()
    {
        // Arrange
        Does testSubject = Does.NotThrow();

        var result = await That(() => testSubject.Return()).DoesNotThrow();
        await That(result).IsEqualTo(42);
    }
}

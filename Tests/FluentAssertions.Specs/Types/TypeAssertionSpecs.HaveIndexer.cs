using System;
using FluentAssertions.Common;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]HaveIndexer specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class HaveIndexer
    {
        [Fact]
        public async Task When_asserting_a_type_has_an_indexer_which_it_does_then_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should()
                    .HaveIndexer(typeof(string), [typeof(string)])
                    .Which.Should()
                    .BeWritable(CSharpAccessModifier.Internal)
                    .And.BeReadable(CSharpAccessModifier.Private);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_indexer_which_it_does_not_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithNoMembers);

            // Act
            Action act = () =>
                type.Should().HaveIndexer(
                    typeof(string), [typeof(int), typeof(Type)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected String *ClassWithNoMembers[System.Int32, System.Type] to exist *failure message*" +
                    ", but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_indexer_with_different_parameters_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveIndexer(
                    typeof(string), [typeof(int), typeof(Type)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_is_null_have_indexer_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveIndexer(typeof(string), [typeof(string)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_indexer_for_null_it_should_throw()
        {
            // Arrange
            Type type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveIndexer(null, [typeof(string)]);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_indexer_with_a_null_parameter_type_list_it_should_throw()
        {
            // Arrange
            Type type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveIndexer(typeof(string), null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class NotHaveIndexer
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_indexer_which_it_does_not_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithoutMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveIndexer([typeof(string)]);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_indexer_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveIndexer([typeof(string)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_is_null_not_have_indexer_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotHaveIndexer([typeof(string)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_indexer_for_null_it_should_throw()
        {
            // Arrange
            Type type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveIndexer(null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }
}

﻿using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]BeStatic specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class BeStatic
    {
        [Fact]
        public void When_type_is_static_it_succeeds()
        {
            // Arrange / Act / Assert
            typeof(Static).Should().BeStatic();
        }

        [Theory]
        [InlineData(typeof(ClassWithoutMembers), "Expected type *.ClassWithoutMembers to be static.")]
        [InlineData(typeof(Sealed), "Expected type *.Sealed to be static.")]
        [InlineData(typeof(Abstract), "Expected type *.Abstract to be static.")]
        public async Task When_type_is_not_static_it_fails(Type type, string exceptionMessage)
        {
            // Act
            Action act = () => type.Should().BeStatic();

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage(exceptionMessage).AsWildcard();
        }

        [Fact]
        public async Task When_type_is_not_static_it_fails_with_a_meaningful_message()
        {
            // Arrange
            var type = typeof(ClassWithoutMembers);

            // Act
            Action act = () => type.Should().BeStatic("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(typeof(IDummyInterface), "*.IDummyInterface must be a class.")]
        [InlineData(typeof(Struct), "*.Struct must be a class.")]
        [InlineData(typeof(ExampleDelegate), "*.ExampleDelegate must be a class.")]
        public async Task When_type_is_not_valid_for_BeStatic_it_throws_exception(Type type, string exceptionMessage)
        {
            // Act
            Action act = () => type.Should().BeStatic();

            // Assert
            await Expect.That(act).Throws<InvalidOperationException>().WithMessage(exceptionMessage).AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_be_static_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().BeStatic("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeStatic
    {
        [Theory]
        [InlineData(typeof(ClassWithoutMembers))]
        [InlineData(typeof(Sealed))]
        [InlineData(typeof(Abstract))]
        public void When_type_is_not_static_it_succeeds(Type type)
        {
            // Arrange / Act / Assert
            type.Should().NotBeStatic();
        }

        [Fact]
        public async Task When_type_is_static_it_fails()
        {
            // Arrange
            var type = typeof(Static);

            // Act
            Action act = () => type.Should().NotBeStatic();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_type_is_static_it_fails_with_a_meaningful_message()
        {
            // Arrange
            var type = typeof(Static);

            // Act
            Action act = () => type.Should().NotBeStatic("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(typeof(IDummyInterface), "*.IDummyInterface must be a class.")]
        [InlineData(typeof(Struct), "*.Struct must be a class.")]
        [InlineData(typeof(ExampleDelegate), "*.ExampleDelegate must be a class.")]
        public async Task When_type_is_not_valid_for_NotBeStatic_it_throws_exception(Type type, string exceptionMessage)
        {
            // Act
            Action act = () => type.Should().NotBeStatic();

            // Assert
            await Expect.That(act).Throws<InvalidOperationException>().WithMessage(exceptionMessage).AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_not_be_static_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotBeStatic("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}

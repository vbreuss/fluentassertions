﻿using System;
using FluentAssertions.Common;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]HaveConstructor specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class HaveConstructor
    {
        [Fact]
        public async Task When_asserting_a_type_has_a_constructor_which_it_does_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should()
                    .HaveConstructor([typeof(string)])
                    .Which.Should().HaveAccessModifier(CSharpAccessModifier.Private);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_constructor_which_it_does_not_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithNoMembers);

            // Act
            Action act = () =>
                type.Should().HaveConstructor([typeof(int), typeof(Type)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected constructor *ClassWithNoMembers(System.Int32, System.Type) to exist *failure message*" +
                    ", but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_have_constructor_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveConstructor([typeof(string)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_constructor_of_null_it_should_throw()
        {
            // Arrange
            Type type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveConstructor(null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class NotHaveConstructor
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_constructor_which_it_does_not_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithNoMembers);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveConstructor([typeof(string)]);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_constructor_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveConstructor([typeof(string)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_is_null_not_have_constructor_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotHaveConstructor([typeof(string)], "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_constructor_of_null_it_should_throw()
        {
            // Arrange
            Type type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveConstructor(null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }
}

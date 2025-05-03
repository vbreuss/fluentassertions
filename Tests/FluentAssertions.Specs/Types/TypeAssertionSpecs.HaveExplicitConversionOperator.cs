﻿using System;
using FluentAssertions.Common;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]HaveExplicitConversionOperator specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class HaveExplicitConversionOperator
    {
        [Fact]
        public void When_asserting_a_type_has_an_explicit_conversion_operator_which_it_does_it_succeeds()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);
            var sourceType = typeof(TypeWithConversionOperators);
            var targetType = typeof(byte);

            // Act / Assert
            type.Should()
                .HaveExplicitConversionOperator(sourceType, targetType)
                .Which.Should()
                .NotBeNull();
        }

        [Fact]
        public async Task Can_chain_an_additional_assertion_on_the_implicit_conversion_operator()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);
            var sourceType = typeof(TypeWithConversionOperators);
            var targetType = typeof(byte);

            // Act
            Action act = () => type
                .Should().HaveExplicitConversionOperator(sourceType, targetType)
                .Which.Should().HaveAccessModifier(CSharpAccessModifier.Private);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_conversion_operator_which_it_does_not_it_fails_with_a_useful_message()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);
            var sourceType = typeof(TypeWithConversionOperators);
            var targetType = typeof(string);

            // Act
            Action act = () =>
                type.Should().HaveExplicitConversionOperator(
                    sourceType, targetType, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected public static explicit System.String(*.TypeWithConversionOperators) to exist *failure message*" +
                    ", but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_have_explicit_conversion_operator_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveExplicitConversionOperator(
                    typeof(TypeWithConversionOperators), typeof(string), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected public static explicit System.String(*.TypeWithConversionOperators) to exist *failure message*" +
                    ", but type is <null>.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_conversion_operator_from_null_it_should_throw()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should().HaveExplicitConversionOperator(null, typeof(string));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_conversion_operator_to_null_it_should_throw()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should().HaveExplicitConversionOperator(typeof(TypeWithConversionOperators), null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class HaveExplicitConversionOperatorOfT
    {
        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_conversion_operatorOfT_which_it_does_it_succeeds()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should()
                    .HaveExplicitConversionOperator<TypeWithConversionOperators, byte>()
                    .Which.Should()
                    .NotBeNull();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_conversion_operatorOfT_which_it_does_not_it_fails()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should().HaveExplicitConversionOperator<TypeWithConversionOperators, string>(
                    "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected public static explicit System.String(*.TypeWithConversionOperators) to exist *failure message*" +
                    ", but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_have_explicit_conversion_operatorOfT_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveExplicitConversionOperator<TypeWithConversionOperators, string>(
                    "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected public static explicit System.String(*.TypeWithConversionOperators) to exist *failure message*" +
                    ", but type is <null>.").AsWildcard();
        }
    }

    public class NotHaveExplicitConversionOperator
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_conversion_operator_which_it_does_not_it_succeeds()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);
            var sourceType = typeof(TypeWithConversionOperators);
            var targetType = typeof(string);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitConversionOperator(sourceType, targetType);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_conversion_operator_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);
            var sourceType = typeof(TypeWithConversionOperators);
            var targetType = typeof(byte);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitConversionOperator(
                    sourceType, targetType, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected public static explicit *.Byte(*.TypeWithConversionOperators) to not exist *failure message*" +
                    ", but it does.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_not_have_explicit_conversion_operator_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitConversionOperator(
                    typeof(TypeWithConversionOperators), typeof(string), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected public static explicit *.String(*.TypeWithConversionOperators) to not exist *failure message*" +
                    ", but type is <null>.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_conversion_operator_from_null_it_should_throw()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitConversionOperator(null, typeof(string));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_conversion_operator_to_null_it_should_throw()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitConversionOperator(typeof(TypeWithConversionOperators), null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class NotHaveExplicitConversionOperatorOfT
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_conversion_operatorOfT_which_it_does_not_it_succeeds()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitConversionOperator<TypeWithConversionOperators, string>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_conversion_operatorOfT_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(TypeWithConversionOperators);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitConversionOperator<TypeWithConversionOperators, byte>(
                    "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected public static explicit *.Byte(*.TypeWithConversionOperators) to not exist *failure message*" +
                    ", but it does.").AsWildcard();
        }
    }
}

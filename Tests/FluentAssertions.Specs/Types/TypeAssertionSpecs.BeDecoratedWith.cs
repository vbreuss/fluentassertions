﻿using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]BeDecoratedWith specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class BeDecoratedWith
    {
        [Fact]
        public async Task When_type_is_decorated_with_expected_attribute_it_succeeds()
        {
            // Arrange
            Type typeWithAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithAttribute.Should().BeDecoratedWith<DummyClassAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_decorated_with_expected_attribute_it_should_allow_chaining()
        {
            // Arrange
            Type typeWithAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithAttribute.Should().BeDecoratedWith<DummyClassAttribute>()
                    .Which.IsEnabled.Should().BeTrue();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_not_decorated_with_expected_attribute_it_fails()
        {
            // Arrange
            Type typeWithoutAttribute = typeof(ClassWithoutAttribute);

            // Act
            Action act = () =>
                typeWithoutAttribute.Should().BeDecoratedWith<DummyClassAttribute>("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassWithoutAttribute to be decorated with *.DummyClassAttribute *failure message*" +
                    ", but the attribute was not found.").AsWildcard();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_BeDecoratedWith_it_should_throw()
        {
            // Arrange
            Type typeWithAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithAttribute.Should().BeDecoratedWith<DummyClassAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_type_is_decorated_with_expected_attribute_with_the_expected_properties_it_succeeds()
        {
            // Arrange
            Type typeWithAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithAttribute.Should()
                    .BeDecoratedWith<DummyClassAttribute>(a => a.Name == "Expected" && a.IsEnabled);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_decorated_with_expected_attribute_with_the_expected_properties_it_should_allow_chaining()
        {
            // Arrange
            Type typeWithAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithAttribute.Should()
                    .BeDecoratedWith<DummyClassAttribute>(a => a.Name == "Expected")
                    .Which.IsEnabled.Should().BeTrue();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_decorated_with_expected_attribute_that_has_an_unexpected_property_it_fails()
        {
            // Arrange
            Type typeWithAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithAttribute.Should()
                    .BeDecoratedWith<DummyClassAttribute>(a => a.Name == "Unexpected" && a.IsEnabled);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassWithAttribute to be decorated with *.DummyClassAttribute that matches " +
                    "(a.Name == \"Unexpected\")*a.IsEnabled, but no matching attribute was found.").AsWildcard();
        }
    }

    public class NotBeDecoratedWith
    {
        [Fact]
        public async Task When_type_is_not_decorated_with_unexpected_attribute_it_succeeds()
        {
            // Arrange
            Type typeWithoutAttribute = typeof(ClassWithoutAttribute);

            // Act
            Action act = () =>
                typeWithoutAttribute.Should().NotBeDecoratedWith<DummyClassAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_decorated_with_unexpected_attribute_it_fails()
        {
            // Arrange
            Type typeWithAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithAttribute.Should().NotBeDecoratedWith<DummyClassAttribute>("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassWithAttribute to not be decorated with *.DummyClassAttribute* *failure message*" +
                    ", but the attribute was found.").AsWildcard();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_NotBeDecoratedWith_it_should_throw()
        {
            // Arrange
            Type typeWithoutAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () => typeWithoutAttribute.Should()
                .NotBeDecoratedWith<DummyClassAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_type_is_not_decorated_with_unexpected_attribute_with_the_expected_properties_it_succeeds()
        {
            // Arrange
            Type typeWithoutAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithoutAttribute.Should()
                    .NotBeDecoratedWith<DummyClassAttribute>(a => a.Name == "Unexpected" && a.IsEnabled);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_not_decorated_with_expected_attribute_that_has_an_unexpected_property_it_fails()
        {
            // Arrange
            Type typeWithoutAttribute = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
                typeWithoutAttribute.Should()
                    .NotBeDecoratedWith<DummyClassAttribute>(a => a.Name == "Expected" && a.IsEnabled);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassWithAttribute to not be decorated with *.DummyClassAttribute that matches " +
                    "(a.Name == \"Expected\") * a.IsEnabled, but a matching attribute was found.").AsWildcard();
        }
    }
}

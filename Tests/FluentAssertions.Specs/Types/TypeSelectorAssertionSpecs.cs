﻿using System;
using DummyNamespace;
using DummyNamespace.InnerDummyNamespace;
using DummyNamespaceTwo;
using FluentAssertions.Types;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

public class TypeSelectorAssertionSpecs
{
    public class BeSealed
    {
        [Fact]
        public void When_all_types_are_sealed_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(Sealed)
            ]);

            // Act / Assert
            types.Should().BeSealed();
        }

        [Fact]
        public async Task When_any_type_is_not_sealed_it_fails_with_a_meaningful_message()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(Sealed),
                typeof(Abstract)
            ]);

            // Act
            Action act = () => types.Should().BeSealed("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeSealed
    {
        [Fact]
        public void When_all_types_are_not_sealed_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(Abstract)
            ]);

            // Act / Assert
            types.Should().NotBeSealed();
        }

        [Fact]
        public async Task When_any_type_is_sealed_it_fails_with_a_meaningful_message()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(Abstract),
                typeof(Sealed)
            ]);

            // Act
            Action act = () => types.Should().NotBeSealed("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class BeDecoratedWith
    {
        [Fact]
        public async Task When_asserting_a_selection_of_decorated_types_is_decorated_with_an_attribute_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().BeDecoratedWith<DummyClassAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_non_decorated_types_is_decorated_with_an_attribute_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithAttribute),
                typeof(ClassWithoutAttribute),
                typeof(OtherClassWithoutAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().BeDecoratedWith<DummyClassAttribute>("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to be decorated with *.DummyClassAttribute *failure message*" +
                    ", but the attribute was not found on the following types:" +
                    "*\"*.ClassWithoutAttribute*.OtherClassWithoutAttribute\".").AsWildcard();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_TypeSelector_BeDecoratedWith_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassWithAttribute));

            // Act
            Action act = () => types.Should()
                .BeDecoratedWith<DummyClassAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_types_with_unexpected_attribute_property_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithAttribute),
                typeof(ClassWithoutAttribute),
                typeof(OtherClassWithoutAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should()
                    .BeDecoratedWith<DummyClassAttribute>(
                        a => a.Name == "Expected" && a.IsEnabled, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to be decorated with *.DummyClassAttribute that matches " +
                    "(a.Name == \"Expected\") * a.IsEnabled *failure message*, but no matching attribute was found on " +
                    "the following types:*\"*.ClassWithoutAttribute*.OtherClassWithoutAttribute\".").AsWildcard();
        }
    }

    public class BeDecoratedWithOrInherit
    {
        [Fact]
        public async Task When_asserting_a_selection_of_decorated_types_inheriting_an_attribute_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithInheritedAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().BeDecoratedWithOrInherit<DummyClassAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_non_decorated_types_inheriting_an_attribute_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithAttribute),
                typeof(ClassWithoutAttribute),
                typeof(OtherClassWithoutAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().BeDecoratedWithOrInherit<DummyClassAttribute>("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to be decorated with or inherit *.DummyClassAttribute *failure message*" +
                    ", but the attribute was not found on the following types:" +
                    "*\"*.ClassWithoutAttribute*.OtherClassWithoutAttribute\".").AsWildcard();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_TypeSelector_BeDecoratedWithOrInherit_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassWithAttribute));

            // Act
            Action act = () => types.Should()
                .BeDecoratedWithOrInherit<DummyClassAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_types_with_some_inheriting_attributes_with_unexpected_attribute_property_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithAttribute),
                typeof(ClassWithInheritedAttribute),
                typeof(ClassWithoutAttribute),
                typeof(OtherClassWithoutAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should()
                    .BeDecoratedWithOrInherit<DummyClassAttribute>(
                        a => a.Name == "Expected" && a.IsEnabled, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to be decorated with or inherit *.DummyClassAttribute that matches " +
                    "(a.Name == \"Expected\")*a.IsEnabled *failure message*, but no matching attribute was found " +
                    "on the following types:*\"*.ClassWithoutAttribute*.OtherClassWithoutAttribute\".").AsWildcard();
        }
    }

    public class NotBeDecoratedWith
    {
        [Fact]
        public async Task When_asserting_a_selection_of_non_decorated_types_is_not_decorated_with_an_attribute_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithoutAttribute),
                typeof(OtherClassWithoutAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().NotBeDecoratedWith<DummyClassAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_decorated_types_is_not_decorated_with_an_attribute_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithoutAttribute),
                typeof(ClassWithAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().NotBeDecoratedWith<DummyClassAttribute>("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to not be decorated *.DummyClassAttribute *failure message*" +
                    ", but the attribute was found on the following types:*\"*.ClassWithAttribute\".").AsWildcard();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_TypeSelector_NotBeDecoratedWith_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassWithAttribute));

            // Act
            Action act = () => types.Should()
                .NotBeDecoratedWith<DummyClassAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_types_with_unexpected_attribute_and_unexpected_attribute_property_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithoutAttribute),
                typeof(ClassWithAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should()
                    .NotBeDecoratedWith<DummyClassAttribute>(
                        a => a.Name == "Expected" && a.IsEnabled, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to not be decorated with *.DummyClassAttribute that matches " +
                    "(a.Name == \"Expected\") * a.IsEnabled *failure message*, but a matching attribute was found " +
                    "on the following types:*\"*.ClassWithAttribute\".").AsWildcard();
        }
    }

    public class NotBeDecoratedWithOrInherit
    {
        [Fact]
        public async Task When_asserting_a_selection_of_non_decorated_types_does_not_inherit_an_attribute_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithoutAttribute),
                typeof(OtherClassWithoutAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().NotBeDecoratedWithOrInherit<DummyClassAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_decorated_types_does_not_inherit_an_attribute_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithoutAttribute),
                typeof(ClassWithInheritedAttribute)
            ]);

            // Act
            Action act = () =>
                types.Should().NotBeDecoratedWithOrInherit<DummyClassAttribute>("we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to not be decorated with or inherit *.DummyClassAttribute *failure message*" +
                    ", but the attribute was found on the following types:*\"*.ClassWithInheritedAttribute\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_selection_of_types_do_inherit_unexpected_attribute_with_the_expected_properties_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassWithInheritedAttribute));

            // Act
            Action act = () => types.Should()
                .NotBeDecoratedWithOrInherit<DummyClassAttribute>(
                    a => a.Name == "Expected" && a.IsEnabled, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to not be decorated with or inherit *.DummyClassAttribute that matches " +
                    "(a.Name == \"Expected\") * a.IsEnabled *failure message*, but a matching attribute was found " +
                    "on the following types:*\"*.ClassWithInheritedAttribute\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_selection_of_types_do_not_inherit_unexpected_attribute_with_the_expected_properties_it_succeeds()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassWithoutAttribute));

            // Act
            Action act = () => types.Should()
                .NotBeDecoratedWithOrInherit<DummyClassAttribute>(a => a.Name == "Expected" && a.IsEnabled);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_TypeSelector_NotBeDecoratedWithOrInherit_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassWithAttribute));

            // Act
            Action act = () => types.Should()
                .NotBeDecoratedWithOrInherit<DummyClassAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class BeInNamespace
    {
        [Fact]
        public async Task When_a_type_is_in_the_expected_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInDummyNamespace));

            // Act
            Action act = () => types.Should().BeInNamespace(nameof(DummyNamespace));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_not_in_the_expected_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassInDummyNamespace),
                typeof(ClassNotInDummyNamespace),
                typeof(OtherClassNotInDummyNamespace)
            ]);

            // Act
            Action act = () =>
                types.Should().BeInNamespace(nameof(DummyNamespace), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to be in namespace \"DummyNamespace\" *failure message*, but the following types " +
                    "are in a different namespace:*\"*.ClassNotInDummyNamespace*.OtherClassNotInDummyNamespace\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_type_is_in_the_expected_global_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInGlobalNamespace));

            // Act
            Action act = () => types.Should().BeInNamespace(null);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_in_the_global_namespace_is_not_in_the_expected_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInGlobalNamespace));

            // Act
            Action act = () => types.Should().BeInNamespace(nameof(DummyNamespace));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to be in namespace \"DummyNamespace\", but the following types " +
                    "are in a different namespace:*\"ClassInGlobalNamespace\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_type_is_not_in_the_expected_global_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassInDummyNamespace),
                typeof(ClassNotInDummyNamespace),
                typeof(OtherClassNotInDummyNamespace)
            ]);

            // Act
            Action act = () => types.Should().BeInNamespace(null);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all types to be in namespace <null>, but the following types are in a different namespace:" +
                    "*\"*.ClassInDummyNamespace*.ClassNotInDummyNamespace*.OtherClassNotInDummyNamespace\".").AsWildcard();
        }
    }

    public class NotBeInNamespace
    {
        [Fact]
        public async Task When_a_type_is_not_in_the_unexpected_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInDummyNamespace));

            // Act
            Action act = () =>
                types.Should().NotBeInNamespace($"{nameof(DummyNamespace)}.{nameof(DummyNamespace.InnerDummyNamespace)}");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_not_in_the_unexpected_parent_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInInnerDummyNamespace));

            // Act
            Action act = () => types.Should().NotBeInNamespace(nameof(DummyNamespace));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_in_the_unexpected_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassInDummyNamespace),
                typeof(ClassNotInDummyNamespace),
                typeof(OtherClassNotInDummyNamespace)
            ]);

            // Act
            Action act = () =>
                types.Should().NotBeInNamespace(nameof(DummyNamespace), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected no types to be in namespace \"DummyNamespace\" *failure message*" +
                    ", but the following types are in the namespace:*\"DummyNamespace.ClassInDummyNamespace\".").AsWildcard();
        }
    }

    public class BeUnderNamespace
    {
        [Fact]
        public async Task When_a_type_is_under_the_expected_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInDummyNamespace));

            // Act
            Action act = () => types.Should().BeUnderNamespace(nameof(DummyNamespace));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_under_the_expected_nested_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInInnerDummyNamespace));

            // Act
            Action act = () =>
                types.Should().BeUnderNamespace($"{nameof(DummyNamespace)}.{nameof(DummyNamespace.InnerDummyNamespace)}");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_under_the_expected_parent_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInInnerDummyNamespace));

            // Act
            Action act = () => types.Should().BeUnderNamespace(nameof(DummyNamespace));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_exactly_under_the_expected_global_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInGlobalNamespace));

            // Act
            Action act = () => types.Should().BeUnderNamespace(null);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_under_the_expected_global_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassInDummyNamespace),
                typeof(ClassNotInDummyNamespace),
                typeof(OtherClassNotInDummyNamespace)
            ]);

            // Act
            Action act = () => types.Should().BeUnderNamespace(null);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_only_shares_a_prefix_with_the_expected_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInDummyNamespaceTwo));

            // Act
            Action act = () =>
                types.Should().BeUnderNamespace(nameof(DummyNamespace), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected the namespaces of all types to start with \"DummyNamespace\" *failure message*" +
                    ", but the namespaces of the following types do not start with it:*\"*.ClassInDummyNamespaceTwo\".").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_selection_of_types_not_under_a_namespace_is_under_that_namespace_it_fails()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassInDummyNamespace),
                typeof(ClassInInnerDummyNamespace)
            ]);

            // Act
            Action act = () =>
                types.Should().BeUnderNamespace($"{nameof(DummyNamespace)}.{nameof(DummyNamespace.InnerDummyNamespace)}");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected the namespaces of all types to start with \"DummyNamespace.InnerDummyNamespace\"" +
                    ", but the namespaces of the following types do not start with it:*\"*.ClassInDummyNamespace\".").AsWildcard();
        }
    }

    public class NotBeUnderNamespace
    {
        [Fact]
        public async Task When_a_types_is_not_under_the_unexpected_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassInDummyNamespace),
                typeof(ClassNotInDummyNamespace),
                typeof(OtherClassNotInDummyNamespace)
            ]);

            // Act
            Action act = () =>
                types.Should().NotBeUnderNamespace($"{nameof(DummyNamespace)}.{nameof(DummyNamespace.InnerDummyNamespace)}");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_type_is_under_the_unexpected_namespace_it_shold_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInDummyNamespace));

            // Act
            Action act = () =>
                types.Should().NotBeUnderNamespace(nameof(DummyNamespace), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected the namespaces of all types to not start with \"DummyNamespace\" *failure message*" +
                    ", but the namespaces of the following types start with it:*\"*.ClassInDummyNamespace\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_type_is_under_the_unexpected_nested_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInInnerDummyNamespace));

            // Act
            Action act = () =>
                types.Should().NotBeUnderNamespace($"{nameof(DummyNamespace)}.{nameof(DummyNamespace.InnerDummyNamespace)}");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected the namespaces of all types to not start with \"DummyNamespace.InnerDummyNamespace\"" +
                    ", but the namespaces of the following types start with it:*\"*.ClassInInnerDummyNamespace\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_type_is_under_the_unexpected_parent_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInInnerDummyNamespace));

            // Act
            Action act = () => types.Should().NotBeUnderNamespace(nameof(DummyNamespace));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected the namespaces of all types to not start with \"DummyNamespace\"" +
                    ", but the namespaces of the following types start with it:*\"*.ClassInInnerDummyNamespace\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_type_is_under_the_unexpected_global_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInGlobalNamespace));

            // Act
            Action act = () => types.Should().NotBeUnderNamespace(null);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected the namespaces of all types to not start with <null>" +
                    ", but the namespaces of the following types start with it:*\"ClassInGlobalNamespace\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_type_is_under_the_unexpected_parent_global_namespace_it_should_throw()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassInDummyNamespace),
                typeof(ClassNotInDummyNamespace),
                typeof(OtherClassNotInDummyNamespace)
            ]);

            // Act
            Action act = () => types.Should().NotBeUnderNamespace(null);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected the namespaces of all types to not start with <null>, but the namespaces of the following types " +
                    "start with it:*\"*.ClassInDummyNamespace*.ClassNotInDummyNamespace*.OtherClassNotInDummyNamespace\".").AsWildcard();
        }

        [Fact]
        public async Task When_a_type_only_shares_a_prefix_with_the_unexpected_namespace_it_should_not_throw()
        {
            // Arrange
            var types = new TypeSelector(typeof(ClassInDummyNamespaceTwo));

            // Act
            Action act = () => types.Should().NotBeUnderNamespace(nameof(DummyNamespace));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }

    public class Miscellaneous
    {
        [Fact]
        public async Task When_accidentally_using_equals_it_should_throw_a_helpful_error()
        {
            // Arrange
            var types = new TypeSelector(
            [
                typeof(ClassWithAttribute)
            ]);

            // Act
            var action = () => types.Should().Equals(null);

            // Assert
            await Expect.That(action).Throws<NotSupportedException>();
        }
    }
}

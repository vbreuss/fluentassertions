﻿using System;
using FluentAssertions.Common;
using FluentAssertions.Types;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

public class MethodInfoSelectorAssertionSpecs
{
    public class BeVirtual
    {
        [Fact]
        public async Task When_asserting_methods_are_virtual_and_they_are_it_should_succeed()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsVirtual));

            // Act
            Action act = () =>
                methodSelector.Should().BeVirtual();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_methods_are_virtual_but_non_virtual_methods_are_found_it_should_throw()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonVirtualPublicMethods));

            // Act
            Action act = () =>
                methodSelector.Should().BeVirtual();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_methods_are_virtual_but_non_virtual_methods_are_found_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonVirtualPublicMethods));

            // Act
            Action act = () =>
                methodSelector.Should().BeVirtual("we want to test the error {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods" +
                    " to be virtual because we want to test the error message," +
                    " but the following methods are not virtual:*" +
                    "Void FluentAssertions*ClassWithNonVirtualPublicMethods.PublicDoNothing*" +
                    "Void FluentAssertions*ClassWithNonVirtualPublicMethods.InternalDoNothing*" +
                    "Void FluentAssertions*ClassWithNonVirtualPublicMethods.ProtectedDoNothing").AsWildcard();
        }
    }

    public class NotBeVirtual
    {
        [Fact]
        public async Task When_asserting_methods_are_not_virtual_and_they_are_not_it_should_succeed()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonVirtualPublicMethods));

            // Act
            Action act = () =>
                methodSelector.Should().NotBeVirtual();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_methods_are_not_virtual_but_virtual_methods_are_found_it_should_throw()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsVirtual));

            // Act
            Action act = () =>
                methodSelector.Should().NotBeVirtual();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_methods_are_not_virtual_but_virtual_methods_are_found_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsVirtual));

            // Act
            Action act = () =>
                methodSelector.Should().NotBeVirtual("we want to test the error {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods" +
                    " not to be virtual because we want to test the error message," +
                    " but the following methods are virtual" +
                    "*ClassWithAllMethodsVirtual.PublicVirtualDoNothing" +
                    "*ClassWithAllMethodsVirtual.InternalVirtualDoNothing" +
                    "*ClassWithAllMethodsVirtual.ProtectedVirtualDoNothing*").AsWildcard();
        }
    }

    public class BeDecoratedWith
    {
        [Fact]
        public async Task When_injecting_a_null_predicate_into_BeDecoratedWith_it_should_throw()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsDecoratedWithDummyAttribute));

            // Act
            Action act = () =>
                methodSelector.Should().BeDecoratedWith<DummyMethodAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_methods_are_decorated_with_attribute_and_they_are_it_should_succeed()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsDecoratedWithDummyAttribute));

            // Act
            Action act = () =>
                methodSelector.Should().BeDecoratedWith<DummyMethodAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_methods_are_decorated_with_attribute_but_they_are_not_it_should_throw()
        {
            // Arrange
            MethodInfoSelector methodSelector =
                new MethodInfoSelector(typeof(ClassWithMethodsThatAreNotDecoratedWithDummyAttribute))
                    .ThatArePublicOrInternal;

            // Act
            Action act = () =>
                methodSelector.Should().BeDecoratedWith<DummyMethodAttribute>();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_methods_are_decorated_with_attribute_but_they_are_not_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithMethodsThatAreNotDecoratedWithDummyAttribute));

            // Act
            Action act = () =>
                methodSelector.Should().BeDecoratedWith<DummyMethodAttribute>("because we want to test the error {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods to be decorated with" +
                    " FluentAssertions*DummyMethodAttribute because we want to test the error message," +
                    " but the following methods are not:*" +
                    "Void FluentAssertions*ClassWithMethodsThatAreNotDecoratedWithDummyAttribute.PublicDoNothing*" +
                    "Void FluentAssertions*ClassWithMethodsThatAreNotDecoratedWithDummyAttribute.ProtectedDoNothing*" +
                    "Void FluentAssertions*ClassWithMethodsThatAreNotDecoratedWithDummyAttribute.PrivateDoNothing").AsWildcard();
        }
    }

    public class NotBeDecoratedWith
    {
        [Fact]
        public async Task When_injecting_a_null_predicate_into_NotBeDecoratedWith_it_should_throw()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithMethodsThatAreNotDecoratedWithDummyAttribute));

            // Act
            Action act = () =>
                methodSelector.Should().NotBeDecoratedWith<DummyMethodAttribute>(isMatchingAttributePredicate: null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_methods_are_not_decorated_with_attribute_and_they_are_not_it_should_succeed()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithMethodsThatAreNotDecoratedWithDummyAttribute));

            // Act
            Action act = () =>
                methodSelector.Should().NotBeDecoratedWith<DummyMethodAttribute>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_methods_are_not_decorated_with_attribute_but_they_are_it_should_throw()
        {
            // Arrange
            MethodInfoSelector methodSelector =
                new MethodInfoSelector(typeof(ClassWithAllMethodsDecoratedWithDummyAttribute))
                    .ThatArePublicOrInternal;

            // Act
            Action act = () =>
                methodSelector.Should().NotBeDecoratedWith<DummyMethodAttribute>();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_methods_are_not_decorated_with_attribute_but_they_are_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsDecoratedWithDummyAttribute));

            // Act
            Action act = () => methodSelector.Should()
                    .NotBeDecoratedWith<DummyMethodAttribute>("because we want to test the error {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods to not be decorated*DummyMethodAttribute*because we want to test the error message" +
                    "*ClassWithAllMethodsDecoratedWithDummyAttribute.PublicDoNothing*" +
                    "*ClassWithAllMethodsDecoratedWithDummyAttribute.PublicDoNothingWithSameAttributeTwice*" +
                    "*ClassWithAllMethodsDecoratedWithDummyAttribute.ProtectedDoNothing*" +
                    "*ClassWithAllMethodsDecoratedWithDummyAttribute.PrivateDoNothing").AsWildcard();
        }
    }

    public class Be
    {
        [Fact]
        public async Task When_all_methods_have_specified_accessor_it_should_succeed()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithPublicMethods));

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(methodSelector).IsEqualTo(CSharpAccessModifier.Public));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_not_all_methods_have_specified_accessor_it_should_throw()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonPublicMethods));

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(methodSelector).IsEqualTo(CSharpAccessModifier.Public));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods to be Public" +
                    ", but the following methods are not:*" +
                    "Void FluentAssertions*ClassWithNonPublicMethods.PublicDoNothing*" +
                    "Void FluentAssertions*ClassWithNonPublicMethods.DoNothingWithParameter*" +
                    "Void FluentAssertions*ClassWithNonPublicMethods.DoNothingWithAnotherParameter").AsWildcard();
        }

        [Fact]
        public async Task When_not_all_methods_have_specified_accessor_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonPublicMethods));

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(methodSelector).IsEqualTo(CSharpAccessModifier.Public).Because($"we want to test the error {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods to be Public" +
                    " because we want to test the error message" +
                    ", but the following methods are not:*" +
                    "Void FluentAssertions*ClassWithNonPublicMethods.PublicDoNothing*" +
                    "Void FluentAssertions*ClassWithNonPublicMethods.DoNothingWithParameter*" +
                    "Void FluentAssertions*ClassWithNonPublicMethods.DoNothingWithAnotherParameter").AsWildcard();
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task When_all_methods_does_not_have_specified_accessor_it_should_succeed()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonPublicMethods));

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(methodSelector).IsNotEqualTo(CSharpAccessModifier.Public));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_any_method_have_specified_accessor_it_should_throw()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithPublicMethods));

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(methodSelector).IsNotEqualTo(CSharpAccessModifier.Public));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods to not be Public" +
                    ", but the following methods are:*" +
                    "Void FluentAssertions*ClassWithPublicMethods.PublicDoNothing*").AsWildcard();
        }

        [Fact]
        public async Task When_any_method_have_specified_accessor_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithPublicMethods));

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(methodSelector).IsNotEqualTo(CSharpAccessModifier.Public).Because($"we want to test the error {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods to not be Public" +
                    " because we want to test the error message" +
                    ", but the following methods are:*" +
                    "Void FluentAssertions*ClassWithPublicMethods.PublicDoNothing*").AsWildcard();
        }
    }

    public class BeAsync
    {
        [Fact]
        public async Task When_asserting_methods_are_async_and_they_are_then_it_succeeds()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsAsync));

            // Act
            Action act = () => methodSelector.Should().BeAsync();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_methods_are_async_but_non_async_methods_are_found_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonAsyncMethods));

            // Act
            Action act = () => methodSelector.Should().BeAsync("we want to test the error {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods" +
                    " to be async because we want to test the error message," +
                    " but the following methods are not:" + Environment.NewLine +
                    "Task FluentAssertions.Specs.Types.ClassWithNonAsyncMethods.PublicDoNothing" + Environment.NewLine +
                    "Task FluentAssertions.Specs.Types.ClassWithNonAsyncMethods.InternalDoNothing" + Environment.NewLine +
                    "Task FluentAssertions.Specs.Types.ClassWithNonAsyncMethods.ProtectedDoNothing").AsWildcard();
        }
    }

    public class NotBeAsync
    {
        [Fact]
        public async Task When_asserting_methods_are_not_async_and_they_are_not_then_it_succeeds()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithNonAsyncMethods));

            // Act
            Action act = () => methodSelector.Should().NotBeAsync();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_methods_are_not_async_but_async_methods_are_found_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var methodSelector = new MethodInfoSelector(typeof(ClassWithAllMethodsAsync));

            // Act
            Action act = () => methodSelector.Should().NotBeAsync("we want to test the error {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected all selected methods" +
                    " not to be async because we want to test the error message," +
                    " but the following methods are:" + Environment.NewLine +
                    "Task FluentAssertions.Specs.Types.ClassWithAllMethodsAsync.PublicAsyncDoNothing" + Environment.NewLine +
                    "Task FluentAssertions.Specs.Types.ClassWithAllMethodsAsync.InternalAsyncDoNothing" + Environment.NewLine +
                    "Task FluentAssertions.Specs.Types.ClassWithAllMethodsAsync.ProtectedAsyncDoNothing").AsWildcard();
        }
    }
}

﻿using System;
using System.Reflection;
using FluentAssertions.Common;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

public class MethodBaseAssertionSpecs
{
    public class Return
    {
        [Fact]
        public async Task When_asserting_an_int_method_returns_int_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().Return(typeof(int));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_int_method_returns_string_it_fails_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().Return(typeof(string), "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected the return type of method IntMethod to be System.String because we want to test the " +
                    "error message, but it is \"System.Int32\".").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_void_method_returns_string_it_fails_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("VoidMethod");

            // Act
            Action act = () =>
                methodInfo.Should().Return(typeof(string), "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected the return type of method VoidMethod to be System.String because we want to test the " +
                    "error message, but it is \"System.Void\".").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_return_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().Return(typeof(string), "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_method_return_type_is_null_it_should_throw()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().Return(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class NotReturn
    {
        [Fact]
        public async Task When_asserting_an_int_method_does_not_return_string_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotReturn(typeof(string));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_int_method_does_not_return_int_it_fails_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotReturn(typeof(int), "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected the return type of*IntMethod*not to be System.Int32*because we want to test the " +
                    "error message, but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_not_return_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().NotReturn(typeof(string), "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_method_return_type_is_not_null_it_should_throw()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotReturn(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class ReturnOfT
    {
        [Fact]
        public async Task When_asserting_an_int_method_returnsOfT_int_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().Return<int>();

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_int_method_returnsOfT_string_it_fails_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().Return<string>("we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected the return type of method IntMethod to be System.String because we want to test the " +
                    "error message, but it is \"System.Int32\".").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_returnOfT_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().Return<string>("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotReturnOfT
    {
        [Fact]
        public async Task When_asserting_an_int_method_does_not_returnsOfT_string_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotReturn<string>();

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_int_method_does_not_returnsOfT_int_it_fails_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotReturn<int>("we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected the return type of*IntMethod*not to be System.Int32*because we want to test the " +
                    "error message, but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_not_returnOfT_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().NotReturn<string>("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class ReturnVoid
    {
        [Fact]
        public async Task When_asserting_a_void_method_returns_void_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("VoidMethod");

            // Act
            Action act = () =>
                methodInfo.Should().ReturnVoid();

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_int_method_returns_void_it_fails_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().ReturnVoid("because we want to test the error message {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected the return type of method IntMethod to be void because we want to test the error message " +
                    "message, but it is \"System.Int32\".").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_return_void_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().ReturnVoid("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotReturnVoid
    {
        [Fact]
        public async Task When_asserting_an_int_method_does_not_return_void_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("IntMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotReturnVoid();

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_void_method_does_not_return_void_it_fails_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("VoidMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotReturnVoid("because we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_is_null_not_return_void_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().NotReturnVoid("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class HaveAccessModifier
    {
        [Fact]
        public async Task When_asserting_a_private_member_is_private_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateMethod");

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier(CSharpAccessModifier.Private);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_private_protected_member_is_private_protected_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateProtectedMethod");

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier(CSharpAccessModifier.PrivateProtected);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_private_member_is_protected_it_throws_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateMethod");

            // Act
            Action act = () =>
                methodInfo.Should()
                    .HaveAccessModifier(CSharpAccessModifier.Protected, "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected method TestClass.PrivateMethod to be Protected because we want to test the error message, but it is " +
                    "Private.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_protected_member_is_protected_it_succeeds()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("ProtectedSetProperty");

            MethodInfo setMethod = propertyInfo.SetMethod;

            // Act
            Action act = () =>
                setMethod.Should().HaveAccessModifier(CSharpAccessModifier.Protected);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_protected_member_is_public_it_throws_with_a_useful_message()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("ProtectedSetProperty");

            MethodInfo setMethod = propertyInfo.SetMethod;

            // Act
            Action act = () =>
                setMethod
                    .Should()
                    .HaveAccessModifier(CSharpAccessModifier.Public, "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected method TestClass.set_ProtectedSetProperty to be Public because we want to test the error message, but it" +
                    " is Protected.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_public_member_is_public_it_succeeds()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("PublicGetProperty");

            MethodInfo getMethod = propertyInfo.GetMethod;

            // Act
            Action act = () =>
                getMethod.Should().HaveAccessModifier(CSharpAccessModifier.Public);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_public_member_is_internal_it_throws_with_a_useful_message()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("PublicGetProperty");

            MethodInfo getMethod = propertyInfo.GetMethod;

            // Act
            Action act = () =>
                getMethod
                    .Should()
                    .HaveAccessModifier(CSharpAccessModifier.Internal, "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected method TestClass.get_PublicGetProperty to be Internal because we want to test the error message, but it" +
                    " is Public.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_an_internal_member_is_internal_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("InternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier(CSharpAccessModifier.Internal);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_internal_member_is_protectedInternal_it_throws_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("InternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier(CSharpAccessModifier.ProtectedInternal, "because we want to test the" +
                    " error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected method TestClass.InternalMethod to be ProtectedInternal because we want to test the error message, but" +
                    " it is Internal.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_protected_internal_member_is_protected_internal_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("ProtectedInternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier(CSharpAccessModifier.ProtectedInternal);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_protected_internal_member_is_private_it_throws_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("ProtectedInternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier(CSharpAccessModifier.Private, "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected method TestClass.ProtectedInternalMethod to be Private because we want to test the error message, but it is " +
                    "ProtectedInternal.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_have_access_modifier_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier(CSharpAccessModifier.Public, "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_method_has_access_modifier_with_an_invalid_enum_value_it_should_throw()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateMethod");

            // Act
            Action act = () =>
                methodInfo.Should().HaveAccessModifier((CSharpAccessModifier)int.MaxValue);

            // Assert
            await That(act).ThrowsExactly<ArgumentOutOfRangeException>();
        }
    }

    public class NotHaveAccessModifier
    {
        [Fact]
        public async Task When_asserting_a_private_member_is_not_protected_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier(CSharpAccessModifier.Protected);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_private_member_is_not_private_protected_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier(CSharpAccessModifier.PrivateProtected);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_private_member_is_not_private_it_throws_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateMethod");

            // Act
            Action act = () =>
                methodInfo.Should()
                    .NotHaveAccessModifier(CSharpAccessModifier.Private, "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_protected_member_is_not_internal_it_succeeds()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("ProtectedSetProperty");
            MethodInfo setMethod = propertyInfo.SetMethod;

            // Act
            Action act = () =>
                setMethod.Should().NotHaveAccessModifier(CSharpAccessModifier.Internal);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_protected_member_is_not_protected_it_throws_with_a_useful_message()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("ProtectedSetProperty");
            MethodInfo setMethod = propertyInfo.SetMethod;

            // Act
            Action act = () =>
                setMethod
                    .Should()
                    .NotHaveAccessModifier(CSharpAccessModifier.Protected, "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_public_member_is_not_private_it_succeeds()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("PublicGetProperty");
            MethodInfo getMethod = propertyInfo.GetMethod;

            // Act
            Action act = () =>
                getMethod.Should().NotHaveAccessModifier(CSharpAccessModifier.Private);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_private_protected_member_is_not_private_it_succeeds()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("PublicGetPrivateProtectedSet");
            MethodInfo setMethod = propertyInfo.SetMethod;

            // Act
            Action act = () =>
                setMethod.Should().NotHaveAccessModifier(CSharpAccessModifier.Private);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_public_member_is_not_public_it_throws_with_a_useful_message()
        {
            // Arrange
            PropertyInfo propertyInfo = typeof(TestClass).FindPropertyByName("PublicGetProperty");
            MethodInfo getMethod = propertyInfo.GetMethod;

            // Act
            Action act = () =>
                getMethod
                    .Should()
                    .NotHaveAccessModifier(CSharpAccessModifier.Public, "we want to test the error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_internal_member_is_not_protectedInternal_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("InternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier(CSharpAccessModifier.ProtectedInternal);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_internal_member_is_not_internal_it_throws_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("InternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier(CSharpAccessModifier.Internal, "because we want to test the" +
                    " error {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_protected_internal_member_is_not_public_it_succeeds()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("ProtectedInternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier(CSharpAccessModifier.Public);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_protected_internal_member_is_not_protected_internal_it_throws_with_a_useful_message()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("ProtectedInternalMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier(CSharpAccessModifier.ProtectedInternal, "we want to test the error {0}",
                    "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_is_not_null_have_access_modifier_should_fail()
        {
            // Arrange
            MethodInfo methodInfo = null;

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier(
                    CSharpAccessModifier.Public, "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_method_does_not_have_access_modifier_with_an_invalid_enum_value_it_should_throw()
        {
            // Arrange
            MethodInfo methodInfo = typeof(TestClass).GetParameterlessMethod("PrivateMethod");

            // Act
            Action act = () =>
                methodInfo.Should().NotHaveAccessModifier((CSharpAccessModifier)int.MaxValue);

            // Assert
            await That(act).ThrowsExactly<ArgumentOutOfRangeException>();
        }
    }
}

#region Internal classes used in unit tests

internal class TestClass
{
    public void VoidMethod() { }

    public int IntMethod() { return 0; }

    private void PrivateMethod() { }

    public string PublicGetProperty { get; private set; }

    protected string ProtectedSetProperty { private get; set; }

    public string PublicGetPrivateProtectedSet { get; private protected set; }

    internal string InternalMethod() { return null; }

    protected internal void ProtectedInternalMethod() { }

    private protected void PrivateProtectedMethod() { }
}

#endregion

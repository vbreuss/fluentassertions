using System;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public enum EnumULong : ulong
{
    Int64Max = long.MaxValue,
    UInt64LessOne = ulong.MaxValue - 1,
    UInt64Max = ulong.MaxValue
}

public enum EnumLong : long
{
    Int64Max = long.MaxValue,
    Int64LessOne = long.MaxValue - 1
}

public class EnumAssertionSpecs
{
    public class HaveFlag
    {
        [Fact]
        public async Task When_enum_has_the_expected_flag_it_should_succeed()
        {
            // Arrange
            TestEnum someObject = TestEnum.One | TestEnum.Two;

            // Act / Assert
            await Expect.That(someObject).HasFlag(TestEnum.One);
        }

        [Fact]
        public async Task When_null_enum_does_not_have_the_expected_flag_it_should_fail()
        {
            // Arrange
            TestEnum? someObject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).HasFlag(TestEnum.Three));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_enum_does_not_have_specified_flag_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            TestEnum someObject = TestEnum.One | TestEnum.Two;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).HasFlag(TestEnum.Three).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveFlag
    {
        [Fact]
        public async Task When_enum_does_not_have_the_unexpected_flag_it_should_succeed()
        {
            // Arrange
            TestEnum someObject = TestEnum.One | TestEnum.Two;

            // Act / Assert
            await Expect.That(someObject).DoesNotHaveFlag(TestEnum.Three);
        }

        [Fact]
        public async Task When_enum_does_have_specified_flag_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            TestEnum someObject = TestEnum.One | TestEnum.Two;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).DoesNotHaveFlag(TestEnum.Two).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_null_enum_does_not_have_the_expected_flag_it_should_not_fail()
        {
            // Arrange
            TestEnum? someObject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).DoesNotHaveFlag(TestEnum.Three));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }

    [Flags]
    public enum TestEnum
    {
        None = 0,
        One = 1,
        Two = 2,
        Three = 4
    }

    [Flags]
    public enum OtherEnum
    {
        Default,
        First,
        Second
    }

    public class Be
    {
        [Fact]
        public async Task When_enums_are_equal_it_should_succeed()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnum expected = MyEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(MyEnum.One, MyEnum.One)]
        public async Task When_nullable_enums_are_equal_it_should_succeed(MyEnum? subject, MyEnum? expected)
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_null_enum_and_an_enum_are_unequal_it_should_throw()
        {
            // Arrange
            MyEnum? subject = null;
            MyEnum expected = MyEnum.Two;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_enums_are_unequal_it_should_throw()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnum expected = MyEnum.Two;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(null, MyEnum.One)]
        [InlineData(MyEnum.One, null)]
        [InlineData(MyEnum.One, MyEnum.Two)]
        public async Task When_nullable_enums_are_equal_it_should_throw(MyEnum? subject, MyEnum? expected)
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task When_enums_are_unequal_it_should_succeed()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnum expected = MyEnum.Two;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_null_enum_and_an_enum_are_unequal_it_should_succeed()
        {
            // Arrange
            MyEnum? subject = null;
            MyEnum expected = MyEnum.Two;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Theory]
        [InlineData(null, MyEnum.One)]
        [InlineData(MyEnum.One, null)]
        [InlineData(MyEnum.One, MyEnum.Two)]
        public async Task When_nullable_enums_are_unequal_it_should_succeed(MyEnum? subject, MyEnum? expected)
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_enums_are_equal_it_should_throw()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnum expected = MyEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(MyEnum.One, MyEnum.One)]
        public async Task When_nullable_enums_are_unequal_it_should_throw(MyEnum? subject, MyEnum? expected)
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public enum MyEnum
    {
        One = 1,
        Two = 2
    }

    public class HaveValue
    {
        [Fact]
        public async Task When_enum_has_the_expected_value_it_should_succeed()
        {
            // Arrange
            TestEnum someObject = TestEnum.One;

            // Act / Assert
            await Expect.That(someObject).HasValue(1);
        }

        [Fact]
        public async Task When_null_enum_does_not_have_the_expected_value_it_should_fail()
        {
            // Arrange
            TestEnum? someObject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).HasValue(3));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_enum_does_not_have_specified_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            TestEnum someObject = TestEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).HasValue(3).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_enum_has_value_it_should_be_chainable()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotNull());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_enum_does_not_have_value_it_should_throw()
        {
            // Arrange
            MyEnum? subject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotNull().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveValue
    {
        [Fact]
        public async Task When_enum_does_not_have_the_unexpected_value_it_should_succeed()
        {
            // Arrange
            TestEnum someObject = TestEnum.One;

            // Act / Assert
            await Expect.That(someObject).DoesNotHaveValue(3);
        }

        [Fact]
        public async Task When_enum_does_have_specified_value_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            TestEnum someObject = TestEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).DoesNotHaveValue(1).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_null_enum_does_not_have_the_expected_value_it_should_not_fail()
        {
            // Arrange
            TestEnum? someObject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).DoesNotHaveValue(3));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_enum_does_not_have_value_it_should_succeed()
        {
            // Arrange
            MyEnum? subject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNull());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_enum_has_value_it_should_throw()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNull().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class HaveSameValueAs
    {
        [Fact]
        public async Task When_enums_have_equal_values_it_should_succeed()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherName expected = MyEnumOtherName.OtherOne;

            // Act
            Action act = () => subject.Should().HaveSameValueAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_enums_have_equal_values_it_should_succeed()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;
            MyEnumOtherName expected = MyEnumOtherName.OtherOne;

            // Act
            Action act = () => subject.Should().HaveSameValueAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_enums_have_equal_values_it_should_throw()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherName expected = MyEnumOtherName.OtherTwo;

            // Act
            Action act = () => subject.Should().HaveSameValueAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(null, MyEnumOtherName.OtherOne)]
        [InlineData(MyEnum.One, MyEnumOtherName.OtherTwo)]
        public async Task When_nullable_enums_have_equal_values_it_should_throw(MyEnum? subject, MyEnumOtherName expected)
        {
            // Act
            Action act = () => subject.Should().HaveSameValueAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveSameValueAs
    {
        [Fact]
        public async Task When_enum_have_unequal_values_it_should_succeed()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherName expected = MyEnumOtherName.OtherTwo;

            // Act
            Action act = () => subject.Should().NotHaveSameValueAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Theory]
        [InlineData(null, MyEnumOtherName.OtherOne)]
        [InlineData(MyEnum.One, MyEnumOtherName.OtherTwo)]
        public async Task When_nullable_enums_have_unequal_values_it_should_succeed(MyEnum? subject, MyEnumOtherName expected)
        {
            // Act
            Action act = () => subject.Should().NotHaveSameValueAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_enums_have_unequal_values_it_should_throw()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherName expected = MyEnumOtherName.OtherOne;

            // Act
            Action act = () => subject.Should().NotHaveSameValueAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_enums_have_unequal_values_it_should_throw()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;
            MyEnumOtherName expected = MyEnumOtherName.OtherOne;

            // Act
            Action act = () => subject.Should().NotHaveSameValueAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public enum MyEnumOtherName
    {
        OtherOne = 1,
        OtherTwo = 2
    }

    public class HaveSameNameAs
    {
        [Fact]
        public async Task When_enums_have_equal_names_it_should_succeed()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherValue expected = MyEnumOtherValue.One;

            // Act
            Action act = () => subject.Should().HaveSameNameAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_enums_have_equal_names_it_should_succeed()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;
            MyEnumOtherValue expected = MyEnumOtherValue.One;

            // Act
            Action act = () => subject.Should().HaveSameNameAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_enums_have_equal_names_it_should_throw()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherValue expected = MyEnumOtherValue.Two;

            // Act
            Action act = () => subject.Should().HaveSameNameAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(null, MyEnumOtherValue.One)]
        [InlineData(MyEnum.One, MyEnumOtherValue.Two)]
        public async Task When_nullable_enums_have_equal_names_it_should_throw(MyEnum? subject, MyEnumOtherValue expected)
        {
            // Act
            Action act = () => subject.Should().HaveSameNameAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveSameNameAs
    {
        [Fact]
        public async Task When_senum_have_unequal_names_it_should_succeed()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherValue expected = MyEnumOtherValue.Two;

            // Act
            Action act = () => subject.Should().NotHaveSameNameAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Theory]
        [InlineData(null, MyEnumOtherValue.One)]
        [InlineData(MyEnum.One, MyEnumOtherValue.Two)]
        public async Task When_nullable_enums_have_unequal_names_it_should_succeed(MyEnum? subject, MyEnumOtherValue expected)
        {
            // Act
            Action act = () => subject.Should().NotHaveSameNameAs(expected);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_enums_have_unequal_names_it_should_throw()
        {
            // Arrange
            MyEnum subject = MyEnum.One;
            MyEnumOtherValue expected = MyEnumOtherValue.One;

            // Act
            Action act = () => subject.Should().NotHaveSameNameAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_enums_have_unequal_names_it_should_throw()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;
            MyEnumOtherValue expected = MyEnumOtherValue.One;

            // Act
            Action act = () => subject.Should().NotHaveSameNameAs(expected, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public enum MyEnumOtherValue
    {
        One = 11,
        Two = 22
    }

    public class BeNull
    {
        [Fact]
        public async Task When_nullable_enum_is_null_it_should_succeed()
        {
            // Arrange
            MyEnum? subject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNull());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_enum_is_not_null_it_should_throw()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNull().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact]
        public async Task When_nullable_enum_is_not_null_it_should_be_chainable()
        {
            // Arrange
            MyEnum? subject = MyEnum.One;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotNull());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_enum_is_null_it_should_throw()
        {
            // Arrange
            MyEnum? subject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotNull().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class Match
    {
        [Fact]
        public void An_enum_matching_the_predicate_should_not_throw()
        {
            // Arrange
            BindingFlags flags = BindingFlags.Public;

            // Act / Assert
            flags.Should().Match(x => x == BindingFlags.Public);
        }

        [Fact]
        public async Task An_enum_not_matching_the_predicate_should_throw_with_the_predicate_in_the_message()
        {
            // Arrange
            BindingFlags flags = BindingFlags.Public;

            // Act
            Action act = () => flags.Should().Match(x => x == BindingFlags.Static, "that's what we need");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task An_enum_cannot_be_compared_with_a_null_predicate()
        {
            // Act
            Action act = () => BindingFlags.Public.Should().Match(null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }
    }

    public class BeOneOf
    {
        [Fact]
        public async Task An_enum_that_is_one_of_the_expected_values_should_not_throw()
        {
            // Arrange
            BindingFlags flags = BindingFlags.Public;

            // Act / Assert
            await Expect.That(flags).IsOneOf(BindingFlags.Public, BindingFlags.ExactBinding);
        }

        [Fact]
        public async Task Throws_when_the_enums_is_not_one_of_the_expected_enums()
        {
            // Arrange
            BindingFlags flags = BindingFlags.DeclaredOnly;

            // Act / Assert
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(flags).IsOneOf(BindingFlags.Public, BindingFlags.ExactBinding).Because("that's what we need"));

            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task An_enum_cannot_be_part_of_an_empty_list()
        {
            // Arrange
            BindingFlags flags = BindingFlags.DeclaredOnly;

            // Act / Assert
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(flags).IsOneOf());

            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class BeDefined
    {
        [Fact]
        public async Task A_valid_entry_of_an_enum_is_defined()
        {
            // Arrange
            var dayOfWeek = DayOfWeek.Monday;

            // Act / Assert
            await Expect.That(dayOfWeek).IsDefined();
        }

        [Fact]
        public async Task If_a_value_casted_to_an_enum_type_and_it_does_not_exist_in_the_enum_it_throws()
        {
            // Arrange
            var dayOfWeek = (DayOfWeek)999;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dayOfWeek).IsDefined().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_null_entry_of_an_enum_throws()
        {
            // Arrange
            MyEnum? subject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsDefined());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeDefined
    {
        [Fact]
        public async Task An_invalid_entry_of_an_enum_is_not_defined_passes()
        {
            // Arrange
            var dayOfWeek = (DayOfWeek)999;

            // Act / Assert
            await Expect.That(dayOfWeek).IsNotDefined();
        }

        [Fact]
        public async Task A_valid_entry_of_an_enum_is_not_defined_fails()
        {
            // Arrange
            var dayOfWeek = DayOfWeek.Monday;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dayOfWeek).IsNotDefined());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_null_value_of_an_enum_is_not_defined_and_throws()
        {
            // Arrange
            MyEnum? subject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotDefined());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class Miscellaneous
    {
        [Fact]
        public async Task Should_throw_a_helpful_error_when_accidentally_using_equals()
        {
            // Arrange
            MyEnum? subject = null;

            // Act
            var action = () => subject.Should().Equals(null);

            // Assert
            await Expect.That(action).Throws<NotSupportedException>();
        }
    }
}

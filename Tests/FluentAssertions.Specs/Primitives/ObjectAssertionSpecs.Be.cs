using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class Be
    {
        [Fact]
        public async Task When_two_equal_object_are_expected_to_be_equal_it_should_not_fail()
        {
            // Arrange
            var someObject = new ClassWithCustomEqualMethod(1);
            var equalObject = new ClassWithCustomEqualMethod(1);

            // Act / Assert
            await That(someObject).IsEqualTo(equalObject);
        }

        [Fact]
        public async Task When_two_different_objects_are_expected_to_be_equal_it_should_fail_with_a_clear_explanation()
        {
            // Arrange
            var someObject = new ClassWithCustomEqualMethod(1);
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            // Act
            Action act = () => Synchronously.Verify(That(someObject).IsEqualTo(nonEqualObject));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_both_subject_and_expected_are_null_it_should_succeed()
        {
            // Arrange
            object someObject = null;
            object expectedObject = null;

            // Act / Assert
            await That(someObject).IsEqualTo(expectedObject);
        }

        [Fact]
        public async Task When_the_subject_is_null_it_should_fail()
        {
            // Arrange
            object someObject = null;
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            // Act
            Action act = () => Synchronously.Verify(That(someObject).IsEqualTo(nonEqualObject));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_two_different_objects_are_expected_to_be_equal_it_should_fail_and_use_the_reason()
        {
            // Arrange
            var someObject = new ClassWithCustomEqualMethod(1);
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            // Act
            Action act = () => Synchronously.Verify(That(someObject).IsEqualTo(nonEqualObject).Because($"because it should use the {"reason"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_comparing_a_numeric_and_an_enum_for_equality_it_should_throw()
        {
            // Arrange
            object subject = 1;
            MyEnum expected = MyEnum.One;

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsEqualTo(expected));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task An_untyped_value_is_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            object value = new SomeClass(5);

            // Act / Assert
            await That(value).IsEqualTo(new SomeClass(5)).Using(new SomeClassEqualityComparer());
        }

        [Fact]
        public async Task A_typed_value_is_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            var value = new SomeClass(5);

            // Act / Assert
            await That(value).IsEqualTo(new SomeClass(5)).Using(new SomeClassEqualityComparer());
        }

        [Fact]
        public async Task An_untyped_value_is_not_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            object value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(new SomeClass(4)).Using(new SomeClassEqualityComparer()));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_typed_value_is_not_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            var value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(new SomeClass(4)).Using(new SomeClassEqualityComparer()));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_typed_value_is_not_of_the_same_type()
        {
            // Arrange
            var value = new ClassWithCustomEqualMethod(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(new SomeClass(3)).Using(new SomeClassEqualityComparer()));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Chaining_after_one_assertion()
        {
            // Arrange
            var value = new SomeClass(3);

            // Act / Assert
            await That(value).IsEqualTo(value);
        }

        [Fact]
        public async Task Can_chain_multiple_assertions()
        {
            // Arrange
            var value = new object();

            // Act / Assert
            await That(value).IsEqualTo(value).Using(new DumbObjectEqualityComparer());
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task When_non_equal_objects_are_expected_to_be_not_equal_it_should_not_fail()
        {
            // Arrange
            var someObject = new ClassWithCustomEqualMethod(1);
            var nonEqualObject = new ClassWithCustomEqualMethod(2);

            // Act / Assert
            await That(someObject).IsNotEqualTo(nonEqualObject);
        }

        [Fact]
        public async Task When_two_equal_objects_are_expected_not_to_be_equal_it_should_fail_with_a_clear_explanation()
        {
            // Arrange
            var someObject = new ClassWithCustomEqualMethod(1);
            var equalObject = new ClassWithCustomEqualMethod(1);

            // Act
            Action act = () =>
Synchronously.Verify(That(someObject).IsNotEqualTo(equalObject));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_two_equal_objects_are_expected_not_to_be_equal_it_should_fail_and_use_the_reason()
        {
            // Arrange
            var someObject = new ClassWithCustomEqualMethod(1);
            var equalObject = new ClassWithCustomEqualMethod(1);

            // Act
            Action act = () =>
Synchronously.Verify(That(someObject).IsNotEqualTo(equalObject).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task An_untyped_value_is_not_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            object value = new SomeClass(5);

            // Act / Assert
            await That(value).IsNotEqualTo(new SomeClass(4)).Using(new SomeClassEqualityComparer());
        }

        [Fact]
        public async Task A_typed_value_is_not_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            var value = new SomeClass(5);

            // Act / Assert
            await That(value).IsNotEqualTo(new SomeClass(4)).Using(new SomeClassEqualityComparer());
        }

        [Fact]
        public async Task An_untyped_value_is_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            object value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNotEqualTo(new SomeClass(3)).Using(new SomeClassEqualityComparer()));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_typed_value_is_equal_to_another_according_to_a_comparer()
        {
            // Arrange
            var value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNotEqualTo(new SomeClass(3)).Using(new SomeClassEqualityComparer()));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_typed_value_is_not_of_the_same_type()
        {
            // Arrange
            var value = new ClassWithCustomEqualMethod(3);

            // Act / Assert
            await That(value).IsNotEqualTo(new SomeClass(3)).Using(new SomeClassEqualityComparer());
        }

        [Fact]
        public async Task Chaining_after_one_assertion()
        {
            // Arrange
            var value = new SomeClass(3);

            // Act / Assert
            await That(value).IsNotEqualTo(new SomeClass(3));
        }

        [Fact]
        public async Task Can_chain_multiple_assertions()
        {
            // Arrange
            var value = new object();

            // Act / Assert
            await That(value).IsNotEqualTo(new object()).Using(new DumbObjectEqualityComparer());
        }
    }

    private enum MyEnum
    {
        One = 1,
        Two = 2
    }
}

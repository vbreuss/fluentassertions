using System;
using System.Xml.Linq;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Xml;

public class XAttributeAssertionSpecs
{
    public class Be
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_attribute_is_equal_to_the_same_xml_attribute_it_should_succeed()
        {
            // Arrange
            var attribute = new XAttribute("name", "value");
            var sameXAttribute = new XAttribute("name", "value");

            // Act
            Action act = () =>
Synchronously.Verify(That(attribute).IsEqualTo(sameXAttribute));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_attribute_is_equal_to_a_different_xml_attribute_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theAttribute = new XAttribute("name", "value");
            var otherAttribute = new XAttribute("name2", "value");

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsEqualTo(otherAttribute).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_both_subject_and_expected_are_null_it_succeeds()
        {
            XAttribute theAttribute = null;

            // Act
            Action act = () => Synchronously.Verify(That(theAttribute).IsEqualTo(null));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_the_expected_attribute_is_null_then_it_fails()
        {
            XAttribute theAttribute = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsEqualTo(new XAttribute("name", "value")).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_the_attribute_is_expected_to_equal_null_it_fails()
        {
            XAttribute theAttribute = new("name", "value");

            // Act
            Action act = () => Synchronously.Verify(That(theAttribute).IsEqualTo(null).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBe
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_attribute_is_not_equal_to_a_different_xml_attribute_it_should_succeed()
        {
            // Arrange
            var attribute = new XAttribute("name", "value");
            var otherXAttribute = new XAttribute("name2", "value");

            // Act
            Action act = () =>
Synchronously.Verify(That(attribute).IsNotEqualTo(otherXAttribute));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_attribute_is_not_equal_to_the_same_xml_attribute_it_should_throw()
        {
            // Arrange
            var theAttribute = new XAttribute("name", "value");
            var sameXAttribute = theAttribute;

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNotEqualTo(sameXAttribute));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_attribute_is_not_equal_to_the_same_xml_attribute_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var theAttribute = new XAttribute("name", "value");
            var sameAttribute = theAttribute;

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNotEqualTo(sameAttribute).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_attribute_is_not_supposed_to_be_an_attribute_it_succeeds()
        {
            // Arrange
            XAttribute theAttribute = null;

            // Act
            Action act = () => Synchronously.Verify(That(theAttribute).IsNotEqualTo(new XAttribute("name", "value")));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_an_attribute_is_not_supposed_to_be_null_it_succeeds()
        {
            // Arrange
            XAttribute theAttribute = new("name", "value");

            // Act
            Action act = () => Synchronously.Verify(That(theAttribute).IsNotEqualTo(null));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_attribute_is_not_supposed_to_be_null_it_fails()
        {
            // Arrange
            XAttribute theAttribute = null;

            // Act
            Action act = () => Synchronously.Verify(That(theAttribute).IsNotEqualTo(null).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeNull
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_attribute_is_null_it_should_succeed()
        {
            // Arrange
            XAttribute attribute = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(attribute).IsNull());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_non_null_xml_attribute_is_null_it_should_fail()
        {
            // Arrange
            var theAttribute = new XAttribute("name", "value");

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_non_null_xml_attribute_is_null_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theAttribute = new XAttribute("name", "value");

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_non_null_xml_attribute_is_not_null_it_should_succeed()
        {
            // Arrange
            var attribute = new XAttribute("name", "value");

            // Act
            Action act = () =>
Synchronously.Verify(That(attribute).IsNotNull());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_attribute_is_not_null_it_should_fail()
        {
            // Arrange
            XAttribute theAttribute = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNotNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_attribute_is_not_null_it_should_fail_with_descriptive_message()
        {
            // Arrange
            XAttribute theAttribute = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNotNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class HaveValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_attribute_has_a_specific_value_and_it_does_it_should_succeed()
        {
            // Arrange
            var attribute = new XAttribute("age", "36");

            // Act
            Action act = () =>
Synchronously.Verify(That(attribute).IsNotNull().Because("36"));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_attribute_has_a_specific_value_but_it_has_a_different_value_it_should_throw()
        {
            // Arrange
            var theAttribute = new XAttribute("age", "36");

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNotNull().Because("16"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_attribute_has_a_specific_value_but_it_has_a_different_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var theAttribute = new XAttribute("age", "36");

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNotNull().Because($"16"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_an_attribute_is_null_then_have_value_should_fail()
        {
            XAttribute theAttribute = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theAttribute).IsNotNull().Because($"value"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}

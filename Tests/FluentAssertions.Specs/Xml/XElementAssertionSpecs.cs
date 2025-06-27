﻿using System;
using System.Xml.Linq;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Xml;

public class XElementAssertionSpecs
{
    public class Be
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equal_to_the_same_xml_element_it_should_succeed()
        {
            // Arrange
            var theElement = new XElement("element");
            var sameElement = new XElement("element");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEqualTo(sameElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equal_to_a_different_xml_element_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = new XElement("element");
            var otherElement = new XElement("other");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEqualTo(otherElement).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equal_to_an_xml_element_with_a_deep_difference_it_should_fail()
        {
            // Arrange
            var theElement =
                new XElement("parent",
                    new XElement("child",
                        new XElement("grandChild2")));

            var expected =
                new XElement("parent",
                    new XElement("child",
                        new XElement("grandChild")));

            // Act
            Action act = () => Synchronously.Verify(That(theElement).IsEqualTo(expected));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_the_expected_element_is_null_it_fails()
        {
            // Arrange
            XElement theElement = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEqualTo(new XElement("other")).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_element_is_expected_to_equal_null_it_fails()
        {
            // Arrange
            XElement theElement = new("element");

            // Act
            Action act = () => Synchronously.Verify(That(theElement).IsEqualTo(null).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_both_subject_and_expected_are_null_it_succeeds()
        {
            // Arrange
            XElement theElement = null;

            // Act
            Action act = () => Synchronously.Verify(That(theElement).IsEqualTo(null));

            // Assert
            await That(act).DoesNotThrow();
        }
    }

    public class NotBe
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_not_equal_to_a_different_xml_element_it_should_succeed()
        {
            // Arrange
            var element = new XElement("element");
            var otherElement = new XElement("other");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsNotEqualTo(otherElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_deep_xml_element_is_not_equal_to_a_different_xml_element_it_should_succeed()
        {
            // Arrange
            var differentElement =
                new XElement("parent",
                    new XElement("child",
                        new XElement("grandChild")));

            var element =
                new XElement("parent",
                    new XElement("child",
                        new XElement("grandChild2")));

            // Act
            Action act = () => Synchronously.Verify(That(element).IsNotEqualTo(differentElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_not_equal_to_the_same_xml_element_it_should_fail()
        {
            // Arrange
            var theElement = new XElement("element");
            var sameElement = theElement;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotEqualTo(sameElement).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_an_element_is_not_supposed_to_be_null_it_succeeds()
        {
            // Arrange
            XElement theElement = new("element");

            // Act
            Action act = () => Synchronously.Verify(That(theElement).IsNotEqualTo(null));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_element_is_not_supposed_to_be_an_element_it_succeeds()
        {
            // Arrange
            XElement theElement = null;

            // Act
            Action act = () => Synchronously.Verify(That(theElement).IsNotEqualTo(new XElement("other")));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_element_is_not_supposed_to_be_null_it_fails()
        {
            // Arrange
            XElement theElement = null;

            // Act
            Action act = () => Synchronously.Verify(That(theElement).IsNotEqualTo(null).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeNull
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_null_and_it_is_it_should_succeed()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsNull());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_null_but_it_is_not_it_should_fail()
        {
            // Arrange
            var theElement = new XElement("element");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_null_but_it_is_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = new XElement("element");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_non_null_xml_element_is_not_null_it_should_succeed()
        {
            // Arrange
            var element = new XElement("element");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsNotNull());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_element_is_not_null_it_should_fail()
        {
            // Arrange
            XElement theElement = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_element_is_not_null_it_should_fail_with_descriptive_message()
        {
            // Arrange
            XElement theElement = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeEquivalentTo
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_equivalent_to_the_same_xml_element_it_should_succeed()
        {
            // Arrange
            var element = new XElement("element");
            var sameXElement = element;

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsEquivalentTo(sameXElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_equivalent_to_a_different_xml_element_with_same_structure_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse("<parent><child /></parent>");
            var otherXElement = XElement.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsEquivalentTo(otherXElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_empty_xml_element_is_equivalent_to_a_different_selfclosing_xml_element_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse("<parent><child></child></parent>");
            var otherElement = XElement.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsEquivalentTo(otherElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_selfclosing_xml_element_is_equivalent_to_a_different_empty_xml_element_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse("<parent><child /></parent>");
            var otherElement = XElement.Parse("<parent><child></child></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsEquivalentTo(otherElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_equivalent_to_a_xml_element_with_elements_missing_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /><child2 /></parent>");
            var otherXElement = XElement.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(otherXElement));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_equivalent_to_a_different_xml_element_with_extra_elements_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /></parent>");
            var otherXElement = XElement.Parse("<parent><child /><child2 /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(otherXElement));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_equivalent_to_a_different_xml_element_elements_missing_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /><child2 /></parent>");
            var otherXElement = XElement.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(otherXElement).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_equivalent_to_a_different_xml_element_with_extra_elements_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /></parent>");
            var otherXElement = XElement.Parse("<parent><child /><child2 /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(otherXElement).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_empty_xml_element_is_equivalent_to_a_different_xml_element_with_text_content_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /></parent>");
            var otherXElement = XElement.Parse("<parent><child>text</child></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(otherXElement).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_an_element_is_null_then_be_equivalent_to_an_element_fails()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(new XElement("element")).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_a_different_xml_element_with_different_namespace_prefix_it_should_succeed()
        {
            // Arrange
            var subject = XElement.Parse("<xml xmlns=\"urn:a\"/>");
            var expected = XElement.Parse("<a:xml xmlns:a=\"urn:a\"/>");

            // Act
            Action act = () =>
Synchronously.Verify(That(subject).IsEquivalentTo(expected));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_a_different_xml_element_which_differs_only_on_unused_namespace_declaration_it_should_succeed()
        {
            // Arrange
            var subject = XElement.Parse("<xml xmlns:a=\"urn:a\"/>");
            var expected = XElement.Parse("<xml/>");

            // Act
            Action act = () =>
Synchronously.Verify(That(subject).IsEquivalentTo(expected));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_different_xml_element_which_lacks_attributes_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<xml><element b=\"1\"/></xml>");
            var expected = XElement.Parse("<xml><element a=\"b\" b=\"1\"/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_different_xml_element_which_has_extra_attributes_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<xml><element a=\"b\"/></xml>");
            var expected = XElement.Parse("<xml><element/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_different_xml_element_which_has_different_attribute_values_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<xml><element a=\"b\"/></xml>");
            var expected = XElement.Parse("<xml><element a=\"c\"/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_different_xml_element_which_has_attribute_with_different_namespace_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<xml><element xmlns:ns=\"urn:a\" ns:a=\"b\"/></xml>");
            var expected = XElement.Parse("<xml><element a=\"b\"/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_different_xml_element_which_has_different_text_contents_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<xml>a</xml>");
            var expected = XElement.Parse("<xml>b</xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_element_is_equivalent_to_different_xml_element_with_different_comments_it_should_succeed()
        {
            // Arrange
            var subject = XElement.Parse("<xml><!--Comment--><a/></xml>");
            var expected = XElement.Parse("<xml><a/><!--Comment--></xml>");

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsEquivalentTo(expected));

            // Assert
            await That(act).DoesNotThrow();
        }
    }

    public class NotBeEquivalentTo
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_a_different_xml_element_with_elements_missing_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse("<parent><child /><child2 /></parent>");
            var otherXElement = XElement.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsNotEquivalentTo(otherXElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_a_different_xml_element_with_extra_elements_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse("<parent><child /></parent>");
            var otherXElement = XElement.Parse("<parent><child /><child2 /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsNotEquivalentTo(otherXElement));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_a_different_xml_element_with_same_structure_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /></parent>");
            var otherXElement = XElement.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotEquivalentTo(otherXElement));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_a_different_xml_element_with_same_contents_but_different_ns_prefixes_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("""<parent xmlns:ns1="a"><ns1:child /></parent>""");
            var otherXElement = XElement.Parse("""<parent xmlns:ns2="a"><ns2:child /></parent>""");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotEquivalentTo(otherXElement));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_a_different_xml_element_with_same_contents_but_extra_unused_xmlns_declaration_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse(@"<xml xmlns:ns1=""a"" />");
            var otherXElement = XElement.Parse("<xml />");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotEquivalentTo(otherXElement));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_the_same_xml_element_it_should_fail()
        {
            // Arrange
            var theElement = new XElement("element");
            var sameXElement = theElement;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotEquivalentTo(sameXElement));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_a_different_xml_element_with_same_structure_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /></parent>");
            var otherXElement = XElement.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotEquivalentTo(otherXElement).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_element_is_not_equivalent_to_the_same_xml_element_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<parent><child /></parent>");
            var sameXElement = theElement;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotEquivalentTo(sameXElement).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_element_is_not_equivalent_to_an_element_it_succeeds()
        {
            XElement theElement = null;

            // Act
            Action act = () => Synchronously.Verify(That(theElement).IsNotEquivalentTo(new XElement("element")));

            // Assert
            await That(act).DoesNotThrow();
        }
    }

    public class HaveValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_a_specific_value_and_it_does_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse("<user>grega</user>");

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsNotNull().Because("grega"));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_a_specific_value_but_it_has_a_different_value_it_should_throw()
        {
            // Arrange
            var theElement = XElement.Parse("<user>grega</user>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotNull().Because("stamac"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_a_specific_value_but_it_has_a_different_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("<user>grega</user>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotNull().Because($"stamac"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_xml_element_is_null_then_have_value_should_fail()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theElement).IsNotNull().Because($"value"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class HaveAttribute
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_found()
        {
            // Arrange
            var element = XElement.Parse(@"<user name=""martin"" />");

            // Act / Assert
            element.Should().HaveAttribute("name");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_found_with_namespace()
        {
            // Arrange
            var element = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act / Assert
            element.Should().HaveAttribute(XName.Get("name", "http://www.example.com/2012/test"));
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_attribute_is_not_found()
        {
            // Arrange
            var theElement = XElement.Parse("""<user name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute("age", "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_attribute_is_not_found_with_namespace()
        {
            // Arrange
            var theElement = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute(XName.Get("age", "http://www.example.com/2012/test"),
                    "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have attribute \"{http://www.example.com/2012/test}age\""
                + "*failure message*but found no such attribute in <user xmlns:a=\"http://www.example.com/2012/test\" a:name=\"martin\" />*").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_xml_element_is_null()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute("name", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"name\" in element *failure message*" +
                    ", but theElement is <null>.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_xml_element_is_null_with_namespace()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute((XName)"name", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"name\" in element*failure message*" +
                    ", but theElement is <null>.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expectation_is_null()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expectation_is_null_with_namespace()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute((XName)null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expectation_is_empty()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class NotHaveAttribute
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_not_found()
        {
            // Arrange
            var element = XElement.Parse(@"<user name=""martin"" />");

            // Act / Assert
            element.Should().NotHaveAttribute("surname");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_not_found_with_namespace()
        {
            // Arrange
            var element = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act / Assert
            element.Should().NotHaveAttribute(XName.Get("surname", "http://www.example.com/2012/test"));
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_attribute_is_found()
        {
            // Arrange
            var theElement = XElement.Parse("""<user name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttribute("name", "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_attribute_is_found_with_namespace()
        {
            // Arrange
            var theElement = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttribute(XName.Get("name", "http://www.example.com/2012/test"),
                    "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Did not expect theElement to have attribute \"{http://www.example.com/2012/test}name\""
                + "*failure message*but found such attribute in <user xmlns:a=\"http://www.example.com/2012/test\" a:name=\"martin\" />*").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_xml_element_is_null()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttribute("name", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Did not expect attribute \"name\" in element *failure message*" +
                    ", but theElement is <null>.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_xml_element_is_null_with_namespace()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttribute((XName)"name", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Did not expect attribute \"name\" in element*failure message*" +
                    ", but theElement is <null>.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expectation_is_null()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttribute(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expectation_is_null_with_namespace()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttribute((XName)null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expectation_is_empty()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttribute(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class HaveAttributeWithValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_specific_value_and_it_does_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse(@"<user name=""martin"" />");

            // Act
            Action act = () =>
                element.Should().HaveAttributeWithValue("name", "martin");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_ns_and_specific_value_and_it_does_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                element.Should().HaveAttributeWithValue(XName.Get("name", "http://www.example.com/2012/test"), "martin");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_specific_value_but_attribute_does_not_exist_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("""<user name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue("age", "36");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_ns_and_specific_value_but_attribute_does_not_exist_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue(XName.Get("age", "http://www.example.com/2012/test"), "36");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have attribute \"{http://www.example.com/2012/test}age\" with value \"36\","
                + " but found no such attribute in <user xmlns:a=\"http://www.example.com/2012/test\" a:name=\"martin\" />").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_specific_value_but_attribute_does_not_exist_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("""<user name="martin" />""");

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                theElement.Should().HaveAttributeWithValue("age", "36", "because we want to test the failure {0}", "message");
            };

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have attribute \"age\" with value \"36\" because we want to test the failure message,"
                + " but found no such attribute in <user name=\"martin\" />").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_ns_and_specific_value_but_attribute_does_not_exist_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue(XName.Get("age", "http://www.example.com/2012/test"), "36",
                    "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have attribute \"{http://www.example.com/2012/test}age\" with value \"36\""
                + " because we want to test the failure message,"
                + " but found no such attribute in <user xmlns:a=\"http://www.example.com/2012/test\" a:name=\"martin\" />").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_specific_value_but_attribute_has_different_value_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("""<user name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue("name", "dennis");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_ns_and_specific_value_but_attribute_has_different_value_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue(XName.Get("name", "http://www.example.com/2012/test"), "dennis");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_specific_value_but_attribute_has_different_value_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("""<user name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should()
                    .HaveAttributeWithValue("name", "dennis", "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"name\" in theElement to have value \"dennis\""
                + " because we want to test the failure message, but found \"martin\".").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_attribute_with_ns_and_specific_value_but_attribute_has_different_value_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue(XName.Get("name", "http://www.example.com/2012/test"), "dennis",
                    "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"{http://www.example.com/2012/test}name\" in theElement to have value \"dennis\""
                + " because we want to test the failure message, but found \"martin\".").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_xml_element_is_null_then_have_attribute_should_fail()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue("name", "value", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"name\" in element to have value \"value\" *failure message*" +
                    ", but theElement is <null>.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_xml_element_is_null_then_have_attribute_with_XName_should_fail()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue((XName)"name", "value", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"name\" in element to have value \"value\" *failure message*" +
                    ", but theElement is <null>.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_an_attribute_with_a_null_name_it_should_throw()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue(null, "value");

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_an_attribute_with_a_null_XName_it_should_throw()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue((XName)null, "value");

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_an_attribute_with_an_empty_name_it_should_throw()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithValue(string.Empty, "value");

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class NotHaveAttributeWithValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_does_not_fit()
        {
            // Arrange
            var element = XElement.Parse(@"<user name=""martin"" />");

            // Act / Assert
            element.Should().NotHaveAttributeWithValue("surname", "martin");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_does_not_fit_with_namespace()
        {
            // Arrange
            var element = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act / Assert
            element.Should().NotHaveAttributeWithValue(XName.Get("surname", "http://www.example.com/2012/test"), "martin");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_and_value_does_not_fit()
        {
            // Arrange
            var element = XElement.Parse(@"<user name=""martin"" />");

            // Act / Assert
            element.Should().NotHaveAttributeWithValue("surname", "mike");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_and_value_does_not_fit_with_namespace()
        {
            // Arrange
            var element = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act / Assert
            element.Should().NotHaveAttributeWithValue(XName.Get("surname", "http://www.example.com/2012/test"), "mike");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_fits_and_value_does_not()
        {
            // Arrange
            var element = XElement.Parse(@"<user name=""martin"" />");

            // Act / Assert
            element.Should().NotHaveAttributeWithValue("name", "mike");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_attribute_fits_and_value_does_not_with_namespace()
        {
            // Arrange
            var element = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act / Assert
            element.Should().NotHaveAttributeWithValue(XName.Get("name", "http://www.example.com/2012/test"), "mike");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_attribute_and_name_fits()
        {
            // Arrange
            var theElement = XElement.Parse("""<user name="martin" />""");

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();

                theElement.Should()
                    .NotHaveAttributeWithValue("name", "martin", "because we want to test the failure {0}", "message");
            };

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Did not expect theElement to have attribute \"name\" with value \"martin\" because we want to test the failure message,"
                + " but found such attribute in <user name=\"martin\" />*").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_attribute_and_name_fits_with_namespace()
        {
            // Arrange
            var theElement = XElement.Parse("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttributeWithValue(XName.Get("name", "http://www.example.com/2012/test"), "martin",
                    "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Did not expect theElement to have attribute \"{http://www.example.com/2012/test}name\" with value \"martin\""
                + " because we want to test the failure message,"
                + " but found such attribute in <user xmlns:a=\"http://www.example.com/2012/test\" a:name=\"martin\" />*").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_is_null()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttributeWithValue("name", "value", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_is_null_with_namespace()
        {
            XElement theElement = null;

            // Act
            Action act = () =>
                theElement.Should()
                    .NotHaveAttributeWithValue((XName)"name", "value", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_is_null()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttributeWithValue(null, "value");

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_is_null_with_namespace()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttributeWithValue((XName)null, "value");

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_attribute_is_something_but_value_is_null()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttributeWithValue("some", null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_attribute_is_something_but_value_is_null_with_namespace()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttributeWithValue((XName)"some", null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_is_empty()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().NotHaveAttributeWithValue(string.Empty, "value");

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class HaveElement
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_child_element_and_it_does_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                element.Should().HaveElement("child");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_child_element_with_ns_and_it_does_it_should_succeed()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent xmlns:c='http://www.example.com/2012/test'>
                    <c:child />
                </parent>
                """);

            // Act
            Action act = () =>
                element.Should().HaveElement(XName.Get("child", "http://www.example.com/2012/test"));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_child_element_but_it_does_not_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theElement.Should().HaveElement("unknown");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_child_element_with_ns_but_it_does_not_it_should_fail()
        {
            // Arrange
            var theElement = XElement.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theElement.Should().HaveElement(XName.Get("unknown", "http://www.example.com/2012/test"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_child_element_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theElement.Should().HaveElement("unknown", "because we want to test the failure message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have child element \"unknown\" because we want to test the failure message,"
                + " but no such child element was found.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_child_element_with_ns_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theElement = XElement.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theElement.Should().HaveElement(XName.Get("unknown", "http://www.example.com/2012/test"),
                    "because we want to test the failure message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have child element \"{{http://www.example.com/2012/test}}unknown\""
                + " because we want to test the failure message, but no such child element was found.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_child_element_it_should_return_the_matched_element_in_the_which_property()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child attr='1' />
                </parent>
                """);

            // Act
            var matchedElement = element.Should().HaveElement("child").Subject;

            // Assert
            await That(matchedElement).IsExactly<XElement>();

            await That(matchedElement.Name).IsEqualTo(XName.Get("child"));
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_a_child_element_with_a_null_name_it_should_throw()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveElement(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_a_child_element_with_a_null_XName_it_should_throw()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveElement((XName)null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_element_has_a_child_element_with_an_empty_name_it_should_throw()
        {
            XElement theElement = new("element");

            // Act
            Action act = () =>
                theElement.Should().HaveElement(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class HaveElementWithOccurrence
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Element_has_two_child_elements_and_it_expected_does_it_succeeds()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child />
                    <child />
                </parent>
                """);

            // Act / Assert
            element.Should().HaveElement("child", Exactly.Twice());
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Asserting_element_inside_an_assertion_scope_it_checks_the_whole_assertion_scope_before_failing()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () =>
            {
                using (new AssertionScope())
                {
                    element.Should().HaveElement("child", Exactly.Twice());
                    element.Should().HaveElement("child", Exactly.Twice());
                }
            };

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Element_has_two_child_elements_and_three_expected_it_fails()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElement("child", Exactly.Twice());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Element_is_valid_and_expected_null_with_string_overload_it_fails()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElement(null, Exactly.Twice());

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Element_is_valid_and_expected_null_with_x_name_overload_it_fails()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElement((XName)null, Exactly.Twice());

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Chaining_after_a_successful_occurrence_check_does_continue_the_assertion()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act / Assert
            element.Should().HaveElement("child", AtLeast.Twice())
                .Which.Should().NotBeNull();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Chaining_after_a_non_successful_occurrence_check_does_not_continue_the_assertion()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElement("child", Exactly.Once())
                .Which.Should().NotBeNull();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Null_element_is_expected_to_have_an_element_count_it_should_fail()
        {
            // Arrange
            XElement xElement = null;

            // Act
            Action act = () => xElement.Should().HaveElement("child", AtLeast.Once());

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class HaveElementWithValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_element_cannot_be_null()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () => element.Should().HaveElementWithValue("child", "b");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Has_element_with_specified_value()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().HaveElementWithValue("child", "b");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_is_not_found()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElementWithValue("c", "f");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_found_but_value_does_not_match()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElementWithValue("child", "c");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_element_is_null()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElementWithValue(null, "a");

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_element_is_null_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElementWithValue((XName)null, "a");

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_value_is_null()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElementWithValue("child", null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_value_is_null_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElementWithValue(XNamespace.None + "child", null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_element_cannot_be_null_and_searching_with_namespace()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () =>
                element.Should()
                    .HaveElementWithValue(XNamespace.None + "child", "b", "we want to test the {0} message", "failure");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Has_element_with_specified_value_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().HaveElementWithValue(XNamespace.None + "child", "b");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_with_namespace_not_found()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                element.Should().HaveElementWithValue(XNamespace.None + "c", "f");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_with_namespace_found_but_value_does_not_match()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().HaveElementWithValue(XNamespace.None + "child", "c");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveElement
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_element_cannot_be_null()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () => element.Should().NotHaveElement("child");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Element_does_not_have_this_child_element()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().NotHaveElement("c");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_found_but_expected_to_be_absent()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElement("child");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_unexpected_element_is_null()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElement(null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_unexpected_element_is_null_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElement((XName)null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_element_cannot_be_null_and_searching_with_namespace()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () =>
                element.Should()
                    .NotHaveElement(XNamespace.None + "child", "we want to test the {0} message", "failure");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Not_have_element_with_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().NotHaveElement(XNamespace.None + "c");
        }
    }

    public class NotHaveElementWithValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_element_cannot_be_null()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () => element.Should().NotHaveElementWithValue("child", "b");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_with_specified_value_is_found()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElementWithValue("child", "b");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_element_not_found()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().NotHaveElementWithValue("c", "f");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_element_found_but_value_does_not_match()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().NotHaveElementWithValue("child", "c");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_element_is_null()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElementWithValue(null, "a");

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_element_is_null_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElementWithValue((XName)null, "a");

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_value_is_null()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElementWithValue("child", null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_value_is_null_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElementWithValue(XNamespace.None + "child", null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_element_cannot_be_null_and_searching_with_namespace()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () =>
                element.Should().NotHaveElementWithValue(XNamespace.None + "child", "b", "we want to test the {0} message",
                    "failure");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_with_specified_value_is_found_with_namespace()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => element.Should().NotHaveElementWithValue(XNamespace.None + "child", "b");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_element_with_namespace_not_found()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().NotHaveElementWithValue(XNamespace.None + "c", "f");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Passes_when_element_with_namespace_found_but_value_does_not_match()
        {
            // Arrange
            var element = XElement.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            element.Should().NotHaveElementWithValue(XNamespace.None + "child", "c");
        }
    }
}

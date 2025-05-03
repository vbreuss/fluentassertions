﻿using System;
using System.Xml;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Xml;

public class XmlNodeAssertionSpecs
{
    public class BeSameAs
    {
        [Fact]
        public async Task When_asserting_an_xml_node_is_the_same_as_the_same_xml_node_it_should_succeed()
        {
            // Arrange
            var doc = new XmlDocument();

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(doc).IsSameAs(doc));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_same_as_a_different_xml_node_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<doc/>");
            var otherNode = new XmlDocument();
            otherNode.LoadXml("<otherDoc/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsSameAs(otherNode).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_same_as_a_different_xml_node_it_should_fail_with_descriptive_message_and_truncate_xml()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<doc>Some very long text that should be truncated.</doc>");
            var otherNode = new XmlDocument();
            otherNode.LoadXml("<otherDoc/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsSameAs(otherNode).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_equality_of_an_xml_node_but_is_null_it_should_throw_appropriately()
        {
            // Arrange
            XmlDocument theDocument = null;
            var expected = new XmlDocument();
            expected.LoadXml("<xml/>");

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsSameAs(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class BeNull
    {
        [Fact]
        public async Task When_asserting_an_xml_node_is_null_and_it_is_it_should_succeed()
        {
            // Arrange
            XmlNode node = null;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(node).IsNull());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_null_but_it_is_not_it_should_fail()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<xml/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(xmlDoc).IsNull());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_null_but_it_is_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected theDocument to be <null> because we want to test the failure message," +
                    " but found <xml />.").AsWildcard();
        }
    }

    public class NotBeNull
    {
        [Fact]
        public async Task When_asserting_a_non_null_xml_node_is_not_null_it_should_succeed()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<xml/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(xmlDoc).IsNotNull());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_null_xml_node_is_not_null_it_should_fail()
        {
            // Arrange
            XmlDocument xmlDoc = null;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(xmlDoc).IsNotNull());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_null_xml_node_is_not_null_it_should_fail_with_descriptive_message()
        {
            // Arrange
            XmlDocument theDocument = null;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsNotNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class BeEquivalentTo
    {
        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_the_same_xml_node_it_should_succeed()
        {
            // Arrange
            var doc = new XmlDocument();

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(doc).IsEqualTo(doc));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_a_different_xml_node_with_other_contents_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<subject/>");
            var expected = new XmlDocument();
            expected.LoadXml("<expected/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_a_different_xml_node_with_same_contents_it_should_succeed()
        {
            // Arrange
            var xml = "<root><a xmlns=\"urn:a\"><data>data</data></a><ns:b xmlns:ns=\"urn:b\"><data>data</data></ns:b></root>";

            var subject = new XmlDocument();
            subject.LoadXml(xml);
            var expected = new XmlDocument();
            expected.LoadXml(xml);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_assertion_an_xml_node_is_equivalent_to_a_different_xml_node_with_different_namespace_prefix_it_should_succeed()
        {
            // Arrange
            var subject = new XmlDocument();
            subject.LoadXml("<xml xmlns=\"urn:a\"/>");
            var expected = new XmlDocument();
            expected.LoadXml("<a:xml xmlns:a=\"urn:a\"/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_a_different_xml_node_which_differs_only_on_unused_namespace_declaration_it_should_succeed()
        {
            // Arrange
            var subject = new XmlDocument();
            subject.LoadXml("<xml xmlns:a=\"urn:a\"/>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_a_different_XmlDocument_which_differs_on_a_child_element_name_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><child><subject/></child></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><child><expected/></child></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_a_different_xml_node_which_differs_on_a_child_element_namespace_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<a:xml xmlns:a=\"urn:a\"><a:child><a:data/></a:child></a:xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml xmlns=\"urn:a\"><child><data xmlns=\"urn:b\"/></child></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_contains_an_unexpected_node_type_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml>data</xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><data/></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_contains_extra_elements_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><data/></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml/>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_lacks_elements_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml/>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><data/></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_lacks_attributes_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><element b=\"1\"/></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><element a=\"b\" b=\"1\"/></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_has_extra_attributes_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><element a=\"b\"/></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><element/></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_has_different_attribute_values_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><element a=\"b\"/></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><element a=\"c\"/></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_has_attribute_with_different_namespace_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><element xmlns:ns=\"urn:a\" ns:a=\"b\"/></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><element a=\"b\"/></xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_which_has_different_text_contents_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml>a</xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml>b</xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_with_different_comments_it_should_succeed()
        {
            // Arrange
            var subject = new XmlDocument();
            subject.LoadXml("<xml><!--Comment--><a/></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><a/><!--Comment--></xml>");

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_to_different_xml_node_with_different_insignificant_whitespace_it_should_succeed()
        {
            // Arrange
            var subject = new XmlDocument { PreserveWhitespace = true };

            subject.LoadXml("<xml><a><b/></a></xml>");

            var expected = new XmlDocument { PreserveWhitespace = true };

            expected.LoadXml("<xml>\n<a>   \n   <b/></a>\r\n</xml>");

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_that_contains_an_unsupported_node_it_should_throw_a_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><![CDATA[Text]]></xml>");

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(theDocument));

            // Assert
            await Expect.That(act).Throws<NotSupportedException>();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_equivalent_that_isnt_it_should_include_the_right_location_in_the_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml><a/><b c=\"d\"/></xml>");
            var expected = new XmlDocument();
            expected.LoadXml("<xml><a/><b c=\"e\"/></xml>");

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsEqualTo(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeEquivalentTo
    {
        [Fact]
        public async Task When_asserting_an_xml_node_is_not_equivalent_to_som_other_xml_node_it_should_succeed()
        {
            // Arrange
            var subject = new XmlDocument();
            subject.LoadXml("<xml>a</xml>");
            var unexpected = new XmlDocument();
            unexpected.LoadXml("<xml>b</xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotEqualTo(unexpected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_xml_node_is_not_equivalent_to_same_xml_node_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = new XmlDocument();
            theDocument.LoadXml("<xml>a</xml>");

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(theDocument).IsNotEqualTo(theDocument).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}

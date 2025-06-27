﻿using System;
using System.Xml.Linq;
using FluentAssertions.Execution;
using FluentAssertions.Formatting;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Xml;

public class XDocumentAssertionSpecs
{
    public class Be
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equal_to_the_same_xml_document_it_should_succeed()
        {
            // Arrange
            var document = new XDocument();
            var sameXDocument = document;

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsEqualTo(sameXDocument));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equal_to_a_different_xml_document_it_should_fail()
        {
            // Arrange
            var theDocument = new XDocument();
            var otherXDocument = new XDocument();

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEqualTo(otherXDocument));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_the_expected_element_is_null_it_fails()
        {
            // Arrange
            XDocument theDocument = null;

            // Act
            Action act = () => Synchronously.Verify(That(theDocument).IsEqualTo(new XDocument()).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_both_subject_and_expected_documents_are_null_it_succeeds()
        {
            // Arrange
            XDocument theDocument = null;

            // Act
            Action act = () => Synchronously.Verify(That(theDocument).IsEqualTo(null));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_document_is_expected_to_equal_null_it_fails()
        {
            // Arrange
            XDocument theDocument = new();

            // Act
            Action act = () => Synchronously.Verify(That(theDocument).IsEqualTo(null).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equal_to_a_different_xml_document_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<configuration></configuration>");
            var otherXDocument = XDocument.Parse("<data></data>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEqualTo(otherXDocument).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBe
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equal_to_a_different_xml_document_it_should_succeed()
        {
            // Arrange
            var document = new XDocument();
            var otherXDocument = new XDocument();

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsNotEqualTo(otherXDocument));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equal_to_the_same_xml_document_it_should_fail()
        {
            // Arrange
            var theDocument = new XDocument();
            var sameXDocument = theDocument;

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEqualTo(sameXDocument));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_document_is_not_supposed_to_be_a_document_it_succeeds()
        {
            // Arrange
            XDocument theDocument = null;

            // Act
            Action act = () => Synchronously.Verify(That(theDocument).IsNotEqualTo(new XDocument()));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_document_is_not_supposed_to_be_null_it_succeeds()
        {
            // Arrange
            XDocument theDocument = new();

            // Act
            Action act = () => Synchronously.Verify(That(theDocument).IsNotEqualTo(null));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_document_is_not_supposed_to_be_equal_to_null_it_fails()
        {
            // Arrange
            XDocument theDocument = null;

            // Act
            Action act = () => Synchronously.Verify(That(theDocument).IsNotEqualTo(null).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equal_to_the_same_xml_document_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<configuration></configuration>");
            var sameXDocument = theDocument;

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEqualTo(sameXDocument).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeEquivalentTo
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equivalent_to_the_same_xml_document_it_should_succeed()
        {
            // Arrange
            var document = new XDocument();
            var sameXDocument = document;

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsEquivalentTo(sameXDocument));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_selfclosing_document_is_equivalent_to_a_different_xml_document_with_same_structure_it_should_succeed()
        {
            // Arrange
            var document = XDocument.Parse("<parent><child /></parent>");
            var otherXDocument = XDocument.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsEquivalentTo(otherXDocument));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equivalent_to_a_different_xml_document_with_same_structure_it_should_succeed()
        {
            // Arrange
            var document = XDocument.Parse("<parent><child></child></parent>");
            var otherXDocument = XDocument.Parse("<parent><child></child></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsEquivalentTo(otherXDocument));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equivalent_to_a_xml_document_with_elements_missing_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /><child2 /></parent>");
            var otherXDocument = XDocument.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(otherXDocument));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equivalent_to_a_different_xml_document_with_extra_elements_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /></parent>");
            var expected = XDocument.Parse("<parent><child /><child2 /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_with_selfclosing_child_is_equivalent_to_a_different_xml_document_with_subchild_child_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /></parent>");
            var otherXDocument = XDocument.Parse("<parent><child><child /></child></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(otherXDocument));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equivalent_to_a_different_xml_document_elements_missing_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /><child2 /></parent>");
            var expected = XDocument.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected EndElement \"parent\" in theDocument at \"/parent\" because we want to test the failure message,"
                + " but found Element \"child2\".").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_equivalent_to_a_different_xml_document_with_extra_elements_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /></parent>");
            var expected = XDocument.Parse("<parent><child /><child2 /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected Element \"child2\" in theDocument at \"/parent\" because we want to test the failure message,"
                + " but found EndElement \"parent\".").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_document_is_null_then_be_equivalent_to_a_document_fails()
        {
            XDocument theDocument = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(XDocument.Parse("<parent><child /></parent>")).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theDocument to be equivalent to <null> *failure message*" +
                    ", but found \"<parent><child /></parent>\".").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_assertion_an_xml_document_is_equivalent_to_a_different_xml_document_with_different_namespace_prefix_it_should_succeed()
        {
            // Arrange
            var subject = XDocument.Parse("<xml xmlns=\"urn:a\"/>");
            var expected = XDocument.Parse("<a:xml xmlns:a=\"urn:a\"/>");

            // Act
            Action act = () =>
Synchronously.Verify(That(subject).IsEquivalentTo(expected));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_document_is_equivalent_to_a_different_xml_document_which_differs_only_on_unused_namespace_declaration_it_should_succeed()
        {
            // Arrange
            var subject = XDocument.Parse("<xml xmlns:a=\"urn:a\"/>");
            var expected = XDocument.Parse("<xml/>");

            // Act
            Action act = () =>
Synchronously.Verify(That(subject).IsEquivalentTo(expected));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_document_is_equivalent_to_different_xml_document_which_lacks_attributes_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<xml><element b=\"1\"/></xml>");
            var expected = XDocument.Parse("<xml><element a=\"b\" b=\"1\"/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_document_is_equivalent_to_different_xml_document_which_has_extra_attributes_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<xml><element a=\"b\"/></xml>");
            var expected = XDocument.Parse("<xml><element/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_document_is_equivalent_to_different_xml_document_which_has_different_attribute_values_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<xml><element a=\"b\"/></xml>");
            var expected = XDocument.Parse("<xml><element a=\"c\"/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_document_is_equivalent_to_different_xml_document_which_has_attribute_with_different_namespace_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<xml><element xmlns:ns=\"urn:a\" ns:a=\"b\"/></xml>");
            var expected = XDocument.Parse("<xml><element a=\"b\"/></xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_document_is_equivalent_to_different_xml_document_which_has_different_text_contents_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<xml>a</xml>");
            var expected = XDocument.Parse("<xml>b</xml>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsEquivalentTo(expected).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_an_xml_document_is_equivalent_to_different_xml_document_with_different_comments_it_should_succeed()
        {
            // Arrange
            var subject = XDocument.Parse("<xml><!--Comment--><a/></xml>");
            var expected = XDocument.Parse("<xml><a/><!--Comment--></xml>");

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsEquivalentTo(expected));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_equivalence_of_an_xml_document_but_has_different_attribute_value_it_should_fail_with_xpath_to_difference()
        {
            // Arrange
            XDocument actual = XDocument.Parse("<xml><a attr=\"x\"/><b id=\"foo\"/></xml>");
            XDocument expected = XDocument.Parse("<xml><a attr=\"x\"/><b id=\"bar\"/></xml>");

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsEquivalentTo(expected));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_equivalence_of_document_with_repeating_element_names_but_differs_it_should_fail_with_index_xpath_to_difference()
        {
            // Arrange
            XDocument actual = XDocument.Parse(
                "<xml><xml2 /><xml2 /><xml2><a x=\"y\"/><b><sub /></b><a x=\"y\"/></xml2></xml>");

            XDocument expected = XDocument.Parse(
                "<xml><xml2 /><xml2 /><xml2><a x=\"y\"/><b><sub /></b><a x=\"z\"/></xml2></xml>");

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsEquivalentTo(expected));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_equivalence_of_document_with_repeating_element_names_on_different_levels_but_differs_it_should_fail_with_index_xpath_to_difference()
        {
            // Arrange
            XDocument actual = XDocument.Parse(
                "<xml><xml /><xml /><xml><xml x=\"y\"/><xml2><xml /></xml2><xml x=\"y\"/></xml></xml>");

            XDocument expected = XDocument.Parse(
                "<xml><xml /><xml /><xml><xml x=\"y\"/><xml2><xml /></xml2><xml x=\"z\"/></xml></xml>");

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsEquivalentTo(expected));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_equivalence_of_document_with_repeating_element_names_with_different_parents_but_differs_it_should_fail_with_index_xpath_to_difference()
        {
            // Arrange
            XDocument actual = XDocument.Parse(
                "<root><xml1 /><xml1><xml2 /><xml2 a=\"x\" /></xml1><xml1><xml2 /><xml2 a=\"x\" /></xml1></root>");

            XDocument expected = XDocument.Parse(
                "<root><xml1 /><xml1><xml2 /><xml2 a=\"x\" /></xml1><xml1><xml2 /><xml2 a=\"y\" /></xml1></root>");

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsEquivalentTo(expected));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeEquivalentTo
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_a_different_xml_document_with_elements_missing_it_should_succeed()
        {
            // Arrange
            var document = XDocument.Parse("<parent><child /><child2 /></parent>");
            var otherXDocument = XDocument.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsNotEquivalentTo(otherXDocument));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_a_different_xml_document_with_extra_elements_it_should_succeed()
        {
            // Arrange
            var document = XDocument.Parse("<parent><child /></parent>");
            var otherXDocument = XDocument.Parse("<parent><child /><child2 /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsNotEquivalentTo(otherXDocument));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_a_different_xml_document_with_same_structure_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /></parent>");
            var otherXDocument = XDocument.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEquivalentTo(otherXDocument));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_the_same_xml_document_it_should_fail()
        {
            // Arrange
            var theDocument = new XDocument();
            var sameXDocument = theDocument;

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEquivalentTo(sameXDocument));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_a_different_xml_document_with_same_structure_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /></parent>");
            var otherDocument = XDocument.Parse("<parent><child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEquivalentTo(otherDocument).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_a_different_xml_document_with_same_contents_but_different_ns_prefixes_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse(@"<parent xmlns:ns1=""a""><ns1:child /></parent>");
            var otherXDocument = XDocument.Parse(@"<parent xmlns:ns2=""a""><ns2:child /></parent>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEquivalentTo(otherXDocument).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_a_different_xml_document_with_same_contents_but_extra_unused_xmlns_declaration_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse(@"<xml xmlns:ns1=""a"" />");
            var otherDocument = XDocument.Parse("<xml />");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEquivalentTo(otherDocument));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_xml_document_is_not_equivalent_to_the_same_xml_document_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<parent><child /></parent>");
            var sameXDocument = theDocument;

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotEquivalentTo(sameXDocument).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_a_null_document_is_not_equivalent_to_a_document_it_succeeds()
        {
            XDocument theDocument = null;

            // Act
            Action act = () => Synchronously.Verify(That(theDocument).IsNotEquivalentTo(XDocument.Parse("<parent><child /></parent>")));

            // Assert
            await That(act).DoesNotThrow();
        }
    }

    public class BeNull
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_document_is_null_it_should_succeed()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsNull());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_non_null_xml_document_is_null_it_should_fail()
        {
            // Arrange
            var theDocument = new XDocument();

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_non_null_xml_document_is_null_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse("<configuration></configuration>");

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_non_null_xml_document_is_not_null_it_should_succeed()
        {
            // Arrange
            var document = new XDocument();

            // Act
            Action act = () =>
Synchronously.Verify(That(document).IsNotNull());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_document_is_not_null_it_should_fail()
        {
            // Arrange
            XDocument theDocument = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_xml_document_is_not_null_it_should_fail_with_descriptive_message()
        {
            // Arrange
            XDocument theDocument = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(theDocument).IsNotNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class HaveRoot
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_element_and_it_does_it_should_succeed_and_return_it_for_chaining()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            XElement root = document.Should().HaveRoot("parent").Subject;

            // Assert
            await That(root).IsSameAs(document.Root);
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_element_but_it_does_not_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () => theDocument.Should().HaveRoot("unknown");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_element_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theDocument.Should().HaveRoot("unknown", "because we want to test the failure message");

            // Assert
            string expectedMessage = "Expected theDocument to have root element \"unknown\"" +
                " because we want to test the failure message" +
                $", but found {Formatter.ToString(theDocument)}.";

            await That(act).Throws<XunitException>().WithMessage(expectedMessage).AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_document_has_root_element_it_should_fail()
        {
            // Arrange
            XDocument theDocument = null;

            // Act
            Action act = () => theDocument.Should().HaveRoot("unknown");

            // Assert
            await That(act).Throws<InvalidOperationException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_document_has_a_root_element_with_a_null_name_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () => theDocument.Should().HaveRoot(null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_document_has_a_root_element_with_a_null_xname_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () => theDocument.Should().HaveRoot((XName)null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_element_with_ns_and_it_does_it_should_succeed()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent xmlns='http://www.example.com/2012/test'>
                    <child/>
                </parent>
                """);

            // Act
            Action act = () =>
                document.Should().HaveRoot(XName.Get("parent", "http://www.example.com/2012/test"));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_element_with_ns_but_it_does_not_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theDocument.Should().HaveRoot(XName.Get("unknown", "http://www.example.com/2012/test"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Can_chain_another_assertion_on_the_root_element()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () => theDocument.Should().HaveRoot("parent").Which.Should().HaveElement("unknownChild");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_element_with_ns_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theDocument.Should().HaveRoot(XName.Get("unknown", "http://www.example.com/2012/test"),
                    "because we want to test the failure message");

            // Assert
            string expectedMessage =
                "Expected theDocument to have root element \"{http://www.example.com/2012/test}unknown\"" +
                " because we want to test the failure message" +
                $", but found {Formatter.ToString(theDocument)}.";

            await That(act).Throws<XunitException>().WithMessage(expectedMessage).AsWildcard();
        }
    }

    public class HaveElement
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_document_has_the_expected_child_element_it_should_not_throw_and_return_the_element_for_chaining()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            XElement element = document.Should().HaveElement("child").Subject;

            // Assert
            await That(element).IsSameAs(document.Element("parent").Element("child"));
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Can_chain_another_assertion_on_the_root_element()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            var act = () => document.Should().HaveElement("child").Which.Should().HaveElement("grandChild");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_with_child_element_but_it_does_not_it_should_fail()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theDocument.Should().HaveElement("unknown");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_with_child_element_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theDocument.Should().HaveElement("unknown", "because we want to test the failure message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theDocument to have root element with child \"unknown\" because we want to test the failure message,"
                + " but no such child element was found.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_with_child_element_with_ns_and_it_does_it_should_succeed()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent xmlns:test='http://www.example.org/2012/test'>
                    <test:child />
                </parent>
                """);

            // Act
            Action act = () =>
                document.Should().HaveElement(XName.Get("child", "http://www.example.org/2012/test"));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_with_child_element_with_ns_but_it_does_not_it_should_fail()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                document.Should().HaveElement(XName.Get("unknown", "http://www.example.org/2012/test"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected document to have root element with child \"{http://www.example.org/2012/test}unknown\","
                + " but no such child element was found.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_with_child_element_with_ns_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var theDocument = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () =>
                theDocument.Should().HaveElement(XName.Get("unknown", "http://www.example.org/2012/test"),
                    "because we want to test the failure message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theDocument to have root element with child \"{http://www.example.org/2012/test}unknown\""
                + " because we want to test the failure message, but no such child element was found.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_root_with_child_element_with_attributes_it_should_be_possible_to_use_which_to_assert_on_the_element()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child attr='1' />
                </parent>
                """);

            // Act
            XElement matchedElement = document.Should().HaveElement("child").Subject;

            // Assert
            await That(matchedElement).IsExactly<XElement>();
            await That(matchedElement.Name).IsEqualTo(XName.Get("child"));
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_document_has_an_element_it_should_fail()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () => document.Should().HaveElement("unknown");

            // Assert
            await That(act).Throws<InvalidOperationException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_document_without_root_element_has_an_element_it_should_fail()
        {
            // Arrange
            XDocument document = new();

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                document.Should().HaveElement("unknown");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_document_has_an_element_with_a_null_name_it_should_fail()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElement(null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_document_has_an_element_with_a_null_xname_it_should_fail()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElement((XName)null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class HaveElementWithValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_document_cannot_be_null()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () => document.Should().HaveElementWithValue("child", "b");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void The_expected_element_with_the_expected_value_is_valid()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            document.Should().HaveElementWithValue("child", "b");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_is_not_found()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElementWithValue("grandchild", "f");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_found_but_value_does_not_match()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElementWithValue("child", "c");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_element_is_null()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElementWithValue(null, "a");

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_element_with_namespace_is_null()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElementWithValue((XName)null, "a");

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_value_is_null()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElementWithValue("child", null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_expected_value_is_null_and_searching_with_namespace()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElementWithValue(XNamespace.None + "child", null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_document_cannot_be_null_and_using_a_namespace()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () =>
                document.Should()
                    .HaveElementWithValue(XNamespace.None + "child", "b", "we want to test the {0} message", "failure");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Has_element_with_namespace_and_specified_value()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            document.Should().HaveElementWithValue(XNamespace.None + "child", "b");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_with_namespace_is_not_found()
        {
            // Arrange
            var document = XDocument.Parse(
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
                document.Should().HaveElementWithValue(XNamespace.None + "grandchild", "f");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_with_namespace_found_but_value_does_not_match()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElementWithValue(XNamespace.None + "child", "c");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class HaveElementWithOccurrence
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void When_asserting_document_has_two_child_elements_and_it_does_it_succeeds()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                    <child />
                </parent>
                """);

            // Act / Assert
            document.Should().HaveElement("child", Exactly.Twice());
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Asserting_document_null_inside_an_assertion_scope_it_checks_the_whole_assertion_scope_before_failing()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () =>
            {
                using (new AssertionScope())
                {
                    document.Should().HaveElement("child", Exactly.Twice());
                    document.Should().HaveElement("child", Exactly.Twice());
                }
            };

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Asserting_with_document_root_null_inside_an_assertion_scope_it_checks_the_whole_assertion_scope_before_failing()
        {
            // Arrange
            XDocument document = new();

            // Act
            Action act = () =>
            {
                using (new AssertionScope())
                {
                    document.Should().HaveElement("child", Exactly.Twice());
                    document.Should().HaveElement("child", Exactly.Twice());
                }
            };

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_document_has_two_child_elements_but_it_does_have_three_it_fails()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElement("child", Exactly.Twice());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Document_is_valid_and_expected_null_with_string_overload_it_fails()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElement(null, Exactly.Twice());

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Document_is_valid_and_expected_null_with_x_name_overload_it_fails()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElement((XName)null, Exactly.Twice());

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Chaining_after_a_successful_occurrence_check_does_continue_the_assertion()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act / Assert
            document.Should().HaveElement("child", AtLeast.Twice())
                .Which.Should().NotBeNull();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Chaining_after_a_non_successful_occurrence_check_does_not_continue_the_assertion()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child />
                    <child />
                    <child />
                </parent>
                """);

            // Act
            Action act = () => document.Should().HaveElement("child", Exactly.Once())
                .Which.Should().NotBeNull();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_a_null_document_to_have_an_element_count_it_should_fail()
        {
            // Arrange
            XDocument xDocument = null;

            // Act
            Action act = () => xDocument.Should().HaveElement("child", AtLeast.Once());

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveElement
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_document_cannot_be_null()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () => document.Should().NotHaveElement("child");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void The_document_does_not_have_this_element()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            document.Should().NotHaveElement("c");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_found_but_expected_to_be_absent()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().NotHaveElement("child");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_unexpected_element_is_null()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().NotHaveElement(null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_unexpected_element_is_null_with_namespace()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act
            Action act = () => document.Should().NotHaveElement((XName)null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_null_with_namespace()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () =>
                document.Should()
                    .NotHaveElement(XNamespace.None + "child", "we want to test the {0} message", "failure");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public void Not_have_element_with_with_namespace()
        {
            // Arrange
            var document = XDocument.Parse(
                """
                <parent>
                    <child>a</child>
                    <child>b</child>
                </parent>
                """);

            // Act / Assert
            document.Should().NotHaveElement(XNamespace.None + "c");
        }
    }

    public class NotHaveElementWithValue
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task The_document_cannot_be_null()
        {
            // Arrange
            XDocument element = null;

            // Act
            Action act = () => element.Should().NotHaveElementWithValue("child", "b");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task Throws_when_element_with_specified_value_is_found()
        {
            // Arrange
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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
        public async Task The_document_cannot_be_null_and_searching_with_namespace()
        {
            // Arrange
            XDocument element = null;

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
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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
            var element = XDocument.Parse(
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

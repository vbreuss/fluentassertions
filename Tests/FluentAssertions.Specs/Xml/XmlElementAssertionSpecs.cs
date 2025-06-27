using System;
using System.Xml;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Xml;

public class XmlElementAssertionSpecs
{
    public class BeEquivalent
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_is_equivalent_to_another_xml_element_with_same_contents_it_should_succeed()
        {
            // This test is basically just a check that the BeEquivalent method
            // is available on XmlElementAssertions, which it should be if
            // XmlElementAssertions inherits XmlNodeAssertions.

            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<user>grega</user>");
            var element = xmlDoc.DocumentElement;
            var expectedDoc = new XmlDocument();
            expectedDoc.LoadXml("<user>grega</user>");
            var expected = expectedDoc.DocumentElement;

            // Act
            Action act = () =>
Synchronously.Verify(That(element).IsEqualTo(expected));

            // Assert
            await That(act).DoesNotThrow();
        }
    }

    public class HaveInnerText
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_a_specific_inner_text_and_it_does_it_should_succeed()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<user>grega</user>");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveInnerText("grega");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_a_specific_inner_text_but_it_has_a_different_inner_text_it_should_throw()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<user>grega</user>");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveInnerText("stamac");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_a_specific_inner_text_but_it_has_a_different_inner_text_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var document = new XmlDocument();
            document.LoadXml("<user>grega</user>");
            var theElement = document.DocumentElement;

            // Act
            Action act = () =>
                theElement.Should().HaveInnerText("stamac", "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class HaveAttribute
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_specific_value_and_it_does_it_should_succeed()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("""<user name="martin" />""");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveAttribute("name", "martin");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_specific_value_but_attribute_does_not_exist_it_should_fail()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("""<user name="martin" />""");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveAttribute("age", "36");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_specific_value_but_attribute_does_not_exist_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var document = new XmlDocument();
            document.LoadXml("""<user name="martin" />""");
            var theElement = document.DocumentElement;

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute("age", "36", "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have attribute \"age\" with value \"36\"" +
                    " because we want to test the failure message" +
                    ", but found no such attribute in <user name=\"martin\"*").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_specific_value_but_attribute_has_different_value_it_should_fail()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("""<user name="martin" />""");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveAttribute("name", "dennis");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_specific_value_but_attribute_has_different_value_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var document = new XmlDocument();
            document.LoadXml("""<user name="martin" />""");
            var theElement = document.DocumentElement;

            // Act
            Action act = () =>
                theElement.Should().HaveAttribute("name", "dennis", "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"name\" in theElement to have value \"dennis\"" +
                    " because we want to test the failure message" +
                    ", but found \"martin\".").AsWildcard();
        }
    }

    public class HaveAttributeWithNamespace
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_ns_and_specific_value_and_it_does_it_should_succeed()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveAttributeWithNamespace("name", "http://www.example.com/2012/test", "martin");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_ns_and_specific_value_but_attribute_does_not_exist_it_should_fail()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveAttributeWithNamespace("age", "http://www.example.com/2012/test", "36");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_ns_and_specific_value_but_attribute_does_not_exist_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var document = new XmlDocument();
            document.LoadXml("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");
            var theElement = document.DocumentElement;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                theElement.Should().HaveAttributeWithNamespace("age", "http://www.example.com/2012/test", "36",
                    "because we want to test the failure {0}", "message");
            };

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have attribute \"{http://www.example.com/2012/test}age\" with value \"36\"" +
                    " because we want to test the failure message" +
                    ", but found no such attribute in <user xmlns:a=\"http:…").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_ns_and_specific_value_but_attribute_has_different_value_it_should_fail()
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");
            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveAttributeWithNamespace("name", "http://www.example.com/2012/test", "dennis");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_attribute_with_ns_and_specific_value_but_attribute_has_different_value_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var document = new XmlDocument();
            document.LoadXml("""<user xmlns:a="http://www.example.com/2012/test" a:name="martin" />""");
            var theElement = document.DocumentElement;

            // Act
            Action act = () =>
                theElement.Should().HaveAttributeWithNamespace("name", "http://www.example.com/2012/test", "dennis",
                    "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected attribute \"{http://www.example.com/2012/test}name\" in theElement to have value \"dennis\"" +
                    " because we want to test the failure message" +
                    ", but found \"martin\".").AsWildcard();
        }
    }

    public class HaveElement
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_and_it_does_it_should_succeed()
        {
            // Arrange
            var xml = new XmlDocument();

            xml.LoadXml(
                """
                <parent>
                    <child />
                </parent>
                """);

            var element = xml.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveElement("child");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_but_it_does_not_it_should_fail()
        {
            // Arrange
            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(
                """
                <parent>
                    <child />
                </parent>
                """);

            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveElement("unknown");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var document = new XmlDocument();

            document.LoadXml(
                """
                <parent>
                    <child />
                </parent>
                """);

            var theElement = document.DocumentElement;

            // Act
            Action act = () =>
                theElement.Should().HaveElement("unknown", "because we want to test the failure message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have child element \"unknown\""
                + " because we want to test the failure message"
                + ", but no such child element was found.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_it_should_return_the_matched_element_in_the_which_property()
        {
            // Arrange
            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(
                """
                <parent>
                    <child attr='1' />
                </parent>
                """);

            var element = xmlDoc.DocumentElement;

            // Act
            var matchedElement = element.Should().HaveElement("child").Subject;

            // Assert
            await That(matchedElement).IsExactly<XmlElement>();

            await That(matchedElement.Name).IsEqualTo("child");
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_with_ns_has_child_element_and_it_does_it_should_succeed()
        {
            // Arrange
            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(
                """
                <parent xmlns="test">
                    <child>value</child>
                </parent>
                """);

            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveElement("child");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_and_it_does_with_ns_it_should_succeed2()
        {
            // Arrange
            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(
                """
                <parent>
                    <child xmlns="test">value</child>
                </parent>
                """);

            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveElement("child");

            // Assert
            await That(act).DoesNotThrow();
        }
    }

    public class HaveElementWithNamespace
    {
        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_with_ns_and_it_does_it_should_succeed()
        {
            // Arrange
            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(
                """
                <parent xmlns:c='http://www.example.com/2012/test'>
                    <c:child />
                </parent>
                """);

            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveElementWithNamespace("child", "http://www.example.com/2012/test");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_with_ns_but_it_does_not_it_should_fail()
        {
            // Arrange
            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(
                """
                <parent>
                    <child />
                </parent>
                """);

            var element = xmlDoc.DocumentElement;

            // Act
            Action act = () =>
                element.Should().HaveElementWithNamespace("unknown", "http://www.example.com/2012/test");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
        public async Task When_asserting_xml_element_has_child_element_with_ns_but_it_does_not_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var document = new XmlDocument();

            document.LoadXml(
                """
                <parent>
                    <child />
                </parent>
                """);

            var theElement = document.DocumentElement;

            // Act
            Action act = () =>
                theElement.Should().HaveElementWithNamespace("unknown", "http://www.example.com/2012/test",
                    "because we want to test the failure message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected theElement to have child element \"{{http://www.example.com/2012/test}}unknown\""
                + " because we want to test the failure message"
                + ", but no such child element was found.").AsWildcard();
        }
    }
}

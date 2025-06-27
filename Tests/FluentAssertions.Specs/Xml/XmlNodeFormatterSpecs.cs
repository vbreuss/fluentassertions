using System;
using System.Xml;
using FluentAssertions.Formatting;
using Xunit;

namespace FluentAssertions.Specs.Xml;

public class XmlNodeFormatterSpecs
{
    [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
    public async Task When_a_node_is_20_chars_long_it_should_not_be_trimmed()
    {
        // Arrange
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(@"<xml attr=""01234"" />");

        // Act
        string result = Formatter.ToString(xmlDoc);

        // Assert
        await That(result).IsEqualTo(@"<xml attr=""01234"" />");
    }

    [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
    public async Task When_a_node_is_longer_then_20_chars_it_should_be_trimmed()
    {
        // Arrange
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(@"<xml attr=""012345"" />");

        // Act
        string result = Formatter.ToString(xmlDoc);

        // Assert
        await That(result).IsEqualTo(@"<xml attr=""012345"" /…");
    }
}

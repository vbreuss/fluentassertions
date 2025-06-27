using System.Xml.Linq;
using FluentAssertions.Formatting;
using Xunit;

namespace FluentAssertions.Specs.Xml;

public class XDocumentFormatterSpecs
{
    [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
    public async Task When_element_has_root_element_it_should_include_it_in_the_output()
    {
        // Act
        var document = XDocument.Parse(
            @"<configuration>
                     <startDate />
                     <endDate />
                  </configuration>");

        string result = Formatter.ToString(document);

        // Assert
        await That(result).IsEqualTo("<configuration>…</configuration>");
    }

    [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
    public async Task When_element_has_no_root_element_it_should_include_it_in_the_output()
    {
        // Act
        var document = new XDocument();

        string result = Formatter.ToString(document);

        // Assert
        await That(result).IsEqualTo("[XML document without root element]");
    }
}

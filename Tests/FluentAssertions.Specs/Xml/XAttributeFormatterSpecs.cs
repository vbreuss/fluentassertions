using System.Xml.Linq;
using FluentAssertions.Formatting;
using Xunit;

namespace FluentAssertions.Specs.Xml;

public class XAttributeFormatterSpecs
{
    [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/575")]
    public async Task When_formatting_an_attribute_it_should_return_the_name_and_value()
    {
        // Act
        var element = XElement.Parse(@"<person name=""Martin"" age=""36"" />");
        XAttribute attribute = element.Attribute("name");
        string result = Formatter.ToString(attribute);

        // Assert
        await That(result).IsEqualTo(@"name=""Martin""");
    }
}

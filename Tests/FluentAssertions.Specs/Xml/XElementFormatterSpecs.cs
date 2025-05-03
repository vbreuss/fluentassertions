using System.Xml.Linq;
using FluentAssertions.Formatting;
using Xunit;

namespace FluentAssertions.Specs.Xml;

public class XElementFormatterSpecs
{
    [Fact]
    public async Task When_element_has_attributes_it_should_include_them_in_the_output()
    {
        // Act
        var element = XElement.Parse(@"<person name=""Martin"" age=""36"" />");
        string result = Formatter.ToString(element);

        // Assert
        await Expect.That(result).IsEqualTo(@"<person name=""Martin"" age=""36"" />");
    }

    [Fact]
    public async Task When_element_has_child_element_it_should_not_include_them_in_the_output()
    {
        // Act
        var element = XElement.Parse("""
            <person name="Martin" age="36">
                <child name="Laura" />
            </person>
            """);

        string result = Formatter.ToString(element);

        // Assert
        await Expect.That(result).IsEqualTo(@"<person name=""Martin"" age=""36"">…</person>");
    }
}

﻿using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using FluentAssertions.Extensions;
using JetBrains.Annotations;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class BeXmlSerializable
    {
        [Fact]
        public async Task When_an_object_is_xml_serializable_it_should_succeed()
        {
            // Arrange
            var subject = new XmlSerializableClass
            {
                Name = "John",
                Id = 1
            };

            // Act
            Action act = () => subject.Should().BeXmlSerializable();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_an_object_is_not_xml_serializable_it_should_fail()
        {
            // Arrange
            var subject = new NonPublicClass
            {
                Name = "John"
            };

            // Act
            Action act = () => subject.Should().BeXmlSerializable("we need to store it on {0}", "disk");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_object_is_xml_serializable_but_doesnt_restore_all_properties_it_should_fail()
        {
            // Arrange
            var subject = new XmlSerializableClassNotRestoringAllProperties
            {
                Name = "John",
                BirthDay = 20.September(1973)
            };

            // Act
            Action act = () => subject.Should().BeXmlSerializable();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class XmlSerializableClass
    {
        [UsedImplicitly]
        public string Name { get; set; }

        public int Id;
    }

    public class XmlSerializableClassNotRestoringAllProperties : IXmlSerializable
    {
        [UsedImplicitly]
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            BirthDay = DateTime.Parse(reader.ReadElementContentAsString(), CultureInfo.InvariantCulture);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(BirthDay.ToString(CultureInfo.InvariantCulture));
        }
    }

    internal class NonPublicClass
    {
        [UsedImplicitly]
        public string Name { get; set; }
    }
}

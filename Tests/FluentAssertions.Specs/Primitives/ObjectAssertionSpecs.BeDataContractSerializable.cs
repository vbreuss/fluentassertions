using System;
using System.Runtime.Serialization;
using FluentAssertions.Extensions;
using JetBrains.Annotations;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class BeDataContractSerializable
    {
        [Fact]
        public async Task When_an_object_is_data_contract_serializable_it_should_succeed()
        {
            // Arrange
            var subject = new DataContractSerializableClass
            {
                Name = "John",
                Id = 1
            };

            // Act
            Action act = () => subject.Should().BeDataContractSerializable();

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_an_object_is_not_data_contract_serializable_it_should_fail()
        {
            // Arrange
            var subject = new NonDataContractSerializableClass();

            // Act
            Action act = () => subject.Should().BeDataContractSerializable("we need to store it on {0}", "disk");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_object_is_data_contract_serializable_but_doesnt_restore_all_properties_it_should_fail()
        {
            // Arrange
            var subject = new DataContractSerializableClassNotRestoringAllProperties
            {
                Name = "John",
                BirthDay = 20.September(1973)
            };

            // Act
            Action act = () => subject.Should().BeDataContractSerializable();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_data_contract_serializable_object_doesnt_restore_an_ignored_property_it_should_succeed()
        {
            // Arrange
            var subject = new DataContractSerializableClassNotRestoringAllProperties
            {
                Name = "John",
                BirthDay = 20.September(1973)
            };

            // Act
            Action act = () => subject.Should()
                .BeDataContractSerializable<DataContractSerializableClassNotRestoringAllProperties>(
                    options => options.Excluding(x => x.Name));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_injecting_null_options_to_BeDataContractSerializable_it_should_throw()
        {
            // Arrange
            var subject = new DataContractSerializableClassNotRestoringAllProperties();

            // Act
            Action act = () => subject.Should()
                .BeDataContractSerializable<DataContractSerializableClassNotRestoringAllProperties>(
                    options: null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class NonDataContractSerializableClass
    {
        public Color Color { get; set; }
    }

    public class DataContractSerializableClass
    {
        [UsedImplicitly]
        public string Name { get; set; }

        public int Id;
    }

    [DataContract]
    public class DataContractSerializableClassNotRestoringAllProperties
    {
        public string Name { get; set; }

        [DataMember]
        public DateTime BirthDay { get; set; }
    }

    public enum Color
    {
        Red = 1,
        Yellow = 2
    }
}

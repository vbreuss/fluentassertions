using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using FluentAssertions.Primitives;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ReferenceTypeAssertionsSpecs
{
    [Fact]
    public async Task When_the_same_objects_are_expected_to_be_the_same_it_should_not_fail()
    {
        // Arrange
        var subject = new ClassWithCustomEqualMethod(1);
        var referenceToSubject = subject;

        // Act / Assert
        await Expect.That(subject).IsSameAs(referenceToSubject);
    }

    [Fact]
    public async Task When_two_different_objects_are_expected_to_be_the_same_it_should_fail_with_a_clear_explanation()
    {
        // Arrange
        var subject = new
        {
            Name = "John Doe"
        };

        var otherObject = new
        {
            UserName = "JohnDoe"
        };

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsSameAs(otherObject).Because($"they are {"the"} {"same"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>().WithMessage("""
            Expected subject to refer to {
                UserName = "JohnDoe"
            } because they are the same, but found {
                Name = "John Doe"
            }.
            """).AsWildcard();
    }

    [Fact]
    public async Task When_a_derived_class_has_longer_formatting_than_the_base_class()
    {
        var subject = new SimpleComplexBase[] { new Complex("goodbye"), new Simple() };
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEmpty());
        await Expect.That(act).Throws<XunitException>().WithMessage("""
            Expected subject to be empty, but found at least one item {
                FluentAssertions.Specs.Primitives.Complex
                {
                    Statement = "goodbye"
                }
            }.
            """).AsWildcard();
    }

    [Fact]
    public async Task When_two_different_objects_are_expected_not_to_be_the_same_it_should_not_fail()
    {
        // Arrange
        var someObject = new ClassWithCustomEqualMethod(1);
        var notSameObject = new ClassWithCustomEqualMethod(1);

        // Act / Assert
        await Expect.That(someObject).IsNotSameAs(notSameObject);
    }

    [Fact]
    public async Task When_two_equal_object_are_expected_not_to_be_the_same_it_should_fail()
    {
        // Arrange
        var someObject = new ClassWithCustomEqualMethod(1);
        ClassWithCustomEqualMethod sameObject = someObject;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNotSameAs(sameObject).Because($"they are {"the"} {"same"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_object_is_of_the_expected_type_it_should_not_throw()
    {
        // Arrange
        string aString = "blah";

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aString).IsExactly(typeof(string)));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_object_is_of_the_expected_open_generic_type_it_should_not_throw()
    {
        // Arrange
        var aList = new List<string>();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aList).IsExactly(typeof(List<>)));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_object_is_not_of_the_expected_open_generic_type_it_should_throw()
    {
        // Arrange
        var aList = new List<string>();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aList).IsExactly(typeof(Dictionary<,>)));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_object_is_null_it_should_throw()
    {
        // Arrange
        string aString = null;

        // Act
        Func<Task> action = async () =>
        {
            await Expect.That(aString).IsExactly(typeof(string));
        };

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_object_is_not_of_the_expected_type_it_should_throw()
    {
        // Arrange
        string aString = "blah";

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aString).IsExactly(typeof(int)));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_an_assertion_fails_on_BeOfType_succeeding_message_should_be_included()
    {
        // Act
        Func<Task> act = async () =>
        {
            var item = string.Empty;
            await Expect.That(item).IsExactly<int>();
            await Expect.That(item).IsExactly<long>();
        };

        // Assert
        await Expect.That(act).Throws<XunitException>().WithMessage("Expected type to be System.Int32, but found System.String.*" +
                "Expected type to be System.Int64, but found System.String.").AsWildcard();
    }

    [Fact]
    public async Task When_object_is_of_the_unexpected_type_it_should_throw()
    {
        // Arrange
        string aString = "blah";

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aString).IsNotExactly(typeof(string)));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_object_is_of_the_unexpected_generic_type_it_should_throw()
    {
        // Arrange
        string aString = "blah";

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aString).IsNotExactly<string>());

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_object_is_of_the_unexpected_open_generic_type_it_should_throw()
    {
        // Arrange
        var aList = new List<string>();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aList).IsNotExactly(typeof(List<>)));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_object_is_not_of_the_expected_type_it_should_not_throw()
    {
        // Arrange
        string aString = "blah";

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aString).IsNotExactly(typeof(int)));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_object_is_not_of_the_unexpected_open_generic_type_it_should_not_throw()
    {
        // Arrange
        var aList = new List<string>();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aList).IsNotExactly(typeof(Dictionary<,>)));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_generic_object_is_not_of_the_unexpected_type_it_should_not_throw()
    {
        // Arrange
        var aList = new List<string>();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aList).IsNotExactly<string>());

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_non_generic_object_is_not_of_the_unexpected_open_generic_type_it_should_not_throw()
    {
        // Arrange
        var aString = "blah";

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(aString).IsNotExactly(typeof(Dictionary<,>)));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_object_is_not_of_type_and_it_is_null_it_should_throw()
    {
        // Arrange
        string aString = null;

        // Act
        Func<Task> action = async () =>
        {
            await Expect.That(aString).IsNotExactly(typeof(string));
        };

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public void When_object_satisfies_predicate_it_should_not_throw()
    {
        // Arrange
        var someObject = new object();

        // Act / Assert
        someObject.Should().Match(o => o != null);
    }

    [Fact]
    public void When_typed_object_satisfies_predicate_it_should_not_throw()
    {
        // Arrange
        var someObject = new SomeDto
        {
            Name = "Dennis Doomen",
            Age = 36,
            Birthdate = new DateTime(1973, 9, 20)
        };

        // Act / Assert
        someObject.Should().Match<SomeDto>(o => o.Age > 0);
    }

    [Fact]
    public async Task When_object_does_not_match_the_predicate_it_should_throw()
    {
        // Arrange
        var someObject = new object();

        // Act
        Action act = () => someObject.Should().Match(o => o == null, "it is not initialized yet");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_a_typed_object_does_not_match_the_predicate_it_should_throw()
    {
        // Arrange
        var someObject = new SomeDto
        {
            Name = "Dennis Doomen",
            Age = 36,
            Birthdate = new DateTime(1973, 9, 20)
        };

        // Act
        Action act = () => someObject.Should().Match((SomeDto d) => d.Name.Length == 0, "it is not initialized yet");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_object_is_matched_against_a_null_it_should_throw()
    {
        // Arrange
        var someObject = new object();

        // Act
        Action act = () => someObject.Should().Match(null);

        // Assert
        await Expect.That(act).Throws<ArgumentNullException>();
    }

    #region Structure Reporting

    [Fact]
    public async Task When_an_assertion_on_two_objects_fails_it_should_show_the_properties_of_the_class()
    {
        // Arrange
        var subject = new SomeDto
        {
            Age = 37,
            Birthdate = 20.September(1973),
            Name = "Dennis"
        };

        var other = new SomeDto
        {
            Age = 2,
            Birthdate = 22.February(2009),
            Name = "Teddie"
        };

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(other));

        // Assert
        await Expect.That(act).Throws<XunitException>().WithMessage("Expected subject to be*FluentAssertions*SomeDto*{*Age = 2*Birthdate = <2009-02-22>*" +
            "  Name = \"Teddie\"*}, but found*FluentAssertions*SomeDto*{*Age = 37*" +
            "  Birthdate = <1973-09-20>*Name = \"Dennis\"*}.").AsWildcard();
    }

    [Fact]
    public async Task When_an_assertion_on_two_objects_fails_and_they_implement_tostring_it_should_show_their_string_representation()
    {
        // Arrange
        object subject = 3;
        object other = 4;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(other));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_an_assertion_on_two_unknown_objects_fails_it_should_report_the_type_name()
    {
        // Arrange
        var subject = new object();
        var other = new object();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(other));

        // Assert
        await Expect.That(act).Throws<XunitException>().WithMessage($"Expected subject to be System.Object (HashCode={other.GetHashCode()}), " +
                $"but found System.Object (HashCode={subject.GetHashCode()}).").AsWildcard();
    }

    #endregion

    public class Miscellaneous
    {
        [Fact]
        public async Task Should_throw_a_helpful_error_when_accidentally_using_equals()
        {
            // Arrange
            var subject = new ReferenceTypeAssertionsDummy(null);

            // Act
            Action action = () => subject.Equals(subject);

            // Assert
            await Expect.That(action).Throws<NotSupportedException>();
        }

        public class ReferenceTypeAssertionsDummy : ReferenceTypeAssertions<object, ReferenceTypeAssertionsDummy>
        {
            public ReferenceTypeAssertionsDummy(object subject)
                : base(subject, AssertionChain.GetOrCreate())
            {
            }

            protected override string Identifier => string.Empty;
        }
    }
}

public class SomeDto
{
    public string Name { get; set; }

    public int Age { get; set; }

    public DateTime Birthdate { get; set; }
}

internal class ClassWithCustomEqualMethod
{
    public ClassWithCustomEqualMethod(int key)
    {
        Key = key;
    }

    private int Key { get; }

    private bool Equals(ClassWithCustomEqualMethod other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return other.Key == Key;
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != typeof(ClassWithCustomEqualMethod))
        {
            return false;
        }

        return Equals((ClassWithCustomEqualMethod)obj);
    }

    public override int GetHashCode()
    {
        return Key;
    }

    public static bool operator ==(ClassWithCustomEqualMethod left, ClassWithCustomEqualMethod right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ClassWithCustomEqualMethod left, ClassWithCustomEqualMethod right)
    {
        return !Equals(left, right);
    }

    public override string ToString()
    {
        return $"ClassWithCustomEqualMethod({Key})";
    }
}

public abstract class SimpleComplexBase;

public class Simple : SimpleComplexBase
{
    public override string ToString() => "Simple(Hello)";
}

public class Complex : SimpleComplexBase
{
    public string Statement { get; set; }

    public Complex(string statement)
    {
        Statement = statement;
    }
}

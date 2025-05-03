using System;
using System.Collections.Generic;
using FluentAssertions.Equivalency;
using FluentAssertions.Equivalency.Execution;
using FluentAssertions.Execution;
using FluentAssertions.Specs.CultureAwareTesting;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

[Collection(nameof(StringComparisonSpecs))]
public class StringComparisonSpecs
{
    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_the_Turkish_letter_i_it_should_differ_by_dottedness(string subject, string expected)
    {
        // Act
        bool ordinal = string.Equals(subject, expected, StringComparison.OrdinalIgnoreCase);
#pragma warning disable CA1309 // Verifies that test data behaves differently in current vs invariant culture
        bool currentCulture = string.Equals(subject, expected, StringComparison.CurrentCultureIgnoreCase);
#pragma warning restore CA1309

        // Assert
        await Expect.That(ordinal).IsNotEqualTo(currentCulture).Because("Turkish distinguishes between a dotted and a non-dotted 'i'");
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_the_same_digit_from_different_cultures_they_should_be_equal(string subject, string expected)
    {
        // Act
        bool ordinal = string.Equals(subject, expected, StringComparison.Ordinal);
#pragma warning disable CA1309 // Verifies that test data behaves differently in current vs invariant culture
        bool currentCulture = string.Equals(subject, expected, StringComparison.CurrentCulture);
#pragma warning restore CA1309

        // Assert
        await Expect.That(ordinal).IsNotEqualTo(currentCulture).Because("These two symbols happened to be culturewise identical on both ICU (net5.0, linux, macOS) and NLS (netfx and netcoreapp on windows)");
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_equivalency_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEquivalentTo(expected));

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_equality_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_having_prefix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).StartsWith(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_not_having_prefix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).DoesNotStartWith(expected));

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_having_equivalent_prefix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().StartWithEquivalentOf(expected);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_not_having_equivalent_prefix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().NotStartWithEquivalentOf(expected);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_having_suffix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).EndsWith(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_not_having_suffix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).DoesNotEndWith(expected));

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_having_equivalent_suffix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().EndWithEquivalentOf(expected);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_not_having_equivalent_suffix_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().NotEndWithEquivalentOf(expected);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_containing_equivalent_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().ContainEquivalentOf(expected);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_not_containing_equivalent_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().NotContainEquivalentOf(expected);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_containing_equal_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).Contains(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_containing_all_equals_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().ContainAll(expected);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_containing_any_equals_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().ContainAny(expected);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_containing_one_equal_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).Contains(expected).Exactly(1));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public async Task When_comparing_strings_for_containing_one_equivalent_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().ContainEquivalentOf(expected, Exactly.Once());

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_not_containing_equal_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).DoesNotContain(expected));

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_not_containing_all_equals_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().NotContainAll(expected);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EqualityData))]
    public async Task When_comparing_strings_for_not_containing_any_equals_it_should_ignore_culture(string subject, string expected)
    {
        // Act
        Action act = () => subject.Should().NotContainAny(expected);

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [CulturedFact("tr-TR")]
    public async Task When_formatting_reason_arguments_it_should_ignore_culture()
    {
        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(1).IsEqualTo(2).Because($"{1.234}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedFact("tr-TR")]
    public void When_stringifying_an_object_it_should_ignore_culture()
    {
        // Arrange
        var obj = new ObjectReference(1.234, string.Empty);

        // Act
        var str = obj.ToString();

        // Assert
        str.Should().Match("*1.234*", "it should always use . as decimal separator");
    }

    [CulturedFact("tr-TR")]
    public void When_stringifying_a_validation_context_it_should_ignore_culture()
    {
        // Arrange
        var comparands = new Comparands
        {
            Subject = 1.234,
            Expectation = 5.678
        };

        // Act
        var str = comparands.ToString();

        // Assert
        str.Should().Match("*1.234*5.678*", "it should always use . as decimal separator");
    }

    [CulturedFact("tr-TR")]
    public async Task When_formatting_the_context_it_should_ignore_culture()
    {
        // Arrange
        var context = new Dictionary<string, object>
        {
            ["FOO"] = 1.234
        };

        var strategy = new CollectingAssertionStrategy();
        strategy.HandleFailure(string.Empty);

        // Act
        Action act = () => strategy.ThrowIfAny(context);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [CulturedTheory("tr-TR")]
    [MemberData(nameof(EquivalencyData))]
    public void Matching_strings_for_equivalence_ignores_the_culture(string subject, string expected)
    {
        // Assert
        subject.Should().MatchEquivalentOf(expected);
    }

    [CulturedFact("en-US")]
    public void Culture_is_ignored_when_sorting_strings()
    {
        using var _ = new AssertionScope();

        new[] { "A", "a" }.Should().BeInAscendingOrder()
            .And.BeInAscendingOrder(e => e)
            .And.ThenBeInAscendingOrder(e => e)
            .And.NotBeInDescendingOrder()
            .And.NotBeInDescendingOrder(e => e);

        new[] { "a", "A" }.Should().BeInDescendingOrder()
            .And.BeInDescendingOrder(e => e)
            .And.ThenBeInDescendingOrder(e => e)
            .And.NotBeInAscendingOrder()
            .And.NotBeInAscendingOrder(e => e);
    }

    private const string LowerCaseI = "i";
    private const string UpperCaseI = "I";

    public static TheoryData<string, string> EquivalencyData => new()
    {
        { LowerCaseI, UpperCaseI }
    };

    private const string SinhalaLithDigitEight = "෮";
    private const string MyanmarTaiLaingDigitEight = "꧸";

    public static TheoryData<string, string> EqualityData => new()
    {
        { SinhalaLithDigitEight, MyanmarTaiLaingDigitEight }
    };
}

// Due to CulturedTheory changing CultureInfo
[CollectionDefinition(nameof(StringComparisonSpecs), DisableParallelization = true)]
public class StringComparisonDefinition;

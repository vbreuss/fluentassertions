﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions.Xml.Equivalency;

namespace FluentAssertions.Xml;

/// <summary>
/// Contains a number of methods to assert that an <see cref="XElement"/> is in the expected state.
/// </summary>
[DebuggerNonUserCode]
public class XElementAssertions : ReferenceTypeAssertions<XElement, XElementAssertions>
{
    private readonly AssertionChain assertionChain;

    /// <summary>
    /// Initializes a new instance of the <see cref="XElementAssertions" /> class.
    /// </summary>
    public XElementAssertions(XElement xElement, AssertionChain assertionChain)
        : base(xElement, assertionChain)
    {
        this.assertionChain = assertionChain;
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> equals the
    /// <paramref name="expected"/> element, by using
    /// <see cref="XNode.DeepEquals(XNode, XNode)"/>
    /// </summary>
    /// <param name="expected">The expected element</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<XElementAssertions> Be(XElement expected,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        assertionChain
            .ForCondition(XNode.DeepEquals(Subject, expected))
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context:subject} to be {0}{reason}, but found {1}.", expected, Subject);

        return new AndConstraint<XElementAssertions>(this);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> does not equal the
    /// <paramref name="unexpected"/> element, using
    /// <see cref="XNode.DeepEquals(XNode, XNode)" />.
    /// </summary>
    /// <param name="unexpected">The unexpected element</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<XElementAssertions> NotBe(XElement unexpected,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        assertionChain
            .ForCondition((Subject is null && unexpected is not null) || !XNode.DeepEquals(Subject, unexpected))
            .BecauseOf(because, becauseArgs)
            .FailWith("Did not expect {context:subject} to be {0}{reason}.", unexpected);

        return new AndConstraint<XElementAssertions>(this);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> is equivalent to the
    /// <paramref name="expected"/> element, using a semantic equivalency
    /// comparison.
    /// </summary>
    /// <param name="expected">The expected element</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<XElementAssertions> BeEquivalentTo(XElement expected,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        using (XmlReader subjectReader = Subject?.CreateReader())
        using (XmlReader expectedReader = expected?.CreateReader())
        {
            var xmlReaderValidator = new XmlReaderValidator(assertionChain, subjectReader, expectedReader, because, becauseArgs);
            xmlReaderValidator.Validate(shouldBeEquivalent: true);
        }

        return new AndConstraint<XElementAssertions>(this);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> is not equivalent to
    /// the <paramref name="unexpected"/> element, using a semantic
    /// equivalency comparison.
    /// </summary>
    /// <param name="unexpected">The unexpected element</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<XElementAssertions> NotBeEquivalentTo(XElement unexpected,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        using (XmlReader subjectReader = Subject?.CreateReader())
        using (XmlReader otherReader = unexpected?.CreateReader())
        {
            var xmlReaderValidator = new XmlReaderValidator(assertionChain, subjectReader, otherReader, because, becauseArgs);
            xmlReaderValidator.Validate(shouldBeEquivalent: false);
        }

        return new AndConstraint<XElementAssertions>(this);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> has the specified <paramref name="expected"/> value.
    /// </summary>
    /// <param name="expected">The expected value</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    public AndConstraint<XElementAssertions> HaveValue(string expected,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        assertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null)
            .FailWith("Expected the element to have value {0}{reason}, but {context:member} is <null>.", expected);

        if (assertionChain.Succeeded)
        {
            assertionChain
                .ForCondition(Subject!.Value == expected)
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:subject} '{0}' to have value {1}{reason}, but found {2}.",
                    Subject.Name, expected, Subject.Value);
        }

        return new AndConstraint<XElementAssertions>(this);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> has an attribute with the specified <paramref name="expectedName"/>
    /// and <paramref name="expectedValue"/>.
    /// </summary>
    /// <param name="expectedName">The name of the expected attribute</param>
    /// <param name="expectedValue">The value of the expected attribute</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="expectedName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="expectedName"/> is empty.</exception>
    public AndConstraint<XElementAssertions> HaveAttribute(string expectedName, string expectedValue,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        Guard.ThrowIfArgumentIsNullOrEmpty(expectedName);

        return HaveAttribute(XNamespace.None + expectedName, expectedValue, because, becauseArgs);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> has an attribute with the specified <paramref name="expectedName"/>
    /// and <paramref name="expectedValue"/>.
    /// </summary>
    /// <param name="expectedName">The name <see cref="XName"/> of the expected attribute</param>
    /// <param name="expectedValue">The value of the expected attribute</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="expectedName"/> is <see langword="null"/>.</exception>
    public AndConstraint<XElementAssertions> HaveAttribute(XName expectedName, string expectedValue,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        Guard.ThrowIfArgumentIsNull(expectedName);

        string expectedText = expectedName.ToString();

        assertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null)
            .FailWith(
                "Expected attribute {0} in element to have value {1}{reason}, but {context:member} is <null>.",
                expectedText, expectedValue);

        if (assertionChain.Succeeded)
        {
            XAttribute attribute = Subject!.Attribute(expectedName);

            assertionChain
                .ForCondition(attribute is not null)
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:subject} to have attribute {0} with value {1}{reason},"
                    + " but found no such attribute in {2}",
                    expectedText, expectedValue, Subject);

            if (assertionChain.Succeeded)
            {
                assertionChain
                    .ForCondition(attribute!.Value == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith(
                        "Expected attribute {0} in {context:subject} to have value {1}{reason}, but found {2}.",
                        expectedText, expectedValue, attribute.Value);
            }
        }

        return new AndConstraint<XElementAssertions>(this);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> has a direct child element with the specified
    /// <paramref name="expected"/> name.
    /// </summary>
    /// <param name="expected">The name <see cref="XName"/> of the expected child element</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="expected"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="expected"/> is empty.</exception>
    public AndWhichConstraint<XElementAssertions, XElement> HaveElement(string expected,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        Guard.ThrowIfArgumentIsNullOrEmpty(expected);

        return HaveElement(XNamespace.None + expected, because, becauseArgs);
    }

    /// <summary>
    /// Asserts that the current <see cref="XElement"/> has a direct child element with the specified
    /// <paramref name="expected"/> name.
    /// </summary>
    /// <param name="expected">The name <see cref="XName"/> of the expected child element</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="expected"/> is <see langword="null"/>.</exception>
    public AndWhichConstraint<XElementAssertions, XElement> HaveElement(XName expected,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        Guard.ThrowIfArgumentIsNull(expected);

        assertionChain
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null)
            .FailWith(
                "Expected the element to have child element {0}{reason}, but {context:member} is <null>.",
                expected.ToString().EscapePlaceholders());

        XElement xElement = null;

        if (assertionChain.Succeeded)
        {
            xElement = Subject!.Element(expected);

            assertionChain
                .ForCondition(xElement is not null)
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:subject} to have child element {0}{reason}, but no such child element was found.",
                    expected.ToString().EscapePlaceholders());
        }

        return new AndWhichConstraint<XElementAssertions, XElement>(this, xElement, assertionChain, "/" + expected);
    }

    /// <summary>
    /// Asserts that the <see cref="XElement"/> of the current <see cref="XElement"/> has the specified occurrence of
    /// child elements with the specified <paramref name="expected"/> name.
    /// </summary>
    /// <param name="expected">
    /// The full name <see cref="XName"/> of the expected child element of the current element's <see cref="XElement"/>.
    /// </param>
    /// <param name="occurrenceConstraint">
    /// A constraint specifying the number of times the specified elements should appear.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="expected"/> is <see langword="null"/>.</exception>
    public AndWhichConstraint<XElementAssertions, IEnumerable<XElement>> HaveElement(XName expected,
        OccurrenceConstraint occurrenceConstraint,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        Guard.ThrowIfArgumentIsNull(expected, nameof(expected),
            "Cannot assert the element has an element count if the element name is <null>.");

        assertionChain
            .ForCondition(Subject is not null)
            .BecauseOf(because, becauseArgs)
            .FailWith(
                "Expected {context:subject} to have an element with count of {0}{reason}, but the element itself is <null>.",
                expected.ToString());

        IEnumerable<XElement> xElements = [];

        if (assertionChain.Succeeded)
        {
            xElements = Subject!.Elements(expected);
            int actual = xElements.Count();

            assertionChain
                .ForConstraint(occurrenceConstraint, actual)
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:subject} to have an element {0} {expectedOccurrence}" +
                    $"{{reason}}, but found it {actual.Times()}.",
                    expected.ToString());
        }

        return new AndWhichConstraint<XElementAssertions, IEnumerable<XElement>>(this, xElements, assertionChain, "/" + expected);
    }

    /// <summary>
    /// Asserts that the <see cref="XElement"/> of the current <see cref="XElement"/> has the specified occurrence of
    /// child elements with the specified <paramref name="expected"/> name.
    /// </summary>
    /// <param name="expected">
    /// The name of the expected child element of the current element's <see cref="XElement"/>.
    /// </param>
    /// <param name="occurrenceConstraint">
    /// A constraint specifying the number of times the specified elements should appear.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="expected"/> is <see langword="null"/>.</exception>
    public AndWhichConstraint<XElementAssertions, IEnumerable<XElement>> HaveElement(string expected,
        OccurrenceConstraint occurrenceConstraint,
        [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        Guard.ThrowIfArgumentIsNull(expected, nameof(expected),
            "Cannot assert the element has an element if the expected name is <null>.");

        return HaveElement(XNamespace.None + expected, occurrenceConstraint, because, becauseArgs);
    }

    /// <summary>
    /// Returns the type of the subject the assertion applies on.
    /// </summary>
    protected override string Identifier => "XML element";
}

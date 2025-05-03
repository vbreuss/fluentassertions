﻿using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Formatting;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Formatting;

public class PredicateLambdaExpressionValueFormatterSpecs
{
    private readonly PredicateLambdaExpressionValueFormatter formatter = new();

    [Fact]
    public async Task Constructor_expression_with_argument_can_be_formatted()
    {
        // Arrange
        Expression expression = (string arg) => new TestItem { Value = arg };

        // Act
        string result = Formatter.ToString(expression);

        // Assert
        await Expect.That(result).IsEqualTo("new TestItem() {Value = arg}");
    }

    [Fact]
    public async Task Constructor_expression_can_be_simplified()
    {
        // Arrange
        string value = "foo";
        Expression expression = () => new TestItem { Value = value };

        // Act
        string result = Formatter.ToString(expression);

        // Assert
        await Expect.That(result).IsEqualTo("new TestItem() {Value = \"foo\"}");
    }

    private sealed class TestItem
    {
        public string Value { get; set; }
    }

    [Fact]
    public async Task When_first_level_properties_are_tested_for_equality_against_constants_then_output_should_be_readable()
    {
        // Act
        string result = Format(a => a.Text == "foo" && a.Number == 123);

        // Assert
        await Expect.That(result).IsEqualTo("(a.Text == \"foo\") AndAlso (a.Number == 123)");
    }

    [Fact]
    public async Task When_first_level_properties_are_tested_for_equality_against_constant_expressions_then_output_should_contain_values_of_constant_expressions()
    {
        // Arrange
        var expectedText = "foo";
        var expectedNumber = 123;

        // Act
        string result = Format(a => a.Text == expectedText && a.Number == expectedNumber);

        // Assert
        await Expect.That(result).IsEqualTo("(a.Text == \"foo\") AndAlso (a.Number == 123)");
    }

    [Fact]
    public async Task When_more_than_two_conditions_are_joined_with_and_operator_then_output_should_not_have_nested_parenthesis()
    {
        // Act
        string result = Format(a => a.Text == "123" && a.Number >= 0 && a.Number <= 1000);

        // Assert
        await Expect.That(result).IsEqualTo("(a.Text == \"123\") AndAlso (a.Number >= 0) AndAlso (a.Number <= 1000)");
    }

    [Fact]
    public async Task When_condition_contains_extension_method_then_extension_method_must_be_formatted()
    {
        // Act
        string result = Format(a => a.TextIsNotBlank() && a.Number >= 0 && a.Number <= 1000);

        // Assert
        await Expect.That(result).IsEqualTo("a.TextIsNotBlank() AndAlso (a.Number >= 0) AndAlso (a.Number <= 1000)");
    }

    [Fact]
    public async Task When_condition_contains_linq_extension_method_then_extension_method_must_be_formatted()
    {
        // Arrange
        int[] allowed = [1, 2, 3];

        // Act
        string result = Format<int>(a => allowed.Contains(a));

        // Assert
        await Expect.That(result).IsEqualTo("value(System.Int32[]).Contains(a)");
    }

    [Fact]
    public async Task Formatting_a_lifted_binary_operator()
    {
        // Arrange
        var subject = new ClassWithNullables { Number = 42 };

        // Act
        Action act = () => subject.Should().Match<ClassWithNullables>(e => e.Number > 43);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    private string Format(Expression<Func<SomeClass, bool>> expression) => Format<SomeClass>(expression);

    private string Format<T>(Expression<Func<T, bool>> expression)
    {
        var graph = new FormattedObjectGraph(maxLines: 100);

        formatter.Format(expression, graph, new FormattingContext(), null);

        return graph.ToString();
    }
}

internal class ClassWithNullables
{
    public int? Number { get; set; }
}

internal class SomeClass
{
    public string Text { get; set; }

    public int Number { get; set; }
}

internal static class SomeClassExtensions
{
    public static bool TextIsNotBlank(this SomeClass someObject) => !string.IsNullOrWhiteSpace(someObject.Text);
}

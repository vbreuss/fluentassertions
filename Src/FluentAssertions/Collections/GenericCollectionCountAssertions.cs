using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Collections;

[DebuggerNonUserCode]
public class GenericCollectionCountAssertions<TAssertions, TCollection, T>
    : ReferenceTypeAssertions<TCollection, TAssertions>
    where TAssertions : GenericCollectionAssertions<TCollection, T, TAssertions>
    where TCollection : IEnumerable<T>
{
    private readonly TAssertions parentAssertions;
    private readonly GenericCollectionCount expectationCount;

    internal GenericCollectionCountAssertions(TAssertions parentAssertions, TCollection actualValue, GenericCollectionCount expectationCount)
        : base(actualValue)
    {
        this.parentAssertions = parentAssertions;
        this.expectationCount = expectationCount;
    }

    /// <summary>
    /// Returns the type of the subject the assertion applies on.
    /// </summary>
    protected override string Identifier => "collection";

    public AndConstraint<TAssertions> Items([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        bool success = Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null)
            .FailWith("Expected {context:collection} to have {0} item(s){reason}, but found <null>.", expectationCount);

        if (success)
        {
            int actualCount = Subject!.Count();

            Execute.Assertion
                .ForCondition(expectationCount.IsSatisfiedBy(actualCount))
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:collection} to have {0} item(s){reason}, but found {1}: {2}.",
                    expectationCount, actualCount, Subject);
        }

        return new AndConstraint<TAssertions>(parentAssertions);
    }

    public AndConstraint<TAssertions> ItemsMatching(Expression<Func<T, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        bool success = Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null)
            .FailWith("Expected {context:collection} to have {0} item(s) matching {1}{reason}, but found <null>.", expectationCount, predicate);

        if (success)
        {
            Func<T, bool> compiledPredicate = predicate.Compile();
            var filtered = Subject!.Where(compiledPredicate).ToArray();
            int actualCount = filtered.Length;

            Execute.Assertion
                .ForCondition(expectationCount.IsSatisfiedBy(actualCount))
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:collection} to have {0} item(s) matching {1}{reason}, but found {2} of {3}: {4}.",
                    expectationCount, predicate, actualCount, Subject!.Count(), filtered);
        }

        return new AndConstraint<TAssertions>(parentAssertions);
    }

    public AndConstraint<TAssertions> ItemsOfType<TType>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        bool success = Execute.Assertion
            .BecauseOf(because, becauseArgs)
        .ForCondition(Subject is not null)
            .FailWith("Expected {context:collection} to have {0} item(s) of type {1}{reason}, but found <null>.", expectationCount, typeof(TType).Name);

        if (success)
        {
            int actualCount = Subject!.OfType<TType>().Count();

            Execute.Assertion
                .ForCondition(expectationCount.IsSatisfiedBy(actualCount))
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:collection} to have {0} item(s) of type {1}{reason}, but found {2}: {3}.",
                    expectationCount, typeof(TType).Name, actualCount, Subject);
        }

        return new AndConstraint<TAssertions>(parentAssertions);
    }

    public AndConstraint<TAssertions> ItemsOfTypeMatching<TType>(Expression<Func<TType, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
    {
        bool success = Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(Subject is not null)
            .FailWith("Expected {context:collection} to have {0} item(s) of type {1} matching {2}{reason}, but found <null>.", expectationCount, typeof(TType).Name, predicate);

        if (success)
        {
            Func<TType, bool> compiledPredicate = predicate.Compile();
            var filtered = Subject!.OfType<TType>().Where(compiledPredicate).ToArray();
            int actualCount = filtered.Length;

            Execute.Assertion
                .ForCondition(expectationCount.IsSatisfiedBy(actualCount))
                .BecauseOf(because, becauseArgs)
                .FailWith(
                    "Expected {context:collection} to have {0} item(s) of type {1} matching {2}{reason}, but found {3} of {4}: {5}.",
                    expectationCount, typeof(TType).Name, predicate, actualCount, Subject.Count(), filtered);
        }

        return new AndConstraint<TAssertions>(parentAssertions);
    }
}

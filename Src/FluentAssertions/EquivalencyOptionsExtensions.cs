using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Equivalency.Matching;
using FluentAssertions.Equivalency.Ordering;
using FluentAssertions.Equivalency.Selection;
using FluentAssertions.Equivalency.Steps;
using FluentAssertions.Equivalency.Tracing;

namespace FluentAssertions;

#pragma warning disable CA1033 //An unsealed externally visible type provides an explicit method implementation of a public interface and does not provide an alternative externally visible method that has the same name.

/// <summary>
/// Represents the run-time behavior of a structural equivalency assertion.
/// </summary>
public static class EquivalencyOptionsExtensions
{
    public static EquivalencyOptions<double> WithTolerance(this EquivalencyOptions<double> options, double tolerance)
    {
        return options.Using(new ApproximatelyComparer(tolerance));
    }

    public static EquivalencyOptions<float> WithTolerance(this EquivalencyOptions<float> options, float tolerance)
    {
        return options.Using(new ApproximatelyComparer(tolerance));
    }

    public static EquivalencyOptions<decimal> WithTolerance(this EquivalencyOptions<decimal> options, decimal tolerance)
    {
        return options.Using(new ApproximatelyDecimalComparer(tolerance));
    }

    private class ApproximatelyDecimalComparer : IEqualityComparer<decimal>
    {
        private readonly decimal tolerance;

        public ApproximatelyDecimalComparer(decimal tolerance)
        {
            this.tolerance = tolerance;
        }

        public bool Equals(decimal x, decimal y)
        {
            return Math.Abs(x - y) < tolerance;
        }

        public int GetHashCode(decimal obj)
        {
            return obj.GetHashCode();
        }
    }

    private class ApproximatelyComparer : IEqualityComparer<double>
    {
        private readonly double tolerance;

        public ApproximatelyComparer(double tolerance)
        {
            this.tolerance = tolerance;
        }

        public bool Equals(double x, double y)
        {
            return Math.Abs(x - y) < tolerance;
        }

        public int GetHashCode(double obj)
        {
            return obj.GetHashCode();
        }
    }
}

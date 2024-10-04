namespace FluentAssertions.Collections;

internal abstract class GenericCollectionCount
{
    internal class Exactly : GenericCollectionCount
    {
        public int Count { get; }

        public Exactly(int count)
        {
            Count = count;
        }

        public override bool IsSatisfiedBy(int actualCount)
            => actualCount == Count;

        public override string ToString() => $"exactly {Count}";
    }

    internal class AtLeast : GenericCollectionCount
    {
        public int Minimum { get; }

        public AtLeast(int minimum)
        {
            Minimum = minimum;
        }

        public override bool IsSatisfiedBy(int actualCount)
            => actualCount >= Minimum;

        public override string ToString() => $"at least {Minimum}";
    }

    internal class Between : GenericCollectionCount
    {
        public int Minimum { get; }

        public int Maximum { get; }

        public Between(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public override bool IsSatisfiedBy(int actualCount)
            => actualCount >= Minimum &&
                actualCount <= Maximum;

        public override string ToString() => $"between {Minimum} and {Maximum}";
    }

    internal class AtMost : GenericCollectionCount
    {
        public int Maximum { get; }

        public AtMost(int maximum)
        {
            Maximum = maximum;
        }

        public override bool IsSatisfiedBy(int actualCount)
            => actualCount <= Maximum;

        public override string ToString() => $"at most {Maximum}";
    }

    public abstract bool IsSatisfiedBy(int actualCount);
}

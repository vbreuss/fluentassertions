using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]Contain specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class Contain
    {
        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_string_contains_the_expected_string_it_should_not_throw()
        {
            // Arrange
            string actual = "ABCDEF";
            string expectedSubstring = "BCD";

            // Act / Assert
            await Expect.That(actual).Contains(expectedSubstring);
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_string_does_not_contain_an_expected_string_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABCDEF").Contains("XYZ").Because($"that is {"required"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_containment_is_asserted_against_null_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("a").Contains(null));

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_containment_is_asserted_against_an_empty_string_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("a").Contains(""));

            // Assert
            await Expect.That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_string_containment_is_asserted_and_actual_value_is_null_then_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someString).Contains("XYZ").Because($"that is {"required"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        public class ContainExactly
        {
            [Fact]
            public async Task When_string_containment_once_is_asserted_and_actual_value_does_not_contain_the_expected_string_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEF";
                string expectedSubstring = "XYS";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Exactly(1.Times()));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_containment_once_is_asserted_against_null_it_should_throw_earlier()
            {
                // Arrange
                string actual = "a";
                string expectedSubstring = null;

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Exactly(1.Times()));

                // Assert
                await Expect.That(act).Throws<ArgumentNullException>();
            }

            [Fact]
            public async Task When_string_containment_once_is_asserted_and_actual_value_is_null_then_it_should_throw()
            {
                // Arrange
                string actual = null;
                string expectedSubstring = "XYZ";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Exactly(1.Times()));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_string_containment_exactly_is_asserted_and_expected_value_is_negative_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Exactly(-1));

                // Assert
                await Expect.That(act).Throws<ArgumentOutOfRangeException>();
            }

            [Fact]
            public async Task When_string_containment_exactly_is_asserted_and_actual_value_contains_the_expected_string_exactly_expected_times_it_should_not_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Exactly(2.Times()));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }

            [Fact]
            public async Task When_string_containment_exactly_is_asserted_and_actual_value_contains_the_expected_string_but_not_exactly_expected_times_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Exactly(3.Times()));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }
        }

        public class ContainAtLeast
        {
            [Fact]
            public async Task When_string_containment_at_least_is_asserted_and_actual_value_contains_the_expected_string_at_least_expected_times_it_should_not_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtLeast(2.Times()));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }

            [Fact]
            public async Task When_string_containment_at_least_is_asserted_and_actual_value_contains_the_expected_string_but_not_at_least_expected_times_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtLeast(3.Times()));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_string_containment_at_least_once_is_asserted_and_actual_value_does_not_contain_the_expected_string_it_should_throw_earlier()
            {
                // Arrange
                string actual = "ABCDEF";
                string expectedSubstring = "XYS";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtLeast(1));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_string_containment_at_least_once_is_asserted_and_actual_value_is_null_then_it_should_throw()
            {
                // Arrange
                string actual = null;
                string expectedSubstring = "XYZ";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtLeast(1));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }
        }

        /* TODO VAB
        public class ContainMoreThan
        {
            [Fact]
            public async Task When_string_containment_more_than_is_asserted_and_actual_value_contains_the_expected_string_more_than_expected_times_it_should_not_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(MoreThan.Times(1)));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }

            [Fact]
            public async Task When_string_containment_more_than_is_asserted_and_actual_value_contains_the_expected_string_but_not_more_than_expected_times_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(MoreThan.Times(2)));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_string_containment_more_than_once_is_asserted_and_actual_value_does_not_contain_the_expected_string_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEF";
                string expectedSubstring = "XYS";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(MoreThan.Once()));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_string_containment_more_than_once_is_asserted_and_actual_value_is_null_then_it_should_throw()
            {
                // Arrange
                string actual = null;
                string expectedSubstring = "XYZ";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(MoreThan.Once()));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }
        }
        */

        public class ContainAtMost
        {
            [Fact]
            public async Task When_string_containment_at_most_is_asserted_and_actual_value_contains_the_expected_string_at_most_expected_times_it_should_not_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtMost(2.Times()));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }

            [Fact]
            public async Task When_string_containment_at_most_is_asserted_and_actual_value_contains_the_expected_string_but_not_at_most_expected_times_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtMost(1.Times()));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_string_containment_at_most_once_is_asserted_and_actual_value_does_not_contain_the_expected_string_it_should_not_throw()
            {
                // Arrange
                string actual = "ABCDEF";
                string expectedSubstring = "XYS";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtMost(1.Times()));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }

            [Fact]
            public async Task When_string_containment_at_most_once_is_asserted_and_actual_value_is_null_then_it_should_not_throw()
            {
                // Arrange
                string actual = null;
                string expectedSubstring = "XYZ";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).AtMost(1.Times()));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }
        }

        /* TODO VAB
        public class ContainsLessThan
        {
            [Fact]
            public async Task When_string_containment_less_than_is_asserted_and_actual_value_contains_the_expected_string_less_than_expected_times_it_should_not_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(LessThan.Times(3)));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }

            [Fact]
            public async Task When_string_containment_less_than_is_asserted_and_actual_value_contains_the_expected_string_but_not_less_than_expected_times_it_should_throw()
            {
                // Arrange
                string actual = "ABCDEBCDF";
                string expectedSubstring = "BCD";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(LessThan.Times(2)));

                // Assert
                await Expect.That(act).Throws<XunitException>();
            }

            [Fact]
            public async Task When_string_containment_less_than_twice_is_asserted_and_actual_value_does_not_contain_the_expected_string_it_should_not_throw()
            {
                // Arrange
                string actual = "ABCDEF";
                string expectedSubstring = "XYS";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(LessThan.Twice()));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }

            [Fact]
            public async Task When_string_containment_less_than_once_is_asserted_and_actual_value_is_null_then_it_should_not_throw()
            {
                // Arrange
                string actual = null;
                string expectedSubstring = "XYZ";

                // Act
                Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).Contains(expectedSubstring).Because(LessThan.Twice()));

                // Assert
                await Expect.That(act).DoesNotThrow();
            }
        }
        */
    }

    public class NotContain
    {
        [Fact]
        public async Task When_string_does_not_contain_the_unexpected_string_it_should_succeed()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("a").DoesNotContain("A"));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_string_contains_unexpected_fragment_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("abcd").DoesNotContain("bc").Because($"it was not expected {"today"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_exclusion_is_asserted_against_null_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("a").DoesNotContain(null));

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_exclusion_is_asserted_against_an_empty_string_it_should_throw()
        {
            // Act
            Func<Task> act = async () => await Expect.That("a").DoesNotContain("");

            // Assert
            await Expect.That(act).Throws<ArgumentException>();
        }
    }
}

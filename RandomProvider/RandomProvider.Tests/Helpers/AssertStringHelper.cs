using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.Tests.Helpers
{
    internal static class AssertStringHelper
    {
        internal static void AssertLength(int expectedLength, string actualString, string? message = null)
        {
            if (actualString == null)
                throw new AssertionException($"Assert! Actual string value is null while expected length {expectedLength}.");

            if (actualString.Length != expectedLength)
                throw new AssertionException(message ?? $"Assert! Actual string value has length {actualString.Length} while expected length {expectedLength}. ");
        }

        internal static void AssertLength(int expectedMinLength, int expectedMaxLength, string actualString, string? message = null)
        {
            if (actualString == null)
                throw new AssertionException($"Assert! Actual string value is null while expected length in the range [{expectedMinLength} .. {expectedMaxLength}].");

            if (actualString.Length < expectedMinLength || actualString.Length > expectedMaxLength)
                throw new AssertionException(message ?? $"Assert! Actual string value has length {actualString.Length} while expected length in the range [{expectedMinLength} .. {expectedMaxLength}].");
        }

        internal static void AssertSymbolsFromArray(IEnumerable<char> expectedChars, string actualString, string? message = null)
        {
            foreach (char item in actualString.ToCharArray())
            {
                if (!expectedChars.Contains(item))
                    throw new AssertionException(message ?? $"Assert! Actual string value contains unexpected symbol({item}).");
            }
        }

    }
}

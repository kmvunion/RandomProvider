using KMVUnion.RandomProvider.TextRandomizer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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


        internal static void AssertAlign(string actualString, TextAlign expectedAlign, string? message = null)
        {
            if (actualString == null)
                throw new AssertionException($"Assert! Actual string value is null while expected align {expectedAlign}.");
            char first = actualString[0];
            char last = actualString[actualString.Length - 1];
            var exception = new AssertionException(message ?? $"Assert! Actual string value has not expected align {expectedAlign}. [{actualString}]");

            switch (expectedAlign)
            {
                case TextAlign.Left:
                    if ((first == ' ' && last != ' ') || (first == ' ' && last == ' ')) throw exception; break;
                case TextAlign.Right:
                    if ((first != ' ' && last == ' ') || (first == ' ' && last == ' ')) throw exception; break;
                case TextAlign.Center:
                    if (first == ' ' && last != ' ') throw exception; break;
                case TextAlign.Justify:
                    if (first == ' ' && last != ' ') throw exception; break;
            }
        }

    }
}

using KMVUnion.RandomProvider.StringRandomizer;
using NUnit.Framework;
using RandomProvider.Tests.Helpers;
using System;
using System.Linq;

namespace RandomProvider.Tests.StringRandomizer
{
    [TestFixture]
    public class StringRandomizerTests
    {
        private StringRandomizerBuilder? _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new StringRandomizerBuilder();
        }

        [Test]
        [Repeat(1000)]
        public void GetValue_ConfiguredLowerCase_Success()
        {
            //Arrange                        
            char[] expectdUsedSymbols = { 'a', 'B', 'C', 'd' };
            string expectedUseString = "eFgh";

            char[] expectdDontUsedSymbols = { 'c', 'd' };
            string expectedDontUseString = "fg";

            int expectdExectLength = 1000;

            char[] expectdtemplates = { 'a', 'b', 'e', 'h' };

            SymbolCases expectedSymbolCases = SymbolCases.Lower;

            var randomizer = _builder?
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithExactLength(expectdExectLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Act
            var generatedValueRandomizer = randomizer?.GetValue();

            //Assert
            Assert.IsNotNull(generatedValueRandomizer);
            AssertStringHelper.AssertLength(expectdExectLength, generatedValueRandomizer);
            AssertStringHelper.AssertSymbolsFromArray(expectdtemplates, generatedValueRandomizer);
        }

        [Test]
        [Repeat(1000)]
        public void GetValue_ConfiguredUpperCase_Success()
        {
            //Arrange                        
            char[] expectdUsedSymbols = { 'A', 'b', 'c', 'D' };
            string expectedUseString = "eFgh";

            char[] expectdDontUsedSymbols = { 'C', 'D' };
            string expectedDontUseString = "FG";

            int expectdExectLength = 1000;

            char[] expectdtemplates = { 'A', 'B', 'E', 'H' };

            SymbolCases expectedSymbolCases = SymbolCases.Upper;

            var randomizer = _builder?
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithExactLength(expectdExectLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Act
            var generatedValueRandomizer = randomizer?.GetValue();

            //Assert
            Assert.IsNotNull(generatedValueRandomizer);
            AssertStringHelper.AssertLength(expectdExectLength, generatedValueRandomizer);
            AssertStringHelper.AssertSymbolsFromArray(expectdtemplates, generatedValueRandomizer);
        }

        [Test]
        [Repeat(1000)]
        public void GetValue_ConfiguredNoneCase_Success()
        {
            //Arrange                        
            char[] expectdUsedSymbols = { 'A', 'b', 'c', 'D' };
            string expectedUseString = "eFgh";

            char[] expectdDontUsedSymbols = { 'C', 'D' };
            string expectedDontUseString = "FG";

            int expectdExectLength = 1000;

            char[] expectdtemplates = { 'A', 'b', 'c', 'e', 'g', 'h' };

            SymbolCases expectedSymbolCases = SymbolCases.None;

            var randomizer = _builder?
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithExactLength(expectdExectLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Act
            var generatedValueRandomizer = randomizer?.GetValue();

            //Assert
            Assert.IsNotNull(generatedValueRandomizer);
            AssertStringHelper.AssertLength(expectdExectLength, generatedValueRandomizer);
            AssertStringHelper.AssertSymbolsFromArray(expectdtemplates, generatedValueRandomizer);
        }

        [Test]
        [Repeat(1000)]
        public void GetValue_ConfiguredNoneCaseWithMixLength_Success()
        {
            //Arrange                        
            char[] expectdUsedSymbols = { 'A', 'b', 'c', 'D' };
            string expectedUseString = "eFgh";

            char[] expectdDontUsedSymbols = { 'C', 'D' };
            string expectedDontUseString = "FG";

            int expectdMintLength = 100;
            int expectdMaxLength = 200;

            char[] expectdtemplates = { 'A', 'b', 'c', 'e', 'g', 'h' };

            SymbolCases expectedSymbolCases = SymbolCases.None;

            var randomizer = _builder?
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithMinLength(expectdMintLength)
                            .WithMaxLength(expectdMaxLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Act
            var generatedValueRandomizer = randomizer?.GetValue();

            //Assert
            Assert.IsNotNull(generatedValueRandomizer);
            AssertStringHelper.AssertLength(expectdMintLength, expectdMaxLength, generatedValueRandomizer);
            AssertStringHelper.AssertSymbolsFromArray(expectdtemplates, generatedValueRandomizer);
        }

        [Test]
        public void GetValues_Configured_Success()
        {
            //Arrange                        
            char[] expectdUsedSymbols = { 'A', 'b', 'c', 'D' };
            string expectedUseString = "eFgh";

            char[] expectdDontUsedSymbols = { 'C', 'D' };
            string expectedDontUseString = "FG";

            int expectdMintLength = 100;
            int expectdMaxLength = 200;

            char[] expectdtemplates = { 'A', 'b', 'c', 'e', 'g', 'h' };

            int expectedCollectionCount = 100;

            SymbolCases expectedSymbolCases = SymbolCases.None;

            var randomizer = _builder?
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithMinLength(expectdMintLength)
                            .WithMaxLength(expectdMaxLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Act
            var generatedValueCollectionRandomizer = randomizer?.GetValues(expectedCollectionCount);

            //Assert
            Assert.IsNotNull(generatedValueCollectionRandomizer);
            generatedValueCollectionRandomizer.All(x =>
                {
                    AssertStringHelper.AssertLength(expectdMintLength, expectdMaxLength, x);
                    AssertStringHelper.AssertSymbolsFromArray(expectdtemplates, x);
                    return true;
                });
        }

        [Test]        
        public void GetValues_ConfiguredIncorrectMixLength_ThrowedException()
        {
            //Arrange                        
            char[] expectdUsedSymbols = { 'A', 'b', 'c', 'D' };
            string expectedUseString = "eFgh";

            char[] expectdDontUsedSymbols = { 'C', 'D' };
            string expectedDontUseString = "FG";

            int expectdMintLength = 100;
            int expectdMaxLength = 200;

            char[] expectdtemplates = { 'A', 'b', 'c', 'e', 'g', 'h' };

            int expectedCollectionCount = -100;
            string exceptionMessage = "Specified argument was out of the range of valid values. (Parameter 'Argument 'count' must have value greater than 0.')";

            SymbolCases expectedSymbolCases = SymbolCases.None;

            var randomizer = _builder?
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithMinLength(expectdMintLength)
                            .WithMaxLength(expectdMaxLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => { randomizer?.GetValues(expectedCollectionCount); });

            //Assert
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }
    }
}

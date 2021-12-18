using KMVUnion.RandomProvider.StringRandomizer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.Tests.StringRandomizer
{
    public class StringRandomizerBuilderTests
    {

        private StringRandomizerBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new StringRandomizerBuilder();   
        }

        [Test]
        public void StringRandomizerBuilder_ConfigurationExectLength_ExpectedConfigurationApplied()
        {
            //Arrange
            char[] expectdDontUsedSymbols = { 'a', 'b', 'c', 'd' };
            char[] expectdUsedSymbols = { 'A', 'B', 'C' };
            string expectedDontUseString = "expectedDontUseString";
            string expectedUseString = "expectedUseString";
            int expectdExectLength = 17;

            SymbolCases expectedSymbolCases = SymbolCases.Lower;

            //Act
            var result = _builder
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithExactLength(expectdExectLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectdDontUsedSymbols, result.DeniedSymbols);
            Assert.AreEqual(expectedDontUseString, result.DeniedSymbolsFromString);           
            Assert.AreEqual(expectdUsedSymbols, result.AllowedSymbols);
            Assert.AreEqual(expectedUseString, result.AllowedSymbolsFromString);           
            Assert.AreEqual(expectdExectLength, result.ExectLength);
            Assert.AreEqual(expectedSymbolCases, result.SymbolCases);
        }

        [Test]
        public void StringRandomizerBuilder_Configuration_ExpectedConfigurationApplied()
        {
            //Arrange
            char[] expectdDontUsedSymbols = { 'a', 'b', 'c', 'd' };
            char[] expectdUsedSymbols = { 'A', 'B', 'C' };
            string expectedDontUseString = "expectedDontUseString";
            string expectedUseString = "expectedUseString";
            int expectdMinLength = 12;
            int expectdMaxLength = 34;

            SymbolCases expectedSymbolCases = SymbolCases.Lower;

            //Act
            var result = _builder
                            .SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithMinLength(expectdMinLength)
                            .WithMaxLength(expectdMaxLength)
                            .WithSymbolsCases(expectedSymbolCases)
                            .Build();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectdDontUsedSymbols, result.DeniedSymbols);
            Assert.AreEqual(expectedDontUseString, result.DeniedSymbolsFromString);

            Assert.AreEqual(expectdUsedSymbols, result.AllowedSymbols);
            Assert.AreEqual(expectedUseString, result.AllowedSymbolsFromString);

            Assert.AreEqual(expectdMaxLength, result.MaxLength);
            Assert.AreEqual(expectdMinLength, result.MinLength);

            Assert.AreEqual(expectedSymbolCases, result.SymbolCases);
        }

    }
}

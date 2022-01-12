using KMVUnion.RandomProvider.Common;
using KMVUnion.RandomProvider.TextRandomizer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.Tests.TextRandomizer
{
    [TestFixture]
    public class TextRandomizerBuilderTests
    {
        private TextRandomizerBuilder? _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new TextRandomizerBuilder();
        }

        [Test]
        public void TextRandomizerBuilder_ConfigurationExectLength_ExpectedConfigurationApplied()
        {
            //Arrange
            char[] expectdDontUsedSymbols = { 'a', 'b', 'c', 'd' };
            char[] expectdUsedSymbols = { 'A', 'B', 'C' };
            string expectedDontUseString = "expectedDontUseString";
            string expectedUseString = "expectedUseString";
            int expectedRowLength = 40;
            TextAlign expectedAlign = TextAlign.Center;

            //Act
            var result = _builder.SetDeniedSymbols(expectdDontUsedSymbols)
                            .SetDeniedSymbolsFromString(expectedDontUseString)
                            .SetAllowedSymbolsFromString(expectedUseString)
                            .SetAllowedSymbols(expectdUsedSymbols)
                            .WithRowLength(expectedRowLength)
                            .WithTextAlign(expectedAlign)
                            .Build();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectdDontUsedSymbols, result.DeniedSymbols);
            Assert.AreEqual(expectedDontUseString, result.DeniedSymbolsFromString);
            Assert.AreEqual(expectdUsedSymbols, result.AllowedSymbols);
            Assert.AreEqual(expectedUseString, result.AllowedSymbolsFromString);
            Assert.AreEqual(expectedRowLength, result.RowLength);
            Assert.AreEqual(expectedAlign, result.Align);
        }

        [Test]
        public void StringRandomizerBuilder_IncorrectRowLengthConfiguation_ThrowedExeption()
        {
            //Arrange
            string exceptionMessage = "Length of the rows cannot be less 0.";

            var result = _builder
                .SetAllowedSymbolsFromString("Allowed string template")                
                .WithTextAlign(TextAlign.Center)
                .WithRowLength(0);

            //ActAssert
            ConfigurationException ex = Assert.Throws<ConfigurationException>(() => { result.Build(); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }

        [Test]
        public void StringRandomizerBuilder_NoneAllowedSymbolsConfigured_ThrowedExeption()
        {
            //Arrange
            string exceptionMessage = "Allowed symbols do not configured. Please set either AllowedSymbols or AllowedSymbolsFromString.";

            var result = _builder                
                .WithTextAlign(TextAlign.Center)
                .WithRowLength(10);

            //ActAssert
            ConfigurationException ex = Assert.Throws<ConfigurationException>(() => { result.Build(); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }

        [Test]
        public void StringRandomizerBuilder_IncorrectAllowedSymbolsConfiguation_ThrowedExeption()
        {
            //Arrange
            string exceptionMessage = "Allowed symbols do not configured or unique configuration length is lower then 2.";

            var result = _builder
                .SetAllowedSymbolsFromString("q")
                .WithTextAlign(TextAlign.Center)                
                .WithRowLength(10);

            //ActAssert
            ConfigurationException ex = Assert.Throws<ConfigurationException>(() => { result.Build(); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }
    }
}

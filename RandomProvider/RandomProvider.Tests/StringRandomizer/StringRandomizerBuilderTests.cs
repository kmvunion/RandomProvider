using KMVUnion.RandomProvider.Common;
using KMVUnion.RandomProvider.StringRandomizer;
using NUnit.Framework;

namespace RandomProvider.Tests.StringRandomizer
{
    public class StringRandomizerBuilderTests
    {
        private StringRandomizerBuilder? _builder;

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
            var result = _builder?
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

        [TestCase(null, null, null, "Not specified length for randomizer. Either ExactLength or (MinLenfth + MaxLength) must be configured")]
        [TestCase(9, 10, 11, "Randomizer length cannot be configured by ExactLength and (MinLenfth + MaxLength) simultaneously.")]
        [TestCase(19, 10, null, "In randomizer configuration MaxLength can not be greater then MinLength.")]
        [TestCase(-9, 10, null, "Length of randomizer cannot be less 0.")]
        [TestCase(-9, -1, null, "Length of randomizer cannot be less 0.")]
        [TestCase(null, null, -1, "Length of randomizer cannot be less 0.")]
        public void StringRandomizerBuilder_IncorrectLengthConfiguation_ThrowedExeption(int? minLength, int? maxLength, int? exactLangth, string exceptionMessage)
        {
            //Arrange
            var result = _builder
                .SetAllowedSymbolsFromString("Allowed string template")
                .WithExactLength(exactLangth)
                .WithMinLength(minLength)
                .WithMaxLength(maxLength)
                .WithSymbolsCases(SymbolCases.Lower);

            //ActAssert
            ConfigurationException ex = Assert.Throws<ConfigurationException>(() => { result.Build(); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }


        [TestCase(null, "1")]
        [TestCase(new char[] { '1' }, "1")]
        [TestCase(new char[] { '1' }, null)]
        public void StringRandomizerBuilder_IncorrectTemplateConfiguation_ThrowedExeption(char[] allowedSymbols, string allowedsymbolsFromString)
        {
            //Arrange
            string exceptionMessage = "Allowed symbols do not configured or unique configuration length is lower then 2.";
            var result = _builder
                .SetAllowedSymbolsFromString(allowedsymbolsFromString)
                .SetAllowedSymbols(allowedSymbols)
                .WithExactLength(10)
                .WithSymbolsCases(SymbolCases.Lower);

            //ActAssert
            ConfigurationException ex = Assert.Throws<ConfigurationException>(() => { result.Build(); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }

        [Test]
        public void StringRandomizerBuilder_NoConfiguation_ThrowedExeption()
        {
            //Arrange
            string exceptionMessage = "Allowed symbols do not configured. Please set either AllowedSymbols or AllowedSymbolsFromString.";
            var result = _builder
                .WithExactLength(10)
                .WithSymbolsCases(SymbolCases.Lower);

            //ActAssert
            ConfigurationException ex = Assert.Throws<ConfigurationException>(() => { result.Build(); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }
    }
}

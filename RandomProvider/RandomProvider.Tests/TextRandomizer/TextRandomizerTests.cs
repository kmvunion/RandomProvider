using KMVUnion.RandomProvider.Common;
using KMVUnion.RandomProvider.TextRandomizer;
using NUnit.Framework;
using RandomProvider.Tests.Helpers;
using RandomProvider.Tests.TextRandomizer.TestCasesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomProvider.Tests.Extensions;

namespace RandomProvider.Tests.TextRandomizer
{
    [TestFixture]
    public class TextRandomizerTests
    {
        private TextRandomizerBuilder _builder;
        private ITextRandomizer _randomizer;

        string _useString = "eFgh23c";
        string _dontUseString = "fg";
        int _rowLength = 40;

        [SetUp]
        public void Setup()
        {
            _builder = new TextRandomizerBuilder();
            _builder.SetDeniedSymbolsFromString(_dontUseString)
                    .SetAllowedSymbolsFromString(_useString)
                    .WithRowLength(_rowLength);
        }

        [TestCaseSource(typeof(TextRandomizerTestCases), nameof(TextRandomizerTestCases.GetNoisyTextDifferentLength))]
        public void Randomizer_GetNoisyText_GetDifferentLength_Success(int length, int expectedLength, TextAlign align)
        {
            //Arrange  
            _randomizer = _builder.WithTextAlign(align).Build();

            //Act
            var result = _randomizer.GetNoisyText(length).ToList();
            var resultInTrimmedString = String.Join(String.Empty, result.Select(x => x.Trim()).ToArray());
            var resultInString = String.Join(String.Empty, result.ToArray());

            //Assert
            Assert.IsNotNull(resultInTrimmedString);
            Assert.AreEqual(expectedLength, resultInString.Length);
            Assert.AreEqual(length, resultInTrimmedString.Length);
            AssertStringHelper.AssertAlign(result.Last(), align);
        }

        [TestCaseSource(typeof(TextRandomizerTestCases), nameof(TextRandomizerTestCases.GetWordyTextDifferentLength))]
        public void Randomizer_GetSentencesText_GetDifferentLength_Success(int length, TextAlign align)
        {
            //Arrange
            _randomizer = _builder.WithTextAlign(align).Build();

            //Act
            var result = _randomizer.GetSentencesText(length).ToList();
            var resultInTrimmedString = String.Join(String.Empty, result.Select(x => x.Trim()).ToArray());

            //Assert
            var resultWordsCount = result.Sum(x=>x.Trim().RemoveDuplicates().GetWordsCount());
            Assert.IsNotNull(resultInTrimmedString);
            Assert.AreEqual(length, resultWordsCount);
            foreach (var item in result)
            {
                AssertStringHelper.AssertAlign(item, align);
            }
        }

        [TestCaseSource(typeof(TextRandomizerTestCases), nameof(TextRandomizerTestCases.GetWordyTextDifferentLength))]
        public void Randomizer_GetWordyText_GetDifferentLength_Success(int length, TextAlign align)
        {
            //Arrange
            _randomizer = _builder.WithTextAlign(align).Build();

            //Act
            var result = _randomizer.GetWordyText(length).ToList();
            var resultInTrimmedString = String.Join(String.Empty, result.Select(x => x.Trim()).ToArray());

            //Assert
            var resultWordsCount = result.Sum(x => x.Trim().RemoveDuplicates().GetWordsCount());
            Assert.IsNotNull(resultInTrimmedString);
            Assert.AreEqual(length, resultWordsCount);
            foreach (var item in result)
            {
                AssertStringHelper.AssertAlign(item, align);
            }
        }

        [TestCase(TextAlign.Left)]
        [TestCase(TextAlign.Right)]
        [TestCase(TextAlign.Center)]
        [TestCase(TextAlign.Justify)]
        public void Randomizer_GetNoisyText_NegativeLength_ThrowedException(TextAlign align)
        {
            //Arrange
            _randomizer = _builder.WithTextAlign(align).Build();
            string exceptionMessage = "Symbols count must be above 0. (Parameter 'symbolsCount')";

            //ActAssert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => { _randomizer.GetNoisyText(-1); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }

        [TestCase(TextAlign.Left)]
        [TestCase(TextAlign.Right)]
        [TestCase(TextAlign.Center)]
        [TestCase(TextAlign.Justify)]
        public void Randomizer_GetSentencesText_ThrowedException(TextAlign align)
        {
            //Arrange
            _randomizer = _builder.WithTextAlign(align).Build();
            string exceptionMessage = "Words count must be above 0. (Parameter 'wordCount')";

            //ActAssert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => { _randomizer.GetSentencesText(-1); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }

        [TestCase(TextAlign.Left)]
        [TestCase(TextAlign.Right)]
        [TestCase(TextAlign.Center)]
        [TestCase(TextAlign.Justify)]
        public void Randomizer_GetWordyText_ThrowedException(TextAlign align)
        {
            //Arrange
            _randomizer = _builder.WithTextAlign(align).Build();
            string exceptionMessage = "Words count must be above 0. (Parameter 'wordCount')";

            //ActAssert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => { _randomizer.GetWordyText(-1); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }

    }
}

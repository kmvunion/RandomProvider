using KMVUnion.RandomProvider.TextRandomizer;
using NUnit.Framework;
using RandomProvider.Integration.Tests.Extensions;
using System;
using System.IO;
using System.Linq;

namespace RandomProvider.Integration.Tests.TextRandomizer
{
    [TestFixture]
    public class TextRandomizerTests
    {
        private ITextRandomizerBuilder _builder = new TextRandomizerBuilder();
        private ITextRandomizer _randomizer;
        private string _fileName;


        [SetUp]
        public void SetUp()
        {
            _builder
                .SetAllowedSymbolsFromString("QWERTYASDFGZXCVB123")
                .WithRowLength(40);


            _fileName = $"TM_{Guid.NewGuid()}.txt";
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }

        [Test]
        public void GetNoisyTextToFile_ALignRightToFile_DataExist()
        {
            //Arrange
            int expectedLength = 400;
            int length = 370;
            _randomizer = _builder.WithTextAlign(TextAlign.Right).Build();

            //Act
            _randomizer.GetNoisyTextToFile(length, _fileName);
            var result = File.ReadAllLines(_fileName).ToList();
            var resultInTrimmedString = String.Join(String.Empty, result.Select(x => x.Trim()).ToArray());
            var resultInString = String.Join(String.Empty, result.ToArray());

            //Assert
            Assert.IsNotNull(resultInTrimmedString);
            Assert.AreEqual(expectedLength, resultInString.Length);
            Assert.AreEqual(length, resultInTrimmedString.Length);
        }

        [Test]
        public void GetWordyTextToFile_ALignRightToFile_DataExist()
        {
            //Arrange
            int expectedLength = 400;
            int length = 370;
            _randomizer = _builder.WithTextAlign(TextAlign.Right).Build();

            //Act
            _randomizer.GetWordyTextToFile(length, _fileName);
            var result = File.ReadAllLines(_fileName).ToList();
            var resultInTrimmedString = String.Join(String.Empty, result.Select(x => x.Trim()).ToArray());

            //Assert
            var resultWordsCount = result.Sum(x => x.Trim().RemoveDuplicates().GetWordsCount());
            Assert.IsNotNull(resultInTrimmedString);
            Assert.AreEqual(length, resultWordsCount);
        }

        [Test]
        public void GetSentencesTextToFile_ALignRightToFile_DataExist()
        {
            //Arrange
            int expectedLength = 400;
            int length = 370;
            _randomizer = _builder.WithTextAlign(TextAlign.Right).Build();

            //Act
            _randomizer.GetSentencesTextToFile(length, _fileName);
            var result = File.ReadAllLines(_fileName).ToList();
            var resultInTrimmedString = String.Join(String.Empty, result.Select(x => x.Trim()).ToArray());

            //Assert
            var resultWordsCount = result.Sum(x => x.Trim().RemoveDuplicates().GetWordsCount());
            Assert.IsNotNull(resultInTrimmedString);
            Assert.AreEqual(length, resultWordsCount);
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
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => { _randomizer.GetNoisyTextToFile(-1, _fileName); });
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
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => { _randomizer.GetSentencesTextToFile(-1, _fileName); });
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
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => { _randomizer.GetWordyTextToFile(-1, _fileName); });
            Assert.IsNotNull(ex);
            Assert.AreEqual(exceptionMessage, ex?.Message);
        }

    }
}

using KMVUnion.RandomProvider.Common.Extensions;

namespace KMVUnion.RandomProvider.TextRandomizer
{
    internal class ConfiguratorSentence
    {
        private (string finalSymbol, int minWeight, int maxWeight)[] _finalSymbolDistribution = new (string, int, int)[] { (".", 0, 70), ("?", 71, 80), ("!", 81, 95), ("...", 96, 100) };

        private int _currentIndex = 0;
        private int _targetWordCount = 0;
        private Random _randomizer = new Random();

        public ConfiguratorSentence()
        {
            Reset();
        }

        private string GetFinalSymbol()
        {
            var weight = _randomizer.Next(100);
            return _finalSymbolDistribution.SingleOrDefault(x => x.minWeight < weight && x.maxWeight > weight).finalSymbol ?? ".";
        }

        private void Reset()
        {
            _currentIndex = 0;
            _targetWordCount = _randomizer.Next(3, 20);
        }

        public string RecordingWord(string item, bool isLastWord)
        {
            if (_currentIndex == 0)
            {
                _currentIndex++;
                return item.StartFromCapital();
            }
            else if (_currentIndex == _targetWordCount || isLastWord)
            {
                Reset();
                return $"{item}{GetFinalSymbol()}";
            }
            _currentIndex++;
            return item;
        }
    }
}

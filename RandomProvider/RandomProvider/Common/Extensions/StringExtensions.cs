namespace KMVUnion.RandomProvider.Common.Extensions
{
    internal static class StringExtensions
    {
        internal static string PadSides(this string item, int rowLength, char symbol)
        {
            int sidelength = Convert.ToInt32(Math.Floor((decimal)((rowLength - item.Length) / 2)));
            return $"{new string(symbol, sidelength)}{item}{new string(symbol, rowLength - item.Length - sidelength)}";
        }

        internal static string Justify(this string item, int rowLength, char symbol)
        {
            var result = item.NormolizeWordingInRow(symbol);
            int spacesCount = result.ToList().Where(x => x.Equals(symbol)).Count();
            if (spacesCount > 0)
            {
                int newSpaceSize = Convert.ToInt32(Math.Floor((decimal)((rowLength - result.Length) / spacesCount)));
                result = result.Replace(new string(symbol, 1), new string(symbol, newSpaceSize + 1));
                var lastSpaceIndex = result.LastIndexOf(symbol);
                if (lastSpaceIndex > 0)
                {
                    return result.Insert(lastSpaceIndex, new string(symbol, rowLength - result.Length));
                }
            }

            return result.PadRight(rowLength, symbol);
        }

        internal static string NormolizeWordingInRow(this string item, char symbol)
        {
            var result = item.Trim(symbol);

            while (result.IndexOf(new string(symbol, 2)) > 0)
            {
                result.Replace(new string(symbol, 2), new string(symbol, 1));
            }

            return result;
        }
    }
}

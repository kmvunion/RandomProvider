using System.Linq;

namespace RandomProvider.Tests.Extensions
{
    public static class StringExtensions
    {
        public static int GetWordsCount(this string item, char separator = ' ')
        {
            return item.Split(separator).Count();
        }

        public static string RemoveDuplicates(this string item, char separator = ' ')
        {
            bool replacedFlag = true;
            while (replacedFlag)
            {
                var duplicate = new string(separator, 2);
                
                if (item.IndexOf(duplicate)>0) 
                {
                    item = item.Replace(duplicate, new string(separator, 1));
                    continue;
                }
                replacedFlag = false;
            }

            return item;
            
        }
    }

}
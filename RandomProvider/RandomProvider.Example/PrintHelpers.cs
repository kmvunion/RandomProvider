using RandomProvider.StringRandomizer;
using System.Collections;
using System.Linq.Expressions;

namespace RandomProvider.Example
{
    internal static class PrintHelpers
    {
        private static readonly ConsoleColor HeaderColor = ConsoleColor.Yellow;
        private static readonly ConsoleColor TextColor = ConsoleColor.White;
        private static readonly ConsoleColor ValueColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor HiddenColor = ConsoleColor.Gray;

        public static void PrintTestsRezults(List<string> generatedValues)
        {
            var predefinedColor = Console.ForegroundColor;            

            for (int i = 0; i < generatedValues.Count; i++)
            {
                Console.ForegroundColor = HiddenColor;
                Console.Write($" {i+1}. ");
                Console.ForegroundColor = TextColor;
                Console.WriteLine(generatedValues[i]);
            }

            Console.ForegroundColor = predefinedColor;
        }

        public static void PrintConfiguration(IStringRandomizer randomizer, string header, string description)
        {
            Console.WriteLine();
            PrintHeader(header);
            PrintDescription(description);
            Console.WriteLine();
            PrintValue(randomizer, v => v.AllowedSymbols);
            PrintValue(randomizer, v => v.DeniedSymbols);
            PrintValue(randomizer, v => v.AllowedSymbolsFromString);
            PrintValue(randomizer, v => v.DeniedSymbolsFromString);
            PrintValue(randomizer, v => v.MinLength);
            PrintValue(randomizer, v => v.MaxLength);
            PrintValue(randomizer, v => v.ExectLength);
            PrintValue(randomizer, v => v.SymbolCases);

            Console.WriteLine("".FillUpToLength(80,'-'));
        }

        private static void PrintValue<TProperty>(IStringRandomizer randomizer, Expression<Func<IStringRandomizer, TProperty>> propertyExpression)
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var name = expression.Member.Name;
            var typeValue = expression.Type;

            string value;
            if (typeValue.IsArray)
            {
                var configurationValue = randomizer.GetType().GetProperty(name)?.GetValue(randomizer, null);
                value = $"[{(Convert.ChangeType(configurationValue, typeValue) as IEnumerable)?.ToStringRepresentation()}]";

            }
            else
            {
                value = randomizer
                    .GetType()
                    .GetProperty(name)?
                    .GetValue(randomizer, null)?
                    .ToString();

                if (typeValue == typeof(string))
                {
                    value= $"\"{value}\"";
                }
            }

            var predefinedColor = Console.ForegroundColor;
            Console.ForegroundColor = TextColor;
            Console.Write($"  - {name.FillUpToLength()}  ");
            Console.ForegroundColor = ValueColor;
            Console.WriteLine(value);
            Console.ForegroundColor = predefinedColor;
        }

        private static void PrintHeader(string text)
        {
            var predefinedColor = Console.ForegroundColor;
            Console.ForegroundColor = HeaderColor;
            Console.WriteLine($"-[{text}]".FillUpToLength(80,'-'));
            Console.ForegroundColor = predefinedColor;
        }

        private static void PrintDescription(string text)
        {
            var predefinedColor = Console.ForegroundColor;
            Console.ForegroundColor = HiddenColor;
            Console.WriteLine(text);
            Console.ForegroundColor = predefinedColor;
        }
    }
}

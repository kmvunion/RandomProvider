# RandomProvider
The lightweight package allows generating random strings for your project based on predefined configurations. 
The complete list of features will describe in the documentation for release version 1.0.1.

## Example 1
Use predefined characters for generating random string values
**Configuration**
```sh
using KMVUnion.RandomProvider.StringRandomizer;
...
var randomizer = new StringRandomizerBuilder()
    .UseSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
    .WithExactLength(7)
    .Build();
```
**Generating value**
```sh
var value = randomizer.GetValue();
```

## Example 2
Use predefined string as a template for generating random string values 
**Configuration**
```sh
using KMVUnion.RandomProvider.StringRandomizer;
...
var randomizer = new StringRandomizerBuilder()
    .UseSymbolsFromString("This is a string that will be used as a template for generating random string value.")
    .DontUseSymbolsFromString("w ta")
    .WithMinLength(3)
    .WithMaxLength(10)
    .WithSymbolsCases(SymbolCases.Lower)
    .Build();
```
**Generating value**
```sh
var value = randomizer.GetValue();
```
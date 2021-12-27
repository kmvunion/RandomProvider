# RandomProvider
The lightweight package allows generating random strings for your project based on predefined configurations. 
Complete documentation will be available in version 1.1.0.

## Documentation

### How to start?
At first, you have to configure your random provider. For this, you need to create a randomizer builder and set up a configuration for it. The minimal setup contains at least two configuration options:
- Length of the generated string.
- The template of symbols is used for generating random values. 

> Declare **KMVUnion.RandomProvider.StringRandomizer** before start by adding a row `using KMVUnion.RandomProvider.StringRandomizer;` in your code.

### How to set up the length of the generated string?
You can choose one of two options: 
**Generate exact length** for whole generated values. In these cases, all generated values have a length previously configured.

```csharp
var randomizer = new StringRandomizerBuilder()
    ...
    .WithExactLength(7) // All generated strings will have a length exact 7  
    ...
    .Build();
```
Also, you can configure length, which would have a **random length in the specified range**.

```csharp
var randomizer = new StringRandomizerBuilder()
    ...
    // Using This configuration generated strings will have a length  from the range 3..10
    .WithMinLength(3)
    .WithMaxLength(10)
    ...
    .Build();
```

### How to set up a template of symbols?
For generating a random value, we need to have a template list of symbols. We can provide it by adding an array of symbols.

```csharp
var randomizer = new StringRandomizerBuilder()
    ...
    .SetAllowedSymbols(new char[3]{'a','b','c'}) // template includes only three symbols 'a', 'b' and 'c'
    ...
    .Build();
```

Another approach for configuration templates is adding a string that contains the required symbols for configuration. 

```csharp
var randomizer = new StringRandomizerBuilder()
    ...
    .SetAllowedSymbolsFromString("defg") // template includes forth symbols 'd', 'e', 'f' and 'g'
    ...
    .Build();
```

You can use any of these techniques or combine them.  In this case, one approach complements another. 


```csharp
var randomizer = new StringRandomizerBuilder()
    ...
    //In this case template will be configured by range of symbols 'a', 'b', 'c', 'd', 'e', 'f' and 'g'
    .SetAllowedSymbols(new char[3]{'a','b','c'})
    .SetAllowedSymbolsFromString("defg") 
    ...
    .Build();
```

Also, you can exclude some symbols from the template. For doing this, you can use two methods for configuration:  

- **SetDeniedSymbols(char[] symbols)** - excludes symbols represented in the array if such exist.
- **SetDeniedSymbolsFromString(string templateString)** - excludes symbols represented in the string if such exist.

Those methods also can complement each other if it is needed. 

```csharp
var randomizer = new StringRandomizerBuilder()
    ...
    .SetAllowedSymbols(...)
    .SetAllowedSymbolsFromString(...) 
    ...
    //In this case from template will be excluded the range of symbols 'x', 'y', 'z', '_', '3', '#' and '.'
    .SetDeniedSymbols(new char[3]{'x','y','z'})
    .SetDeniedSymbolsFromString("_3#.") 
    ...
    .Build();
```

### How to configure case of the symbols?
The property **SymbolCases** is responsible for the configuration output cases of the symbols.
It could be one from the fourth:
 - **None** - use symbols exact in the same cases as these are in the template.
 - **Lower** - all symbols will be converted in the lower case 
 - **Upper** - result will be converted into the upper case 
 - **Mixed** - for this configuration result string will include symbols in upper and lower cases approximately in a proportion of 50/50. 

> By default, the symbol case setting is **None**. 

But you can change by setting it via the method **WithSymbolsCases** of the StringRandomizerBuilder class.

```csharp
var randomizer = new StringRandomizerBuilder()
    ...
    .WithSymbolsCases(SymbolCases.Lower) // result contains symbols only in the lower case
    ...
    .Build();
```

### How to generate random value?
> Randomizer configuration must be provided at first!

Use method **GetValue()** method for getting random of string value.

```csharp
    var randomizer = new StringRandomizerBuilder()
    ...    
    .Build();
    ...
    //Generate value
    var value = randomizer.GetValue();
```

### How to generate a collection of random values?
> Randomizer configuration must be provided at first!

Use method **GetValues(int count)** for generating collection of random of string values.

```csharp
    var randomizer = new StringRandomizerBuilder()
    ...    
    .Build();
    ...
    //Generating collection of 30 random string values.
    var values = randomizer.GetValues(30);
```

> Please, have a look examples below for a better understanding of the randomizer configuration.

## Examples

### Example 1
Use predefined characters for the generating random string values
```csharp
using KMVUnion.RandomProvider.StringRandomizer;
...
//Configuration
var randomizer = new StringRandomizerBuilder()
    .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
    .WithExactLength(7)
    .Build();
...
//Generating value
var value = randomizer.GetValue();
```

### Example 2
Use predefined string as a template for generating random string values 

```csharp
using KMVUnion.RandomProvider.StringRandomizer;
...
//Configuration
var randomizer = new StringRandomizerBuilder()
    .SetAllowedSymbolsFromString("This is a string that will be used as a template for generating random string value.")
    .SetDeniedSymbolsFromString("w ta")
    .WithMinLength(3)
    .WithMaxLength(10)
    .WithSymbolsCases(SymbolCases.Lower)
    .Build();
...
//Generating value
var value = randomizer.GetValue();
```
```

### Example 3
Use predefined randomizer for generating a collection of the random strings

```csharp
using KMVUnion.RandomProvider.StringRandomizer;
...
//Configuration
var randomizer = new StringRandomizerBuilder()
    .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
    .WithExactLength(7)
    .Build();
...
//Generating collection of 30 random string values.
var values = randomizer.GetValues(30);
```
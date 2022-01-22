# RandomProvider

The lightweight package allows generating random data for your project based on predefined configurations.

Current version contains following randomizers:
* ***StringRandomizer*** - allows generating random string values in your project;
* ***TextRandomizer*** - provides possibility to generate random text.  

---
## StringRandomizer

**String randomizer** serves for generating random string values based on predefined configuration. You can configure string length, symbols cases and symbols that could be used for generating particular value and that should not.

### Configuration methods
Before starting configuration and using StringRandomizer you should add
`using KMVUnion.RandomProvider.StringRandomizer;` 
into **using** section of your code.

For configuring randomizer you can use set of methods ```IStringRandomizerBuilder```. Method ```Build();```  returns an instance of the ```StringRandomizer```;

| Methods | Description | Comments|
| ------ | ------ | ------ |
|SetAllowedSymbols(char[] symbols)|Set allowed symbols from the array.||
|SetDeniedSymbols(char[] symbols)|Set denied symbols from the array.||
|SetAllowedSymbolsFromString(string templateString)|Set allowed symbols from the string.||
|SetDeniedSymbolsFromString(string templateString)|Set denied symbols from the string.||
|WithMinLength(int? length)|Set configuration of the minimal length for the generating random strings.| Must be configured in pair with **Max Length** and be over 0.|
|WithMaxLength(int? length)|Set configuration of the maximum length for the generating random strings.| Must be configured in pair with **Min Length** and be over 0.|
|WithExactLength(int? length)|Set configuration of the  exact length of the random string.| If you use **ExactLength** than you should not use pair **Min Length** and **Max Length** |
|WithSymbolsCases(SymbolCases cases)|Set symbols case option for configuration generated values.| It could be one of the foure **None, Mixed, Lower, Upper**|
|Build()| Build an instance of the randomizer based on configuration. ||

#### Length configuration
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

#### Configuration a template of symbols
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

#### Symbol cases configuration
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

### Get ranndom data methods
There are few methods that you could use for generating random string values:

| Methods | Description | Comments|
| ------ | ------ | ------ |
|GetValue()|Generate random string value.|It uses configuration that has been provided while StringRandomizer had built. |
|GetValue(int exactLength)|Generate random string value of exact length| This method skips preconfigured length and applies exact length from the argument |
|GetValue(int minLength, int maxLength)|Generate random string value with length from the range| This method skips preconfigured length and applies min, max length from the argument |
|GetValues(int count)|Generate IEnumerable of random string values||

### Examples 
**Example 1**
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
**Result:**
```
"FDFggBF"
```

**Example 2**
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
**Result:**
```
"viosrnbu"
```

**Example 3**
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
//Generating collection of 3 random string values.
var values = randomizer.GetValues(3);
```
**Result:**
```
["lCh1l5B","D5Cl1BD","AC1hDg5"]
```
**Example 4**
Although configuration contains a range of lengths from 3 to 10, we can get the random string value of exact length different from the initial randomizer configuration.

```csharp
using KMVUnion.RandomProvider.StringRandomizer;
...
//Configuration
var randomizer = new StringRandomizerBuilder()
    .SetAllowedSymbolsFromString("This is a string that will be used as a template for generating random string value.")
    .WithMinLength(3)
    .WithMaxLength(10)
    .WithSymbolsCases(SymbolCases.Lower)
    .Build();
...
//Generating value
var value = randomizer.GetValue(20);
```
---
## TextRandomizer

**Text randomizer** allows you to generate random text values. These text values could have different representations based on configuration.

### Configuration 

Before starting configuration and using StringRandomizer you should add
`using KMVUnion.RandomProvider.StringRandomizer;` 
into **using** section of your code.

For configuring randomizer you can use set of methods ```ITextRandomizerBuilder```. Method ```Build();```  returns an instance of the ```TextRandomizer```;

| Methods | Description | Comments|
| ------ | ------ | ------ |
|SetAllowedSymbols(char[] symbols)|Set allowed symbols from the array.||
|SetDeniedSymbols(char[] symbols)|Set denied symbols from the array.||
|SetAllowedSymbolsFromString(string templateString)|Set allowed symbols from the string.||
|SetDeniedSymbolsFromString(string templateString)|Set denied symbols from the string.||
|WithTextAlign(TextAlign align)|Initialize text align mode. |One of the fourth **Left**, **Center**, **Right**, **Justify**|
|WithRowLength(int rowLength)|Setup row length for the generating text value||
|Build()| Build an instance of the randomizer based on configuration. ||

#### Configuration a template of symbols
For generating a random value, we need to have a template list of symbols. We can provide it by adding an array of symbols.

```csharp
var randomizer = new TextRandomizerBuilder()
    ...
    .SetAllowedSymbols(new char[3]{'a','b','c'}) // template includes only three symbols 'a', 'b' and 'c'
    ...
    .Build();
```

Another approach for configuration templates is adding a string that contains the required symbols for configuration. 

```csharp
var randomizer = new TextRandomizerBuilder()
    ...
    .SetAllowedSymbolsFromString("defg") // template includes forth symbols 'd', 'e', 'f' and 'g'
    ...
    .Build();
```

You can use any of these techniques or combine them.  In this case, one approach complements another. 

```csharp
var randomizer = new TextRandomizerBuilder()
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
var randomizer = new TextRandomizerBuilder()
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

#### Text aligning configuration
The property **TextAlign** is responsible for the configuration text align mode of the output text value.
It could be one from the fourth:
 - **Left** - Align text to the left
 - **Center** - Align text to the center
 - **Right** - Align text to the right
 - **Justify** - Justify text
 
> By default, text align mode is **Left**. 

You can change by setting it via the method **WithTextAlign** of the TextRandomizerBuilder class.

```csharp
var randomizer = new TextRandomizerBuilder()
    ...
    .WithTextAlign(SymbolCases.Center) // result text aligns in the center of the row
    ...
    .Build();
```

### Get ranndom data methods
There are some methods that generate random text values. These methods generate text of three different types:
- **Noisy** - This type builds text that consists of random symbols without any gaps.
Example:
 ```
        Ehh1gAlEECDgD5l1hEBFgDAgl5ECFh
        FFABDFEADhFAFBFlDgEDDBEgElFglg
        ChgCFhBEFCA5C1EAhDhBBBgE1C5C55
        hlC1FDAAgD
 ```
 
- **Wordy** - text of this type contains pseudo words, that are built by random symbols. At the same time, such text does not have sentences.
Example:
```
        DBF1llC1D A1CA15Bl EECBChF lhhh1CAgCFD
        DCgDggChC Bg5h51h lEBBgECh BhFhBA5F
        lACBC5FgE15
```
- **Sentences** - Such text contains sentences that start from the capital and contain one random symbol from the range (**'.'**, **'!'**, **'?'**) at the end of the sentence. 
```
        Gcaamdgkl AADmkll ADBChgmDDE lCAChkEBAm ll EClBhDE EDhm ggBkkgEgBl? Cgfecfdh
        FgCADmCEEmB BAABggDEBD BAFmAgE! A gDDgBlDgECB lEmBBlF gDFDCAED BhgDgmlkDh
        mhklDEAB EkgBChCDCC. 
```

| Methods | Description | Comments|
| ------ | ------ | ------ |
| IEnumerable<string> GetNoisyText(int symbolsCount)|Generate random noisy text||
| void GetNoisyTextToFile(int symbolsCount, string filePath)|Generate random noisy text and store it into the file||
| IEnumerable<string> GetWordyText(int wordCount)|Generate random wordy text||
| void GetWordyTextToFile(int wordCount, string filePath)|Generate random wordy text and store it into the file||
| IEnumerable<string> GetSentencesText(int wordCount)|Generate random and similar to the literature text|Contains sentences and, each of those sentences starts from a capital letter.|
| void GetSentencesTextToFile(int wordCount, string filePath)|Generate random, similar to the literature text and store it into the file|Contains sentences and, each of those starts from a capital letter|

### Examples 
**Example 1**
Generating noisy text with aligning text from the right side.

```csharp
using KMVUnion.RandomProvider.TextRandomizer;
...
//Configuration
var randomizer = new TextRandomizerBuilder()
            .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })                        
            .WithRowLength(30)
            .WithTextAlign(TextAlign.Right)
            .Build();
...
var result = randomizer.GetNoisyText(100);
```

**Result:**
```
ElEg1BEBDCgBCChDEhCEAg5DhE1hll
Cg1hl1lBB5EFDgFlgBlE115lgAEAhA
BhD5FBEEgD5CDBEl5E5Dllg1llFF5g
                 ggFB15hhCC
```

**Example 2**
Generating wordy text with aligning text from the left side.

```csharp
using KMVUnion.RandomProvider.TextRandomizer;
...
//Configuration
var randomizer = new TextRandomizerBuilder()
            .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
            .WithRowLength(40)
            .WithTextAlign(TextAlign.Left)
            .Build();
...
//Generating wordy text
var result = randomizer.GetWordyText(40);
```

**Result:**
```
g5BglD1A1 F hAF5gBg5 51E1lDC DgD1AAA
Agh D1EClB15B ll1hlC5Cggh FCFEghF
EF1BC55hF 1hl1AFBhlF F5l lh1DF51 5EgA
FDAh5AEhD BFDCAlhD h EABBll51DlB
Dl5AFDgE5D 15lg1l1E BClD1lDAABh
51BgE1g5 1B ElA5DADg ACDEBEF
FlFlhC1AAF1 FBA551lg1h BC1Ehg5lD
EAgD1F5BEC F1BhF DAFCAll A5EB FDDA5A1AB
BCE51FlAAC l1Eg1Dg 5A5FC1FF1hC
ElFlh1CCBF Cg5DClBh5gl g1DF5AhB gEEllCl
```

**Example 3**
Generating wordy text with aligning in the justify mode.

```csharp
using KMVUnion.RandomProvider.TextRandomizer;
...
//Configuration
var randomizer = new TextRandomizerBuilder()
            .SetAllowedSymbols(new[] { '1', 'G', 'h', 'l', '5', 'a', 'B', 'C', 'D', 'e', 'f' })
            .WithRowLength(40)
            .WithTextAlign(TextAlign.Justify)
            .Build();
...
// Generating wordy text
var result = randomizer.GetWordyText(40);
```

**Result:**
```
ABCFgFFB5E 1hECCBF1F 1 FhDlAF5   F1AhhAB
lD    5F1l11DDFB    FlCEFACgC    1hCgg5A
FEEE51Dg5FF Bg1DgE1hFh DEAh151AB   ECg5B
EhFDEl1   BFlCBAAB   EAFABCB    FECAB1C1
gFD5E1CCACE  CB  DEEFD1EACFC   ghhFFhCBh
DgC1AED5DFh 1DFDD1hE5FC F5ADCDFhg  EAhBl
hF1E5FF      l5Dl511gBBD      lDAglBgll1
5CDCEE1AFC  FD1BB5EEg  FBCDAEF  5DFBCFCC
CD51ChgAh   AFEDg1hFA   DAEgDBFFAgC    h
1gDFhlD5   hl   1A1hlFl1h     5hAFhghF51
```

**Example 4**
Generating text which consist of set of sentences with aligning text in the center.

```csharp
using KMVUnion.RandomProvider.TextRandomizer;
...
//Configuration
var randomizer = new TextRandomizerBuilder()
            .SetAllowedSymbols(new[] { 'k', 'G', 'h', 'l', 'M', 'a', 'B', 'C', 'D', 'e', 'f' })
            .WithRowLength(80)
            .WithTextAlign(TextAlign.Center)
            .Build();
...
//Generating text contained pseudo sentences.
var result = randomizer.GetSentencesText(40);
```

**Result:**
```
   Flglfdg FA CgFggghBFg mgmAkFCBBl kEhEkhlBEmm glFAlhEEDAA BEm BmF BkDhhhBkAl
     kBECAggAAB kkECkDgCFEm BAlAFgDC. Akbdffhfbll kChE mAhmhkCEE FFBEBCDA Eg
 DhkmADAE hECDEhCA hFBBEADg lClChAm DFAgABlEBh. Gflbamcfgh BhFklBFCkm EBEkFCBAhF
 AlDCChgA AhChAlAl mEhFBDlA lEglmDmD? Aldldelmece DlEhEChDkk ABEEBglDBm lmEFkFmh
                  F AgAm kgFmClFlg CDFBAgmC llBgglk gDBCg hAmAl?
```
---
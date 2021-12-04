using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.StringRandomizer
{
    public  interface IStringRandomizerBuilder: IBaseRandomizer<IStringRandomizer>
    {
        IStringRandomizerBuilder UseSymbols(char[] symbols);
        
        IStringRandomizerBuilder DontUseSymbols(char[] symbols);        
        
        IStringRandomizerBuilder DontUseSymbolsFromString(string templateString);
        
        IStringRandomizerBuilder UseSymbolsFromString(string templateString);
        
        IStringRandomizerBuilder WithMinLength(int length);
        
        IStringRandomizerBuilder WithMaxLength(int length);
        
        IStringRandomizerBuilder WithExectLength(int length);

        IStringRandomizerBuilder WithSymbolsCases(SymbolCases cases);

    }
}

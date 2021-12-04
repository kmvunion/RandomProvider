using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.StringRandomizer
{
    public  interface IStringRandomizer: IBaseRandomizer<IStringRandomizer>
    {
        IStringRandomizer UseSymbols(char[] symbols);
        
        IStringRandomizer DontUseSymbols(char[] symbols);        
        
        IStringRandomizer DontUseSymbolsFromString(string templateString);
        
        IStringRandomizer UseSymbolsFromString(string templateString);
        
        IStringRandomizer WithMinLength(int length);
        
        IStringRandomizer WithMaxLength(int length);
        
        IStringRandomizer WithExectLength(int length);

        IStringRandomizer WithSymbolsCases(SymbolCases cases);

    }
}

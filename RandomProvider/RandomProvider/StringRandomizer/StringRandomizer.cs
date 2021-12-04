using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider.StringRandomizer
{
    public class StringRandomizer : IStringRandomizer
    {
        public IStringRandomizer Build()
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer CleanConfiguration()
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer DontUseSymbols(char[] symbols)
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer DontUseSymbolsFromString(string templateString)
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer UseSymbols(char[] symbols)
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer UseSymbolsFromString(string templateString)
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer WithExectLength(int length)
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer WithMaxLength(int length)
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer WithMinLength(int length)
        {
            throw new NotImplementedException();
        }

        public IStringRandomizer WithSymbolsCases(SymbolCases cases)
        {
            throw new NotImplementedException();
        }
    }
}

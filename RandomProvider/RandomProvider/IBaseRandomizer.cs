using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProvider
{
    public interface IBaseRandomizer<T>
    {
        T Build();

        T CleanConfiguration();
    }
}

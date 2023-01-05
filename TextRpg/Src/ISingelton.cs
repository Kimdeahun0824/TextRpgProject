using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal interface ISingelton<T> where T : class
    {
        T getInstance();
    }
}

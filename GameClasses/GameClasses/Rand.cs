using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClasses
{
    public static class Rand
    {        
        public static int GetRandInt(Random rnd ,int min, int max)
        {            
            return rnd.Next(min, max);
        }
    }
}

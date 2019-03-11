using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopSwagCode.CI.AWS.WebAPI.Services
{
    public class ValuesService
    {
        public int SumOfValues(List<int> values)
        {
            return values.Sum();
        }
    }
}

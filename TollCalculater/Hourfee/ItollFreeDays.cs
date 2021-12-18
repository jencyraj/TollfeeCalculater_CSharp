using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.Hourfee
{
    public interface ItollFreeDays
    {
        bool Istollfree(DateTime date);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoConsolidator
{
    public interface ICargoConsolidator
    {
        public void AddReport(string path);
        public int GetAmount(int itemId);
    }
}

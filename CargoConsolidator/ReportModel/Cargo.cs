using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoConsolidator.ReportModel
{
    internal class Cargo
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}

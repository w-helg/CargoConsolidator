using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoConsolidator.ReportModel
{
    internal class Storage
    {
        public int Id { get; set; }
        public List<Cargo> Cargos { get; set; }
    }
}

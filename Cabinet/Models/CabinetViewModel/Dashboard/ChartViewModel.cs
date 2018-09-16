using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.Models.CabinetViewModel.Dashboard
{
    public class ChartViewModel
    {
        List<ColumnChartData> ColumnsChartData { get; set; }
    }

    public class ColumnChartData
    {
        public int GeburtsDatumJahr;
        public int PatientsCount;
    }
}

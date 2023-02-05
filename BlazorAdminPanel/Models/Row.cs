

namespace BlazorAdminPanel.Models
{
    // Универсальный шаблон строки для таблиц данных.
    public class Row
    {
        public string Name { get; set; }
        public int NumCustomers { get; set; }
        public double Percent { get; set; }
        public string ISO { get; set; }
        public string Month { get; set; }
        public int Earnings { get; set; }
    }
}

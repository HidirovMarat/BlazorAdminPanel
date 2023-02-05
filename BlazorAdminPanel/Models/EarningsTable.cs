using BlazorAdminPanel.MyCode;
using System;
using System.Globalization;


namespace BlazorAdminPanel.Models
{
    public class EarningsTable : Table
    {
        // Итоговые данные.
        public int TotalEarning { get; set; }
        public int TotalCustomers { get; set; }
        public int MonthAverage { get; set; }
        public int EarningsGrowth { get; set; }


        // Свое событие обновления итогов.
        // Скрываем родительское.
        new public event UpdateEventHandler UpdateEvent;


        // Для сравнения с текущим годом.
        public const int LastYearEarnings = 1800000;


        // Путь к файлу базы данных.
        public override string PathTable => Constants.PathEarningsTable;


        // Инициализация общих итоговых данных.
        public EarningsTable() : base()
        {
            Total();
        }


        // Только для инициализации данных.
        public override void Init()
        {
            var r = new Random();

            Rows.Clear();

            for (int i = 0; i < 12; i++)
            {
                DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat;
                string month = dtfi.GetMonthName(i + 1);

                Row item = new Row
                {
                    Month = month,
                    Earnings = r.Next(80000, 260001),
                    NumCustomers = r.Next(300, 900)
                };

                Rows.Add(item);
            }

            Write();
        }



        // После родительского метода следует вычисление итогов.
        new public void Write()
        {
            base.Write();

            Total();

            // Событие обновления после записи и подсчёта итогов.
            // Скрыто родительское событие, 
            // поскольку родительское событие происходит
            // до подсчёта итогов.
            UpdateEvent?.Invoke(this);
        }



        // Вычисление итоговых значений.
        public void Total()
        {
            TotalEarning = 0;
            TotalCustomers = 0;

            foreach (var i in Rows)
            {
                TotalEarning += i.Earnings;
                TotalCustomers += i.NumCustomers;
            }

            MonthAverage = TotalEarning / Rows.Count;

            EarningsGrowth = (int)(TotalEarning / (double)LastYearEarnings * 100.0 - 100.0);
        }
    }
}

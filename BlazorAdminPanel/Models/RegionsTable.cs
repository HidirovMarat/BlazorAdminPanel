using BlazorAdminPanel.MyCode;
using System;



namespace BlazorAdminPanel.Models
{
    public class RegionsTable : Table
    {
        // Путь к файлам базы.
        public override string PathTable => Constants.PathRegionTable;


        public override void Init()
        {
            var r = new Random();


            Rows.Clear();


            Rows.Add(
                new Row()
                {
                    ISO = "RU",
                    Name = "Россия",
                    NumCustomers = r.Next(18000, 40000)
                }
            );

            Rows.Add(
                new Row()
                {
                    ISO = "UA",
                    Name = "Украина",
                    NumCustomers = r.Next(8000, 20000)
                }
            );

            Rows.Add(
                new Row()
                {
                    ISO = "US",
                    Name = "США",
                    NumCustomers = r.Next(3000, 10000)
                }
            );

            Rows.Add(
                new Row()
                {
                    ISO = "CA",
                    Name = "Канада",
                    NumCustomers = r.Next(2000, 8000)
                }
            );

            Rows.Add(
                new Row()
                {
                    ISO = "KZ",
                    Name = "Казахстан",
                    NumCustomers = r.Next(1000, 7000)
                }
            );

            Rows.Add(
                new Row()
                {
                    ISO = "DE",
                    Name = "Германия",
                    NumCustomers = r.Next(500, 5000)
                }
            );

            Rows.Add(
                new Row()
                {
                    ISO = "FR",
                    Name = "Франция",
                    NumCustomers = r.Next(500, 5000)
                }
            );

            Rows.Add(
                new Row()
                {
                    ISO = "CN",
                    Name = "Китай",
                    NumCustomers = r.Next(500, 5000)
                }
            );


            Write();

        }

    }
}

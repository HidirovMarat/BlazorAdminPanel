using BlazorAdminPanel.MyCode;
using System;


namespace BlazorAdminPanel.Models
{
    public class WebProgTable : Table
    {
        public override string PathTable => Constants.PathTechnologyTable;

        public override void Init()
        {
            var r = new Random();


            Rows.Clear();

            Rows.Add(
                new Row()
                {
                    Name = "PHP",
                    NumCustomers = r.Next(10000, 40000)
                }
            );

            Rows.Add(
                new Row()
                {
                    Name = "Python",
                    NumCustomers = r.Next(7000, 15000)
                }
            );

            Rows.Add(
                new Row()
                {
                    Name = "ASP.NET",
                    NumCustomers = r.Next(7000, 15000)
                }
            );

            Rows.Add(
                new Row()
                {
                    Name = "Perl",
                    NumCustomers = r.Next(3000, 10000)
                }
            );

            Rows.Add(
                new Row()
                {
                    Name = "Ruby",
                    NumCustomers = r.Next(3000, 10000)
                }
            );

            Write();
        }
    }
}

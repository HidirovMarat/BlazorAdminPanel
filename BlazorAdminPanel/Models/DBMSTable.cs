using BlazorAdminPanel.MyCode;
using System;

namespace BlazorAdminPanel.Models
{
    public class DBMSTable : Table
    {
        public override string PathTable => Constants.PathDBMSTable;


        public override void Init()
        {
            var r = new Random();


            Rows.Clear();

            Rows.Add(
                new Row()
                {
                    Name = "MySql",
                    NumCustomers = r.Next(10000, 40000)
                }
            );

            Rows.Add(
                new Row()
                {
                    Name = "MS SQL",
                    NumCustomers = r.Next(5000, 15000)
                }
            );

            Rows.Add(
                new Row()
                {
                    Name = "PostgreSQL",
                    NumCustomers = r.Next(5000, 9000)
                }
            );

            Rows.Add(
                new Row()
                {
                    Name = "MS Access",
                    NumCustomers = r.Next(1000, 5000)
                }
            );



            Write();
        }

    }
}

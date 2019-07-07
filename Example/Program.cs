using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            List<main_table> mainTableData = getMainTableData();
            using (var sqliteDbContext = new Model1("sqlite"))
            {
                var mainTableDataToSave = sqliteDbContext.main_table.Create();
                mainTableDataToSave = mainTableData[0];
                sqliteDbContext.main_table.Add(mainTableDataToSave);
                sqliteDbContext.SaveChanges();
            }
            int a = 0;
        }

        private static List<main_table> getMainTableData()
        {
            List<main_table> mainTableData = null;
            using (var msSqlDbContext = new Model1("mssql"))
            {
                mainTableData = msSqlDbContext.main_table.Include("employee").ToList();
            };
            return mainTableData;
        }
    }
}

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
            setDataDirectoryPath();

            List<main_table> mainTableData = getMainTableData();
            using (var sqliteDbContext = new Model1("sqliteRelativePath"))
            {
                var mainTableDataToSave = sqliteDbContext.main_table.Create();
                mainTableDataToSave = mainTableData[0];
                sqliteDbContext.main_table.Add(mainTableDataToSave);
                sqliteDbContext.SaveChanges();
            }
            int a = 0;
        }

        private static void setDataDirectoryPath()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            path = path.Replace(@"\bin\Debug", "");
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
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

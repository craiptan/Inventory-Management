using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace TestWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MergeFiles();
        }

        protected override void OnStop()
        {
            
        }
        public void MergeFiles()
        {
            Application app = new Application();

            app.Visible = true;
            app.DisplayAlerts = false;

            Workbook destinationWb = app.Workbooks.Add("");
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Christopher.Githui\Downloads\TestWorkbooks");
            foreach(var file in directoryInfo.GetFiles())
            {
                app.Workbooks.Add(file.FullName);
            }
            // Copy all worksheets
            Worksheet after = destinationWb.Worksheets[1];


            for (int wbIndex = app.Workbooks.Count; wbIndex >= 2; wbIndex--)
            {
                Workbook wb = app.Workbooks[wbIndex];
                for (int wsIndex = wb.Worksheets.Count; wsIndex >= 1; wsIndex--)
                {
                    Worksheet ws = wb.Worksheets[wsIndex];
                    ws.Copy(After: after);
                }
            }

            // Close source documents before saving destination. Otherwise, save will fail
            for (int wbIndex = 2; wbIndex <= app.Workbooks.Count; wbIndex++)
            {
                Workbook wb = app.Workbooks[wbIndex];
                wb.Close();
            }

            // Delete default worksheet
            after.Delete();

            // Save new workbook
            destinationWb.SaveAs(@"C:\Users\Christopher.Githui\Downloads\TestWorkbooks\Combinedworkbook.xlsx");
            destinationWb.Close();

            app.Quit();

        }
    }
}

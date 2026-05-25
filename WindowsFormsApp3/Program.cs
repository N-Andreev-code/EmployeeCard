using System;
using System.Windows.Forms;
using OfficeOpenXml;

namespace EmployeeCard
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Установка лицензии EPPlus 8+ для некоммерческого использования
            ExcelPackage.License.SetNonCommercialOrganization("MyPersonalProject");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
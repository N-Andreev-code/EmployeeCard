using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EmployeeCard
{
    public partial class Form1 : Form
    {
        private string photoPath = "";
        private string printLastName, printFirstName, printPosition, printDepartment;
        private Image printPhoto;

        public Form1()
        {
            InitializeComponent();
        }   

        private void btnLoadPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp|Все файлы|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                photoPath = openFileDialog1.FileName;
                pbPhoto.Image = Image.FromFile(photoPath);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printLastName = txtLastName.Text;
            printFirstName = txtFirstName.Text;
            printPosition = txtPosition.Text;
            printDepartment = txtDepartment.Text;
            printPhoto = pbPhoto.Image;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 12, FontStyle.Regular);
            int startX = 50;
            int startY = 50;
            int lineHeight = 30;

            g.DrawString("КАРТОЧКА СОТРУДНИКА", titleFont, Brushes.DarkBlue, startX, startY);
            g.DrawLine(Pens.DarkBlue, startX, startY + 40, 600, startY + 40);
            startY += 60;
            g.DrawString($"Фамилия: {printLastName}", textFont, Brushes.Black, startX, startY);
            startY += lineHeight;
            g.DrawString($"Имя: {printFirstName}", textFont, Brushes.Black, startX, startY);
            startY += lineHeight;
            g.DrawString($"Должность: {printPosition}", textFont, Brushes.Black, startX, startY);
            startY += lineHeight;
            g.DrawString($"Отдел: {printDepartment}", textFont, Brushes.Black, startX, startY);

            if (printPhoto != null)
            {
                startY += 20;
                int maxWidth = 150;
                int maxHeight = 200;
                double ratioX = (double)maxWidth / printPhoto.Width;
                double ratioY = (double)maxHeight / printPhoto.Height;
                double ratio = Math.Min(ratioX, ratioY);
                int newWidth = (int)(printPhoto.Width * ratio);
                int newHeight = (int)(printPhoto.Height * ratio);
                Bitmap newImage = new Bitmap(newWidth, newHeight);
                using (Graphics g2 = Graphics.FromImage(newImage))
                {
                    g2.DrawImage(printPhoto, 0, 0, newWidth, newHeight);
                }
                g.DrawImage(newImage, startX, startY);
            }

            g.DrawLine(Pens.Gray, startX, 800, 600, 800);
            g.DrawString($"Дата печати: {DateTime.Now.ToShortDateString()}", new Font("Arial", 8), Brushes.Gray, startX, 810);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (pbPhoto.Image == null)
            {
                MessageBox.Show("Загрузите фото сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel файлы|*.xlsx",
                FileName = $"Карточка_{txtLastName.Text}_{txtFirstName.Text}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Карточка сотрудника");
                        worksheet.Column(1).Width = 20;
                        worksheet.Column(2).Width = 40;

                        using (var range = worksheet.Cells["A1:B1"])
                        {
                            range.Merge = true;
                            range.Value = "КАРТОЧКА СОТРУДНИКА";
                            range.Style.Font.Bold = true;
                            range.Style.Font.Size = 16;
                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        }

                        worksheet.Cells["A3"].Value = "Фамилия:";
                        worksheet.Cells["B3"].Value = txtLastName.Text;
                        worksheet.Cells["A4"].Value = "Имя:";
                        worksheet.Cells["B4"].Value = txtFirstName.Text;
                        worksheet.Cells["A5"].Value = "Должность:";
                        worksheet.Cells["B5"].Value = txtPosition.Text;
                        worksheet.Cells["A6"].Value = "Отдел:";
                        worksheet.Cells["B6"].Value = txtDepartment.Text;
                        worksheet.Cells["A8"].Value = "Фото:";

                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            ms.Position = 0;
                            var picture = worksheet.Drawings.AddPicture("Photo", ms);
                            picture.SetPosition(7, 0, 1, 0);
                            picture.SetSize(150, 200);
                        }

                        using (var range = worksheet.Cells["A1:B6"])
                        {
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        FileInfo fileInfo = new FileInfo(saveDialog.FileName);
                        package.SaveAs(fileInfo);
                    }
                    MessageBox.Show("Экспорт выполнен успешно!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
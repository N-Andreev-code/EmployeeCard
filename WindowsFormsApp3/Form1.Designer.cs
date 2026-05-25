namespace EmployeeCard
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnLoadPhoto;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.btnLoadPhoto = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();

            // txtLastName
            this.txtLastName.Location = new System.Drawing.Point(120, 20);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 22);
            this.txtLastName.TabIndex = 0;

            // txtFirstName
            this.txtFirstName.Location = new System.Drawing.Point(120, 50);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);
            this.txtFirstName.TabIndex = 1;

            // txtPosition
            this.txtPosition.Location = new System.Drawing.Point(120, 80);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(200, 22);
            this.txtPosition.TabIndex = 2;

            // txtDepartment
            this.txtDepartment.Location = new System.Drawing.Point(120, 110);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(200, 22);
            this.txtDepartment.TabIndex = 3;

            // pbPhoto
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(120, 180);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(150, 200);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 4;
            this.pbPhoto.TabStop = false;

            // btnLoadPhoto
            this.btnLoadPhoto.Location = new System.Drawing.Point(120, 400);
            this.btnLoadPhoto.Name = "btnLoadPhoto";
            this.btnLoadPhoto.Size = new System.Drawing.Size(150, 30);
            this.btnLoadPhoto.TabIndex = 5;
            this.btnLoadPhoto.Text = "Загрузить фото";
            this.btnLoadPhoto.UseVisualStyleBackColor = true;
            this.btnLoadPhoto.Click += new System.EventHandler(this.btnLoadPhoto_Click);

            // btnPrint
            this.btnPrint.Location = new System.Drawing.Point(350, 180);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 40);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnExportExcel
            this.btnExportExcel.Location = new System.Drawing.Point(350, 240);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(150, 40);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "Экспорт в Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // printDocument1
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);

            // printPreviewDialog1
            this.printPreviewDialog1.Document = this.printDocument1;

            // openFileDialog1
            this.openFileDialog1.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp|Все файлы|*.*";

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Text = "Фамилия:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 53);
            this.label2.Name = "label2";
            this.label2.Text = "Имя:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Name = "label3";
            this.label3.Text = "Должность:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 113);
            this.label4.Name = "label4";
            this.label4.Text = "Отдел:";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnLoadPhoto);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Name = "Form1";
            this.Text = "Карточка сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
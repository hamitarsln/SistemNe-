using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemNe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool ikinci = false;

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (!ikinci)
            {
                ikinci = true;
                // RAM bilgisini alma
                ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject obj in ramSearcher.Get())
                {
                    label1.Text = "Toplam Ram: " + Convert.ToDouble(obj["TotalPhysicalMemory"]) / (1024 * 1024 * 1024) + " GB";
                }

                // İşlemci bilgisini alma
                ManagementObjectSearcher cpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject obj in cpuSearcher.Get())
                {
                    label2.Text = "İşlemci Adı: " + obj["Name"];
                    label3.Text = "İşlemci Sayısı: " + obj["NumberOfCores"];
                }

                // Ekran kartı bilgisini alma
                ManagementObjectSearcher gpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                foreach (ManagementObject obj in gpuSearcher.Get())
                {
                    label4.Text = "Ekran Kartı Adı: " + obj["Name"];
                    label5.Text = "Ekran Kartı Bellek Kapasitesi: " + Convert.ToDouble(obj["AdapterRAM"]) / (1024 * 1024 * 1024) + " GB";
                }

                // Depolama alanı bilgisini alma
                ManagementObjectSearcher driveSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject obj in driveSearcher.Get())
                {
                    label6.Text = "Depolama Modeli: " + obj["Model"];
                    label7.Text = "Depolama Alanı: " + Convert.ToDouble(obj["Size"]) / (1024 * 1024 * 1024) + " GB";
                }

                // Ana kart bilgisini alma
                ManagementObjectSearcher motherboardSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject obj in motherboardSearcher.Get())
                {
                    label8.Text = "Anakart Üreticisi: " + obj["Manufacturer"];
                    label9.Text = "Anakart Modeli: " + obj["Product"];
                }
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                guna2GradientButton1.Text = "Sistemimi Gizle";
                guna2GradientButton1.BorderRadius = 25;
                guna2GradientButton1.Location = new Point(28, 128);
                guna2GradientButton1.Size = new Size(180, 46);
            }

            else
            {
                ikinci = false;
                panel1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                guna2GradientButton1.BorderRadius = 45;
                guna2GradientButton1.Location = new Point(203, 168);
                guna2GradientButton1.Size = new Size(353, 95);
                guna2GradientButton1.Text = "Sistemimi Göster";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            guna2GradientButton1.BorderRadius = 45;
            guna2GradientButton1.Location = new Point(203, 168);
            guna2GradientButton1.Size = new Size(353, 95);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/hamitarsln");
        }
    }
}

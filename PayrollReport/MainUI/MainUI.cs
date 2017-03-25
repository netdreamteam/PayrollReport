using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MainUI
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
            this.panel_command.Visible = false;
            this.panel_table.Height += 136;
        }
        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                string s=fbd.SelectedPath;
            }
            
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            ExportMenu em = new ExportMenu();
            em.ShowDialog();
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog()==DialogResult.OK)
            //{
            //    string s = fbd.SelectedPath;
            //}
        }

        private void btn_command_Click(object sender, EventArgs e)
        {
            if (this.panel_command.Visible)
            {
                this.panel_command.Visible = false;
                this.panel_table.Height += 136;
            }
            else
            {
                this.panel_command.Visible = true;
                this.panel_table.Height -= 136;
            }
        }

        private void MainUI_ClientSizeChanged(object sender, EventArgs e)
        {

        }
    }
}

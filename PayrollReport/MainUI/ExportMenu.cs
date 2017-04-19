using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace MainUI
{
    public partial class ExportMenu : Form
    {
        private List<Payroll> _dataSource;
        private delegate void DelegateExport();
        private DelegateExport Export;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExportMenu()
        {
            InitializeComponent();
        }

        public ExportMenu(List<Payroll> _dataSource) : this()
        {
            this._dataSource = _dataSource;
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存路径点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_savePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txb_savePath.Text = fbd.SelectedPath;
            }
        }
        /// <summary>
        /// ok点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.txb_savePath.Text.ToString()))
            {
                MessageBox.Show(string.Format("[{0}]路径不存在,请重新选择", this.txb_savePath.Text.ToString()), "提示");
                return;
            }
            if (this.checkBox1.Checked == false && this.checkBox2.Checked == false && this.checkBox3.Checked == false && this.checkBox4.Checked == false)
            {
                MessageBox.Show("请选择要导出的报表", "提示");
                return;
            }
            if (checkBox4.Checked)
            {
                var t = new ImportTableFour(_dataSource, Path.Combine(txb_savePath.Text.ToString(), "4.xlsx"));
                this.Export += new DelegateExport(t.Run);
            }
            if (checkBox1.Checked)
            {
                var t = new ImportTableOne(_dataSource, txb_savePath.Text.ToString());
                this.Export += new DelegateExport(t.Run);

            }
            if (checkBox2.Checked)
            {
                ImportTableTwo t = new ImportTableTwo(_dataSource, Path.Combine(txb_savePath.Text.ToString(), "2.xlsx"));
                this.Export += new DelegateExport(t.Run);
            }
            if (checkBox3.Checked)
            {
                var t = new ImportTableThree(_dataSource, Path.Combine(txb_savePath.Text.ToString(), "3.xlsx"));
                this.Export += new DelegateExport(t.Run);
            }
            Export();
            this.Close();
            MessageBox.Show("导出成功","提示");
        }
    }
}

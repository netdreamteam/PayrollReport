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
using ExcelImport;
using Model;
using Controller;

namespace MainUI
{
    public partial class MainUI : Form
    {
        private Payroll _payroll;
        private Dictionary<string, List<string>> _condition = new Dictionary<string, List<string>>();
        private BusinessContext _bc;
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainUI()
        {
            InitializeComponent();
            this.panel_command.Visible = false;
            this.panel_table.Height += 136;
            _bc = new BusinessContext();
            _payroll = new Payroll();
            if (_bc.Payroll == null || _bc.Payroll.Count() == 0)
            {
                this.btn_command.Visible = false;
            }
            PagerInit(1, 30);
        }
        /// <summary>
        /// 导入按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_Click(object sender, EventArgs e)
        {
            //FileImportService(@"F:\code\PayrollReport\输入件\12");
            //FileImportService(@"H:\项目\PayrollReport\输入件");
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                FileImportService(fbd.SelectedPath);
            }

        }
        /// <summary>
        /// 数据源导入服务
        /// </summary>
        /// <param name="selectedPath"></param>
        private void FileImportService(string selectedPath)
        {
            List<string> pathList = new List<string>();
            foreach (string item in Directory.GetFiles(selectedPath))
            {
                if (item.EndsWith(".xls") || item.EndsWith(".xlsx"))
                {
                    pathList.Add(item);
                }
            }
            ImportHelper im = new ImportHelper();
            DataSet ds = im.ImportExcelFile(pathList);
            if (ds != null&& ds.Tables.Count>0)
            {
                this.btn_command.Visible = true;
                //for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                //{
                //    dataGridView1.Columns[i].HeaderCell.Value = ds.Tables[0].Columns[i].ColumnName;
                //}
            }
            AddSourceInfoController addSourceInfoController = new AddSourceInfoController();
            addSourceInfoController.Run(ds);
            bool flag = addSourceInfoController.Run(ds);
            if (!flag)
            {
                MessageBox.Show("添加数据到数据库失败","提示");
            }
            PagerInit(1, 30);
        }

        /// <summary>
        /// 导出按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            ExportMenu em = new ExportMenu();
            em.ShowDialog();

        }
        /// <summary>
        /// 筛选按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ComboBoxBinding();
            }
        }
        /// <summary>
        /// 下拉框数据绑定
        /// </summary>
        /// <returns></returns>
        private void ComboBoxBinding()
        {
            if (_bc.Payroll == null || _bc.Payroll.Count() == 0)
            {

                return;
            }

            this.cmb_xiashudanwei.DataSource = _bc.Payroll.Select(r => r.SubordinateNnits).Distinct().ToList();
            this.cmb_nianyue.DataSource = _bc.Payroll.Select(r => r.Years).Distinct().ToList();
            this.cmb_suozaigangwei.DataSource = _bc.Payroll.Select(r => r.PositionID).Distinct().ToList();
            this.cmb_gangweizhiji.DataSource = _bc.Payroll.Select(r => r.PostRankID).Distinct().ToList();
        }
        /// <summary>
        /// 页面初始化数据
        /// </summary>
        /// <param name="startPager">开始页面</param>
        /// <param name="num">一页显示的数量</param>
        private void PagerInit(int startPager, int num)
        {
            if (_bc.Payroll==null)
            {
                return;
            }
            
            int count = this._bc.Payroll.Count();
            if (count == 0)
            {
                return;
            }
            int pager = (count / num);
            if (count % 30 > 0)
            {
                pager += 1;
            }
            if (startPager <= 0)
            {
                startPager = 1;
            }
            if (startPager > pager)
            {
                startPager = pager;
            }
            this.txb_pager.Text = startPager.ToString();
            startPager -= 1;
            this.lbl_RecordCount.Text = string.Format("共【{0}】记录,每页【{1}】条记录,共【{2}】页", count, num, pager);
            this.dataGridView1.DataSource = _bc.Payroll.AsEnumerable().Skip(0 + startPager * num).Take(num).ToList();
            
        }

        private void btn_firstPage_Click(object sender, EventArgs e)
        {
            PagerInit(1, 30);
        }

        private void btn_before_Click(object sender, EventArgs e)
        {
            int result = 1;
            int.TryParse(this.txb_pager.Text, out result);
            PagerInit(result - 1, 30);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            int result = 1;
            int.TryParse(this.txb_pager.Text, out result);
            PagerInit(result + 1, 30);
        }

        private void btn_last_Click(object sender, EventArgs e)
        {

            PagerInit(1000000000, 30);
        }

        private void txb_pager_TextChanged(object sender, EventArgs e)
        {
            int result = 1;
            int.TryParse(this.txb_pager.Text, out result);
            PagerInit(result, 30);
        }

        private void btn_shuaixuan_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btn_xiashudanwei_Click(object sender, EventArgs e)
        {

            if (!_condition.ContainsKey("下属单位"))
            {

                _condition.Add("下属单位", new List<string>());
            }

            _condition["下属单位"].Add(cmb_xiashudanwei.SelectedValue.ToString());
            //this.cmb_xiashudanwei.DataSource = ComboBoxBinding(0);


            Condition();
        }

        private void btn_nianyue_Click(object sender, EventArgs e)
        {

            if (!_condition.ContainsKey("年月"))
            {

                _condition.Add("年月", new List<string>());
            }

            _condition["年月"].Add(cmb_nianyue.SelectedValue.ToString());
            //this.cmb_nianyue.Items.Remove(cmb_nianyue.SelectedValue);

            //this.cmb_nianyue.DataSource = ComboBoxBinding(1);

            Condition();
        }

        private void btn_suozaigangwei_Click(object sender, EventArgs e)
        {

            if (!_condition.ContainsKey("所在单位"))
            {

                _condition.Add("所在单位", new List<string>());
            }

            _condition["所在单位"].Add(cmb_suozaigangwei.SelectedValue.ToString());
            //this.cmb_suozaigangwei.Items.Remove(cmb_suozaigangwei.SelectedValue);

            //this.cmb_suozaigangwei.DataSource = ComboBoxBinding(4);
            Condition();
        }

        private void btn_gangweizhiji_Click(object sender, EventArgs e)
        {

            if (!_condition.ContainsKey("岗位职级"))
            {

                _condition.Add("岗位职级", new List<string>());
            }

            _condition["岗位职级"].Add(cmb_gangweizhiji.SelectedValue.ToString());
            //this.cmb_gangweizhiji.Items.Remove(cmb_gangweizhiji.SelectedValue);

            //this.cmb_gangweizhiji.DataSource = ComboBoxBinding(5);
            Condition();
        }
        /// <summary>
        /// 复原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {

            listView1.Clear();
            PagerInit(1, 30);
            this._condition.Clear();
        }

        private void btn_condition_Click(object sender, EventArgs e)
        {
            //ConditionUI cui = new ConditionUI(_condition);
            //cui.ShowDialog();

        }
        internal void Condition()
        {
            listView1.Clear();
            this.listView1.Columns.Add("类别", 90, HorizontalAlignment.Left);
            this.listView1.Columns.Add("条件", 90, HorizontalAlignment.Left);
            ListViewItem lvi = null;
            foreach (var item in _condition)
            {


                lvi = null;
                foreach (var item1 in item.Value)
                {
                    lvi = new ListViewItem();

                    lvi.Tag = item.Key;
                    lvi.Text = item.Key;
                    lvi.SubItems.Add(item1.ToString());
                    this.listView1.Items.Add(lvi);
                }
            }
        }
    }
}

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
        private DataSet _ds = new DataSet();
        private DataSet _dsOld = new DataSet();
        private Dictionary<int, List<string>> _condition = new Dictionary<int, List<string>>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainUI()
        {
            InitializeComponent();
            this.panel_command.Visible = false;
            this.panel_table.Height += 136;
        }
        /// <summary>
        /// 导入按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_Click(object sender, EventArgs e)
        {
            FileImportService(@"F:\code\PayrollReport\输入件\12");

            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    FileImportService(fbd.SelectedPath);
            //}

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
            _dsOld = im.ImportExcelFile(pathList);
            _ds = _dsOld;

            AddSourceInfoController addSourceInfoController = new AddSourceInfoController();
            addSourceInfoController.Run(_dsOld);

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
                this.cmb_xiashudanwei.DataSource = ComboBoxBinding(0);
                this.cmb_nianyue.DataSource = ComboBoxBinding(1);
                this.cmb_suozaigangwei.DataSource = ComboBoxBinding(4);
                this.cmb_gangweizhiji.DataSource = ComboBoxBinding(5);
            }
        }
        /// <summary>
        /// 下拉框数据绑定
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private List<object> ComboBoxBinding(int i)
        {
            if (_ds == null || _ds.Tables.Count == 0)
            {
                return new List<object>();
            }
            var sql =
                from dt in _ds.Tables[0].AsEnumerable()
                select dt.ItemArray[i];
            HashSet<object> hs = new HashSet<object>(sql.ToList());
            return hs.ToList();
        }
        private void PagerInit(int startPager, int num)
        {
            if (this._ds == null)
            {
                return;
            }
            int count = this._ds.Tables[0].Rows.Count;
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
            this.dataGridView1.DataSource = _ds.Tables[0].AsEnumerable().Skip(0 + startPager * num).Take(num).CopyToDataTable();

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
            PagerInit(100000, 30);
        }

        private void txb_pager_TextChanged(object sender, EventArgs e)
        {
            int result = 1;
            int.TryParse(this.txb_pager.Text, out result);
            PagerInit(result, 30);
        }

        private void btn_shuaixuan_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //if (_condition.Count==0)
            //{
            //    dt = _ds.Tables[0];
            //}
            //foreach (DataRow item in _ds.Tables[0].Rows)
            //{
            //    int i = 0;
            //    foreach (var con in _condition)
            //    {
            //        if (item[con.Value].ToString()!=con.Key)
            //        {
            //            break;
            //        }
            //        i++;
            //    }
            //    if (i== _condition.Count)
            //    {
            //        dt.Rows.Add(item);
            //    } 
            //}
            //_ds = new DataSet();
            //_ds.Tables.Add(dt);
            DataTable dt = _ds.Tables[0];
            foreach (var item in _condition)
            {
                if (dt.Rows.Count == 0)
                {
                    break;
                }
                var result = dt.AsEnumerable().Where(s => item.Value.Contains(s.ItemArray[item.Key].ToString()));
                if (result.Count() == 0)
                {
                    break;
                }
                dt = result.CopyToDataTable();
            }
            _ds = new DataSet();
            _ds.Tables.Add(dt.Copy());
            PagerInit(1, 30);
        }

        private void btn_xiashudanwei_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey(0))
            {
                _condition.Add(0, new List<string>());
            }
            _condition[0].Add(cmb_xiashudanwei.SelectedValue.ToString());
            //this.cmb_xiashudanwei.Items.Remove(cmb_xiashudanwei.SelectedValue);
        }

        private void btn_nianyue_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey(1))
            {
                _condition.Add(1, new List<string>());
            }
            _condition[1].Add(cmb_nianyue.SelectedValue.ToString());
            //this.cmb_nianyue.Items.Remove(cmb_nianyue.SelectedValue);
        }

        private void btn_suozaigangwei_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey(4))
            {
                _condition.Add(4, new List<string>());
            }
            _condition[4].Add(cmb_suozaigangwei.SelectedValue.ToString());
            //this.cmb_suozaigangwei.Items.Remove(cmb_suozaigangwei.SelectedValue);
        }

        private void btn_gangweizhiji_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey(5))
            {
                _condition.Add(5, new List<string>());
            }
            _condition[5].Add(cmb_gangweizhiji.SelectedValue.ToString());
            //this.cmb_gangweizhiji.Items.Remove(cmb_gangweizhiji.SelectedValue);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this._ds = _dsOld;
            PagerInit(1, 30);
            this._condition.Clear();
        }

        private void btn_condition_Click(object sender, EventArgs e)
        {
            ConditionUI cui = new ConditionUI(_condition);
        }
    }
}

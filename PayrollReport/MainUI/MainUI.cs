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
        private Dictionary<string, List<string>> _condition = new Dictionary<string, List<string>>();
        private BusinessContext _bc;
        private PayrollSearchCondition _conditionModel = new PayrollSearchCondition();
        private List<Payroll> _dataSource = new List<Payroll>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainUI()
        {
            InitializeComponent();
            this.panel_command.Visible = false;
            this.panel_table.Height += 136;
            _bc = new BusinessContext();
            if (_bc.Payroll == null || _bc.Payroll.Count() == 0)
            {
                this.btn_command.Visible = false;
            }
            _dataSource = _bc.Payroll.ToList();
            PagerInit(1, 30);
        }

        #region 导航栏
        /// <summary>
        /// 导入按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_Click(object sender, EventArgs e)
        {
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
                int j = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (!dataGridView1.Columns[i].Visible)
                    {
                        continue;
                    }
                    dataGridView1.Columns[i].HeaderCell.Value = ds.Tables[0].Columns[j].ColumnName;
                    j++;
                }
            }
            AddSourceInfoController addSourceInfoController = new AddSourceInfoController();
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
            ExportMenu em = new ExportMenu(_dataSource);
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
        /// 统计信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_summary_Click(object sender, EventArgs e)
        {
            var data = dataGridView1.DataSource as List<Payroll>;
            UIDataSummary ui = new UIDataSummary(data);
            ui.ShowDialog();
        }
        #endregion

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
            this.cmb_suozaigangwei.DataSource = _bc.Payroll.Select(r => r.PositionLink).Distinct().ToList();
            this.cmb_gangweizhiji.DataSource = _bc.Payroll.Select(r => r.PostRankLink).Distinct().ToList();
        }
        /// <summary>
        /// 页面初始化数据
        /// </summary>
        /// <param name="startPager">开始页面</param>
        /// <param name="num">一页显示的数量</param>
        private void PagerInit(int startPager, int num)
        {
            if (_dataSource == null)
            {
                return;
            }
            int count = _dataSource.Count;
            
            //if (count == 0)
            //{
            //    return;
            //}
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
            this.dataGridView1.DataSource = _dataSource.Skip(0 + startPager * num).Take(num).ToList();
            
        }

        #region 分页按钮
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
        #endregion
        #region 筛选条件
        private void btn_shuaixuan_Click(object sender, EventArgs e)
        {
            SearchConditionController search = new SearchConditionController();
            List<Payroll> result =search.SearchByCondition(_conditionModel);
            _dataSource = result;
            PagerInit(1, 30);

        }

        private void btn_xiashudanwei_Click(object sender, EventArgs e)
        {

            if (!_condition.ContainsKey("下属单位"))
            {
                _condition.Add("下属单位", new List<string>());

            }
            if (!_condition["下属单位"].Contains(cmb_xiashudanwei.SelectedValue.ToString()))
            {
                _condition["下属单位"].Add(cmb_xiashudanwei.SelectedValue.ToString());
                _conditionModel.SubordinateNnits.Add(cmb_xiashudanwei.SelectedValue.ToString());
            }
            Condition();
        }

        private void btn_suozaigangwei_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey("所在岗位"))
            {
                _condition.Add("所在岗位", new List<string>());
            }
            if (!_condition["所在岗位"].Contains(cmb_suozaigangwei.SelectedValue.ToString()))
            {
                _condition["所在岗位"].Add(cmb_suozaigangwei.SelectedValue.ToString());
                _conditionModel.PositionName.Add(cmb_suozaigangwei.SelectedValue.ToString());
            }
            Condition();
        }

        private void btn_gangweizhiji_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey("岗位职级"))
            {
                _condition.Add("岗位职级", new List<string>());
            }
            if (!_condition["岗位职级"].Contains(cmb_gangweizhiji.SelectedValue.ToString()))
            {
                _condition["岗位职级"].Add(cmb_gangweizhiji.SelectedValue.ToString());
                _conditionModel.PostRankName.Add(cmb_gangweizhiji.SelectedValue.ToString());
            }
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
            listView1.Visible = false;
            _dataSource = _bc.Payroll.ToList();
            PagerInit(1, 30);
            this._condition.Clear();
            this._conditionModel = new PayrollSearchCondition();
        }
        internal void Condition()
        {
            listView1.Clear();
            listView1.Visible = true;
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

        

        private void btn_date_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey("时间"))
            {
                _condition.Add("时间", new List<string>());

            }
            if (!_condition["时间"].Contains(string.Format("{0}-{1}",dtp_start.Value.ToString("yyyyMM"), dtp_stop.Value.ToString("yyyyMM"))))
            {
                _condition["时间"].Add(string.Format("{0}-{1}", dtp_start.Value.ToString("yyyyMM"), dtp_stop.Value.ToString("yyyyMM")));
                _conditionModel.StartYears = this.dtp_start.Value;
                _conditionModel.EndYears = this.dtp_stop.Value;
            }
            Condition();

        }
        

        private void btn_Name_Click(object sender, EventArgs e)
        {
            if (!_condition.ContainsKey("姓名"))
            {
                _condition.Add("姓名", new List<string>());
            }
            if (!_condition["姓名"].Contains(cmb_gangweizhiji.SelectedValue.ToString()))
            {
                _condition["姓名"].Add(txt_Name.Text.ToString());
                _conditionModel.Name.Add(txt_Name.Text.ToString());
            }
            Condition();
        }
        #endregion
    }
}

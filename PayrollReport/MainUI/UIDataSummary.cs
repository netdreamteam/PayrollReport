using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace MainUI
{
    public partial class UIDataSummary : Form
    {
        private List<Payroll> _data;

        public UIDataSummary()
        {
            InitializeComponent();
        }

        public UIDataSummary(List<Payroll> data)
            : this()
        {
            this._data = data;
            Run();
        }
        public void Run()
        {
            this.listView1.Clear();
            List<float> list = new List<float>();
            List<UIDataSummaryModel> uiModel = new List<UIDataSummaryModel>();
            this.listView1.Columns.Add("类别", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("最大值", 90, HorizontalAlignment.Left);
            this.listView1.Columns.Add("最小值", 90, HorizontalAlignment.Left);
            this.listView1.Columns.Add("平均值", 90, HorizontalAlignment.Left);
            ListViewItem lvi = null;
            list = _data.Select(s => s.Subtotal).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "Subtotal", MaxValue = list.Max().ToString(), MinValue = list.Min().ToString(), AvgValue = list.Average().ToString() });
            foreach (var item in uiModel)
            {
                lvi = new ListViewItem();
                lvi.Tag = item.Name;
                lvi.Text = item.Name;
                lvi.SubItems.Add(item.MaxValue.ToString());
                lvi.SubItems.Add(item.MinValue.ToString());
                lvi.SubItems.Add(item.AvgValue.ToString());
                this.listView1.Items.Add(lvi);
            }
            
        }
    }
}


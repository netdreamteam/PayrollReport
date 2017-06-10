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
            this.listView1.Columns.Add("类别", 150, HorizontalAlignment.Center);
            this.listView1.Columns.Add("最大值", 110, HorizontalAlignment.Center);
            this.listView1.Columns.Add("最小值", 110, HorizontalAlignment.Center);
            this.listView1.Columns.Add("平均值", 110, HorizontalAlignment.Center);
            ListViewItem lvi = null;
            this.listView1.GridLines = true;
            list = _data.Select(s => s.PostWage).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "岗位工资", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.MonthlyPerformancePay).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "月绩效工资", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.PerformancePay).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "考核绩效工资", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.SeniorityWage).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "工龄工资", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.TechnicalAllowance).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "技术津贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.ProfessionalAllowances).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "专业津贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.QuasiVehicleAllowances).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "准驾车型补贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.PostAllowance).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "岗位津贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.StaffServiceAllowance).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "排障员业务补贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.DustCharge).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "防尘费", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.NightAllowance).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "夜班补贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.HardshipAllowance).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "艰苦边远补贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.TollStationService).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "收费站业务补贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.SmileStar).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "微笑之星", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.JobReplacement).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "补发岗位工资", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.ReplacementPay).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "补发工资", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.PluggingIncome).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "堵漏增收", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.Other).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "其他", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.Reserve1).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "预留1", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.Reserve2).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "预留2", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.Subtotal).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "小计", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.HighSubsidies).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "高温补贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.CommunicationSubsidy).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "通讯补贴", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.OvertimePay).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "加班费", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.Debit).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "扣款", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.TotalShouldBeIssued).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "应发合计", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.NaturalYearEndPerformance).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "自然年度年终绩效", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
            list = _data.Select(s => s.AnnualYearEndPerformance).ToList();
            uiModel.Add(new UIDataSummaryModel() { Name = "所属年度年终绩效", MaxValue = list.Max().ToString("0.00"), MinValue = list.Min().ToString("0.00"), AvgValue = list.Average().ToString("0.00") });
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


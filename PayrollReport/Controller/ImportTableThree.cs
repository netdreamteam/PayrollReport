using Model;
using ReportExport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// 导出报表三
    /// </summary>
    public class ImportTableThree
    {
        /// <summary>
        /// 源数据表
        /// </summary>
        private List<Payroll> m_Payroll;
        /// <summary>
        /// 保存路径
        /// </summary>
        private string _savePath;
        /// <summary>
        /// 存储路径
        /// </summary>
        private string _path;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ImportTableThree(List<Payroll> payroll, string savePath,string path)
        {
            if (payroll == null)
            {
                m_Payroll = new List<Payroll>();
            }
            else
            {
                m_Payroll = payroll;
            }
            _savePath = savePath;
            _path = path;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public void Run()
        {
            List<ReportDetailed> result = new List<ReportDetailed>();
            if (m_Payroll == null)
            {
                return;
            }

            var itemGroupByPosition = m_Payroll.GroupBy(a => a.PositionLink.PositionName);
            foreach (var itemGBP in itemGroupByPosition)
            {
                var itemGroupBySSN = itemGBP.GroupBy(a => a.SocialSecurityNumber);
                foreach (var itemGSSN in itemGroupBySSN)
                {
                    var item = itemGSSN.First();

                    var reportItem = new ReportDetailed
                    {
                        PositionName = itemGBP.Key,
                        PostRankName = item.PostRankLink.PostRankName,
                        WorkTime = itemGSSN.Count(),
                        SocialSecurityNumber = item.SocialSecurityNumber,
                        Name = item.Name,
                        HighSubsidies = itemGSSN.Sum(a => a.HighSubsidies),
                        CommunicationSubsidy = itemGSSN.Sum(a => a.CommunicationSubsidy),
                        NaturalYearEndPerformance = itemGSSN.Sum(a => a.NaturalYearEndPerformance),
                        AnnualYearEndPerformance = itemGSSN.Sum(a => a.AnnualYearEndPerformance),
                    };
                    var jItem = GetPayRollByMonth("01", itemGSSN,reportItem.PositionName);
                    if (jItem != null)
                    {
                        reportItem.January = jItem.Sum(a=>a.TotalShouldBeIssued);
                    }
                    var febItem = GetPayRollByMonth("02", itemGSSN, reportItem.PositionName);
                    if (febItem != null)
                    {
                        reportItem.February = febItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var marItem = GetPayRollByMonth("03", itemGSSN, reportItem.PositionName);
                    if (marItem != null)
                    {
                        reportItem.March = marItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var apItem = GetPayRollByMonth("04", itemGSSN, reportItem.PositionName);
                    if (apItem != null)
                    {
                        reportItem.April = apItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var mayItem = GetPayRollByMonth("05", itemGSSN, reportItem.PositionName);
                    if (mayItem != null)
                    {
                        reportItem.May = mayItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var juneItem = GetPayRollByMonth("06", itemGSSN, reportItem.PositionName);
                    if (juneItem != null)
                    {
                        reportItem.June = juneItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var julyItem = GetPayRollByMonth("07", itemGSSN, reportItem.PositionName);
                    if (julyItem != null)
                    {
                        reportItem.July = julyItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var auItem = GetPayRollByMonth("08", itemGSSN, reportItem.PositionName);
                    if (auItem != null)
                    {
                        reportItem.August = auItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var sepItem = GetPayRollByMonth("09", itemGSSN, reportItem.PositionName);
                    if (sepItem != null)
                    {
                        reportItem.September = sepItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var octItem = GetPayRollByMonth("10", itemGSSN, reportItem.PositionName);
                    if (octItem != null)
                    {
                        reportItem.October = octItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var noveItem = GetPayRollByMonth("11", itemGSSN, reportItem.PositionName);
                    if (noveItem != null)
                    {
                        reportItem.November = noveItem.Sum(a => a.TotalShouldBeIssued);
                    }
                    var deceItem = GetPayRollByMonth("12", itemGSSN, reportItem.PositionName);
                    if (deceItem != null)
                    {
                        reportItem.December = deceItem.Sum(a => a.TotalShouldBeIssued);
                    }

                    result.Add(reportItem);
                }
                //汇总报表三的最大值、最小值、平均值
                //输出合计文件
                //输出所属年度绩效文件
                ReportDetailed Smax =result.Find(a=>a.AnnualYearEndPerformance==result.Max(x=>x.AnnualYearEndPerformance)) as ReportDetailed;
                ReportDetailed Smin = result.Find(a => a.AnnualYearEndPerformance == result.Min(x => x.AnnualYearEndPerformance)) as ReportDetailed;
                var Savg =result.Average(x => x.AnnualYearEndPerformance);
                string messageS = "Max("+Smax.AnnualYearEndPerformance+"):"+Smax.Name+"\r\nMin("+Smin.AnnualYearEndPerformance+"):"+Smin.Name+"\r\nAVG("+Savg+")";
                File.WriteAllText(Path.Combine(_path, "所属年度绩效.txt"), messageS);
                //输出自然年度绩效文件
                ReportDetailed Zmax = result.Find(a => a.NaturalYearEndPerformance == result.Max(x => x.NaturalYearEndPerformance)) as ReportDetailed;
                ReportDetailed Zmin = result.Find(a => a.NaturalYearEndPerformance == result.Min(x => x.NaturalYearEndPerformance)) as ReportDetailed;
                var Zavg = result.Average(x => x.NaturalYearEndPerformance);
                string messageZ = "Max(" + Smax.NaturalYearEndPerformance + "):" + Smax.Name + "\r\nMin(" + Smin.NaturalYearEndPerformance + "):" + Smin.Name + "\r\nAVG(" + Zavg+ ")";
                File.WriteAllText(Path.Combine(_path, "自然年度绩效.txt"), messageZ);
            }

            //导出报表三
            ReportExportByAspose export = new ReportExportByAspose();
            try
            {
                export.ExportReport(result, _savePath);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private IEnumerable<Payroll> GetPayRollByMonth(string monthStr, IGrouping<string, Payroll> itemGSSN,string postionName)
        {
            IEnumerable<Payroll> val = itemGSSN.Where(a => a.Years.EndsWith(monthStr) && a.PositionName == postionName);
            if (val.Count() > 0)
            {
                return val;
            }

            return null;
        }
    }
}

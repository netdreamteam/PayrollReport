using Model;
using ReportExport;
using System;
using System.Collections.Generic;
using System.Data;
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
        /// 构造函数
        /// </summary>
        public ImportTableThree(List<Payroll> payroll, string savePath)
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
                    var jItem = GetPayRollByMonth("01", itemGSSN);
                    if (jItem != null)
                    {
                        reportItem.January = jItem.Subtotal;
                    }
                    var febItem = GetPayRollByMonth("02", itemGSSN);
                    if (febItem != null)
                    {
                        reportItem.February = febItem.Subtotal;
                    }
                    var marItem = GetPayRollByMonth("03", itemGSSN);
                    if (marItem != null)
                    {
                        reportItem.March = marItem.Subtotal;
                    }
                    var apItem = GetPayRollByMonth("04", itemGSSN);
                    if (apItem != null)
                    {
                        reportItem.April = apItem.Subtotal;
                    }
                    var mayItem = GetPayRollByMonth("05", itemGSSN);
                    if (mayItem != null)
                    {
                        reportItem.May = mayItem.Subtotal;
                    }
                    var juneItem = GetPayRollByMonth("06", itemGSSN);
                    if (juneItem != null)
                    {
                        reportItem.June = juneItem.Subtotal;
                    }
                    var julyItem = GetPayRollByMonth("07", itemGSSN);
                    if (julyItem != null)
                    {
                        reportItem.July = julyItem.Subtotal;
                    }
                    var auItem = GetPayRollByMonth("08", itemGSSN);
                    if (auItem != null)
                    {
                        reportItem.August = auItem.Subtotal;
                    }
                    var sepItem = GetPayRollByMonth("09", itemGSSN);
                    if (sepItem != null)
                    {
                        reportItem.September = sepItem.Subtotal;
                    }
                    var octItem = GetPayRollByMonth("10", itemGSSN);
                    if (octItem != null)
                    {
                        reportItem.October = octItem.Subtotal;
                    }
                    var noveItem = GetPayRollByMonth("11", itemGSSN);
                    if (noveItem != null)
                    {
                        reportItem.November = noveItem.Subtotal;
                    }
                    var deceItem = GetPayRollByMonth("12", itemGSSN);
                    if (deceItem != null)
                    {
                        reportItem.December = deceItem.Subtotal;
                    }

                    result.Add(reportItem);
                }
            }

            //导出报表二
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

        private Payroll GetPayRollByMonth(string monthStr, IGrouping<string, Payroll> itemGSSN)
        {
            return itemGSSN.FirstOrDefault(a => a.Years.Contains(monthStr));
        }
    }
}

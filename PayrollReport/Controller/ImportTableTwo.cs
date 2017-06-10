using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using ReportExport;

namespace Controller
{
    /// <summary>
    /// 导出报表二
    /// </summary>
    public class ImportTableTwo
    {
        /// <summary>
        /// 源数据表
        /// </summary>
        private List<Payroll> m_Payroll;
        /// <summary>
        /// 月份字典
        /// </summary>
        private Dictionary<string, string> _dicMonth = new Dictionary<string, string>();
        /// <summary>
        /// 保存路径
        /// </summary>
        private string _savePath;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ImportTableTwo(List<Payroll> payroll,string savePath)
        {
            if (payroll == null)
            {
                m_Payroll = new List<Payroll>();
            }
            else
            {
                m_Payroll = payroll;
            }
            SetYearDic();
            _savePath = savePath;
        }

        /// <summary>
        /// 创建月份字典
        /// </summary>
        private void SetYearDic()
        {
            _dicMonth["01"] = "January";
            _dicMonth["02"] = "February";
            _dicMonth["03"] = "March";
            _dicMonth["04"] = "April";
            _dicMonth["05"] = "May";
            _dicMonth["06"] = "June";
            _dicMonth["07"] = "July";
            _dicMonth["08"] = "August";
            _dicMonth["09"] = "September";
            _dicMonth["10"] = "October";
            _dicMonth["11"] = "November";
            _dicMonth["12"] = "December";
        }

        

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public void Run()
        {
            List<ReportAnnualWage> listResult=new List<ReportAnnualWage>();
            
            var groupComValues = m_Payroll.AsEnumerable().GroupBy(a=>a.SubordinateNnits);
            foreach (var gr in groupComValues)
            {
                ReportAnnualWage result = new ReportAnnualWage();
                
                result.CompanyName = gr.Key;
                var groupYearValues = gr.GroupBy(r => r.Years);
                foreach (var gy in groupYearValues)
                {
                    SetYearValue(result,gy.Key.Substring(4),gy.Sum(r=>r.TotalShouldBeIssued));
                }
                //添加自然年度绩效合计
                result.NaturalYearEndPerformance = gr.Sum(a => a.NaturalYearEndPerformance);
                float subSum = 0;
                if (result.January != null)
                {
                    subSum += (float)result.January;
                }
                if (result.February != null)
                {
                    subSum += (float)result.February;
                }
                if (result.March != null)
                {
                    subSum += (float)result.March;
                }
                if (result.April != null)
                {
                    subSum += (float)result.April;
                }
                if (result.May != null)
                {
                    subSum += (float)result.May;
                }
                if (result.June != null)
                {
                    subSum += (float)result.June;
                }
                if (result.July != null)
                {
                    subSum += (float)result.July;
                }
                if (result.August != null)
                {
                    subSum += (float)result.August;
                }
                if (result.September != null)
                {
                    subSum += (float)result.September;
                }
                if (result.October != null)
                {
                    subSum += (float)result.October;
                }
                if (result.November != null)
                {
                    subSum += (float)result.November;
                }
                if (result.December != null)
                {
                    subSum += (float)result.December;
                }
                //添加自然年度合计 合计
                result.NaturalYearEndSum = subSum + result.NaturalYearEndPerformance;
                //添加所属年度绩效合计
                result.AnnualYearEndPerformance = gr.Sum(a => a.AnnualYearEndPerformance);
                //添加所属年度合计 合计
                result.AnnualYearEndSum = subSum + result.AnnualYearEndPerformance;
                listResult.Add(result);
            }
            //导出报表二
            ReportExportByAspose export=new ReportExportByAspose();
            try
            {
                export.ExportReport(listResult, _savePath);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void SetYearValue(ReportAnnualWage result,string year,float value)
        {
            Type type = typeof (ReportAnnualWage);
            var property = type.GetProperties().FirstOrDefault(r => r.Name == _dicMonth[year]);
            if (property != null)
            {
                property.SetValue(result, value);
            }
        }
    }
}

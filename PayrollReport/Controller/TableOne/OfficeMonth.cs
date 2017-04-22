using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.TableOne
{
    /// <summary>
    /// 总公司月汇总表
    /// </summary>
    public class OfficeMonth
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
        /// <param name="payroll">源数据表</param>
        public OfficeMonth(List<Payroll> payroll, string path)
        {
            if (payroll == null)
            {
                m_Payroll = new List<Payroll>();
            }
            else
            {
                m_Payroll = payroll;
            }

            _savePath = path;
        }

        public void Run()
        {
            if (m_Payroll == null || m_Payroll.Count == 0)
            {
                return;
            }
            //key:公司名称,value:数据
            Dictionary<string, List<ReportPost>> dicResult = new Dictionary<string, List<ReportPost>>();
            List<ReportPost> result = new List<ReportPost>();

            var itemsGroupByYears = m_Payroll.GroupBy(a => a.Years);
            foreach (var itemsGBY in itemsGroupByYears)
            {
                OfficeYear oYear = new OfficeYear(itemsGBY.ToList(), _savePath + "/" + itemsGBY.Key + "/");
                oYear.Run(itemsGBY.Key);
            }
        }
    }
}

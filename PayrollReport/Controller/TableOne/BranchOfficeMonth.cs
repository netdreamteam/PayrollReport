using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.TableOne
{
    /// <summary>
    /// 分公司每月
    /// </summary>
    public class BranchOfficeMonth
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
        public BranchOfficeMonth(List<Payroll> payroll, string path)
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
                BranchOfficeYear boYear = new BranchOfficeYear(itemsGBY.ToList(), _savePath + "/" + itemsGBY.Key + "/");
                boYear.Run(itemsGBY.Key);
            }
        }
    }
}

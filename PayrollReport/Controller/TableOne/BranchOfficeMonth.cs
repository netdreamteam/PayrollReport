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
        /// 构造函数
        /// </summary>
        /// <param name="payroll">源数据表</param>
        public BranchOfficeMonth(List<Payroll> payroll)
        {
            if (payroll == null)
            {
                m_Payroll = new List<Payroll>();
            }
            else
            {
                m_Payroll = payroll;
            }
        }

        public void Run()
        {
            //key:公司名称,value:数据
            Dictionary<string, List<ReportPost>> dicResult = new Dictionary<string, List<ReportPost>>();
            List<ReportPost> result = new List<ReportPost>();

            var itemsGroupByOffice = m_Payroll.GroupBy(a => a.SubordinateNnits);
            foreach (var itemsGBO in itemsGroupByOffice)
            {

            }
        }
    }
}

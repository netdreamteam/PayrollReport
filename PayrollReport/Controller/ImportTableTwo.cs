using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

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
        /// 构造函数
        /// </summary>
        public ImportTableTwo(List<Payroll> payroll)
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

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public ReportAnnualWage Run()
        {
            ReportAnnualWage result = new ReportAnnualWage();

            return result;
        }
    }
}

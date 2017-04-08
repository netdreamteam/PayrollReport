using Model;
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
        /// 构造函数
        /// </summary>
        public ImportTableThree(List<Payroll> payroll)
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
        public ReportDetailed Run()
        {
            ReportDetailed result = new ReportDetailed();

            return result;
        }
    }
}

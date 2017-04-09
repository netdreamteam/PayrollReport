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
    /// 导出报表一
    /// </summary>
    public class ImportTableOne
    {
        /// <summary>
        /// 源数据表
        /// </summary>
        private List<Payroll> m_Payroll;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dt">源数据表</param>
        public ImportTableOne(List<Payroll> payroll)
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
        public List<ReportPost> Run()
        {
            List<ReportPost> result = new List<ReportPost>();
            if (m_Payroll.Count > 0)
            {
                var values = m_Payroll.AsEnumerable().GroupBy(a => a.PositionID);
                foreach (var value in values)
                {
                    foreach (var val in value)
                    {
                        Dictionary<string, List<ReportPost>> dic = new Dictionary<string, List<ReportPost>>();
                        List<ReportPost> listReport = new List<ReportPost>();
                        ReportPost report = new ReportPost();
                        
                    }
                }
            }
            return result;
        }
    }
}

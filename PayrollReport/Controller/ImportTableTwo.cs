using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
        private DataTable m_table;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ImportTableTwo(DataTable dt)
        {
            if (dt == null)
            {
                m_table = new DataTable();
            }
            else
            {
                m_table = dt;
            }
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public DataTable Run()
        {
            DataTable dtResult = new DataTable();

            return dtResult;
        }
    }
}

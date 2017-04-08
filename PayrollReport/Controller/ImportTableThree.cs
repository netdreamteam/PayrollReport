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
        private DataTable m_table;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ImportTableThree(DataTable dt)
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

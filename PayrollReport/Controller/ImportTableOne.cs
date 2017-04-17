using Controller.TableOne;
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
        /// 保存路径
        /// </summary>
        private string _savePath;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dt">源数据表</param>
        public ImportTableOne(List<Payroll> payroll, string path)
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

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public void Run()
        {
            //初始化数据
            CommonStrInfo common = new CommonStrInfo();
            //分公司年汇总
            BranchOfficeYear branchOfficeYear = new BranchOfficeYear(m_Payroll, _savePath + "/分公司汇总表/");
            branchOfficeYear.Run();
            //分公司月汇总

            //总公司年汇总
            OfficeYear o = new OfficeYear(m_Payroll, _savePath);
            o.Run();
            //总公司月汇总
        }
    }
}

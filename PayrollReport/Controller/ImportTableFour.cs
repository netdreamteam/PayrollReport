using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ReportExport;

namespace Controller
{
    /// <summary>
    /// 导出报表四（筛选后的数据源表）
    /// </summary>
    public class ImportTableFour
    {
        /// <summary>
        /// 导出数据源
        /// </summary>
        private List<Payroll> _listPayrolls;
        /// <summary>
        /// 保存路径
        /// </summary>
        private string _savePath;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="payroll">导出数据源</param>
        /// <param name="savePath">保存路径</param>
        public ImportTableFour(List<Payroll> payrolls,string savePath)
        {
            _listPayrolls = payrolls;
            _savePath = savePath;
        }

        /// <summary>
        /// 执行
        /// </summary>
        public void Run()
        {
            ReportExportByAspose export=new ReportExportByAspose();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("Year",string.Format("公司{0}年工资表",_listPayrolls.First().Years.Substring(0,4)));
            export.ExportReport(_listPayrolls,_savePath,dictionary);
        }
    }
}

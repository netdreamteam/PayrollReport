using Model;
using ReportExport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.TableOne
{
    public class OfficeYear
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
        public OfficeYear(List<Payroll> payroll, string path)
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

        public void Run(string month = "")
        {
            if (m_Payroll == null || m_Payroll.Count == 0)
            {
                return;
            }

            BranchOfficeYear b = new BranchOfficeYear(m_Payroll, _savePath);
            Dictionary<string, List<ReportPost>> dicResult = b.OutUsing(m_Payroll);

            //导出数据

            //导出报表三
            ReportExportByAspose export = new ReportExportByAspose();
            try
            {
                var path = Path.Combine(_savePath, "总公司年汇总表" + month + ".xlsx");
                if (!Directory.Exists(_savePath))
                {
                    Directory.CreateDirectory(_savePath);
                }
                export.ExportReportDic(path, dicResult, "总公司", month);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
    }
}


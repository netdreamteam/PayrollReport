using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Aspose.Cells;
using System.Reflection;

namespace ReportExport
{
    public class ReportExportByAspose
    {
        /// <summary>
        /// 导出岗位工资报表
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="month"></param>
        /// <param name="dicReportLeader"></param>
        public void ExportPostWage(string companyName, string month, Dictionary<string, List<ReportPost>> dicReportLeader)
        {
            WorkbookDesigner designer = new WorkbookDesigner();
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTemplate\\ReportPost.xls");

            designer.Workbook = new Workbook(path);
            designer.SetDataSource("Company", companyName);
            designer.SetDataSource("Month", month);
            foreach (var item in dicReportLeader)
            {
                designer.SetDataSource(item.Key, item.Value);
            }
            //根据数据源处理生成报表内容
            designer.Process();

            //保存Excel文件
            string fileToSave = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartMarker.xls");
            designer.Workbook.Save(fileToSave);
        }

        public void ExportReportAnnualWage(List<ReportAnnualWage> listData)
        {
            WorkbookDesigner designer = new WorkbookDesigner();
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTemplate\\AnnualWage.xlsx");

            designer.Workbook = new Workbook(path);
            designer.SetDataSource("ReportAnnualWage", listData);
            //根据数据源处理生成报表内容
            designer.Process();

            //保存Excel文件
            string fileToSave = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnnualWage1.xlsx");
            designer.Workbook.Save(fileToSave);
        }
    }
}

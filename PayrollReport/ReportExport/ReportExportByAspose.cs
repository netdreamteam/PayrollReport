using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Aspose.Cells;
using System.Reflection;
using System.IO;

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
        public void ExportPostWage(string companyName, string month, Dictionary<string, List<ReportPost>> dicReportLeader,string reportFile)
        {
            WorkbookDesigner designer = new WorkbookDesigner();
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTemplate\\ReportPost.xlsx");

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
            //string fileToSave = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartMarker.xls");
            designer.Workbook.Save(reportFile);
        }

        public void ExportReport<T>(List<T> listData,string reportFile,Dictionary<string,object> dicVariable=null)
        {
            WorkbookDesigner designer = new WorkbookDesigner();
            string typeName = typeof (T).Name;
            string muban = string.Format("ReportTemplate\\{0}.xlsx", typeName);
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, muban);

            designer.Workbook = new Workbook(path);
            designer.SetDataSource(typeName, listData);
            if (dicVariable != null)
            {
                foreach (var item in dicVariable)
                {
                    designer.SetDataSource(item.Key, item.Value);
                }
                
            }
            //根据数据源处理生成报表内容
            designer.Process();
            //保存Excel文件
            designer.Workbook.Save(reportFile);
        }

        public void ExportReportDic<T>(string reportFile, Dictionary<string, List<T>> dicVariable = null)
        {
            WorkbookDesigner designer = new WorkbookDesigner();
            string typeName = typeof(T).Name;
            string muban = string.Format("ReportTemplate\\{0}.xlsx", typeName);
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, muban);

            designer.Workbook = new Workbook(path);
            if (dicVariable != null)
            {
                foreach (var item in dicVariable)
                {
                    designer.SetDataSource(item.Key, item.Value);
                }

            }
            //根据数据源处理生成报表内容
            designer.Process();
            //保存Excel文件
            designer.Workbook.Save(reportFile);
        }

        //public void ExportReportDetailed(List<ReportDetailed> listData,string reportFile)
        //{
        //    WorkbookDesigner designer = new WorkbookDesigner();
        //    string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTemplate\\ReportDetailed.xlsx");

        //    designer.Workbook = new Workbook(path);
        //    designer.SetDataSource("ReportDetailed", listData);
        //    //根据数据源处理生成报表内容
        //    designer.Process();
        //    //保存Excel文件
        //    designer.Workbook.Save(reportFile);
        //}

        //public void ExportReportAnnualWage(List<ReportAnnualWage> listData,string reportFile)
        //{
        //    WorkbookDesigner designer = new WorkbookDesigner();
        //    string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTemplate\\AnnualWage.xlsx");

        //    designer.Workbook = new Workbook(path);
        //    designer.SetDataSource("ReportAnnualWage", listData);
        //    //根据数据源处理生成报表内容
        //    designer.Process();

        //    //保存Excel文件
        //    designer.Workbook.Save(reportFile);
        //}
    }
}

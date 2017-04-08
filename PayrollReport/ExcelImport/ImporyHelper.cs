using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelImport
{
    /// <summary>
    /// Excxel导入
    /// </summary>
    public class ImportHelper
    {
        /// <summary>
        /// NPOI导入Excel
        /// </summary>
        /// <param name="listFileNames">文件名集合</param>
        /// <returns></returns>
        #region
        public DataSet ImportExcelFile(List<string> listFileNames)
        {
            DataSet ds = new DataSet();
            int dataNum = 0;
            try
            {
                foreach (string fileName in listFileNames)
                {
                    dataNum++;
                    if (string.Compare(Path.GetExtension(fileName), ".xlsx", true).Equals(0))
                    {
                        DataTable dt = new DataTable();
                        dt = ReadDataBy07(fileName);
                        dt.TableName = string.Format("数据源{0}", dataNum);
                        ds.Tables.Add(dt);
                    }
                    else if (string.Compare(Path.GetExtension(fileName), ".xls", true).Equals(0))
                    {
                        DataTable dt = new DataTable();
                        dt = ReadDataBy03(fileName);
                        dt.TableName = string.Format("数据源{0}", dataNum);
                        ds.Tables.Add(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return ds;
        }
        #endregion

        #region 按版本读取Excel

        /// <summary>
        /// 07版Excel读取
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private DataTable ReadDataBy07(string fileName)
        {
            DataTable dt = new DataTable();
            XSSFWorkbook hssfworkbook;
            XSSFRow row;
            int rowNum = 0;
            int sheetNum = 0;
            #region 初始化信息
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new XSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion
            foreach (XSSFSheet sheet in hssfworkbook)
            {
                if (sheet.SheetName == "源数据")
                {
                    #region 只读取源数据sheet页
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    dt.TableName = sheet.SheetName;
                    //构建表头
                    if (sheetNum.Equals(0))
                    {
                        row = (XSSFRow)sheet.GetRow(1);
                    }
                    else
                    {
                        row = (XSSFRow)sheet.GetRow(0);
                    }
                    sheetNum++;
                    for (int j = 0; j < (row.LastCellNum); j++)
                    {
                        if (dt.Columns.Contains(row.Cells[j].ToString()))
                        {
                            dt.Columns.Add(row.Cells[j].ToString() + "_");
                        }
                        else
                        {
                            dt.Columns.Add(row.Cells[j].ToString());
                        }
                    }
                    foreach (XSSFRow xsRow in sheet)
                    {
                        if (rowNum >= 2)
                        {
                            if (!xsRow.GetCell(0).ToString().Contains("公司"))
                            {
                                break;
                            }
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                NPOI.SS.UserModel.ICell cell = xsRow.GetCell(i);
                                if (cell == null)
                                {
                                    dr[i] = DBNull.Value;
                                    continue;
                                }
                                switch (cell.CellType)
                                {
                                    case CellType.Blank:
                                        dr[i] = DBNull.Value;
                                        break;
                                    case CellType.Boolean:
                                        dr[i] = cell.BooleanCellValue;
                                        break;
                                    case CellType.Error:
                                        dr[i] = cell.ErrorCellValue;
                                        break;
                                    case CellType.Formula:
                                        try
                                        {
                                            dr[i] = cell.NumericCellValue;
                                        }
                                        catch
                                        {
                                            dr[i] = cell.ToString();
                                        }
                                        break;
                                    case CellType.Numeric:
                                        dr[i] = cell.NumericCellValue;
                                        break;
                                    case CellType.String:
                                        dr[i] = cell.RichStringCellValue;
                                        break;
                                    case CellType.Unknown:
                                        break;
                                    default:
                                        dr[i] = cell.ToString();
                                        break;
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                        rowNum++;
                    }
                    #endregion
                }
            }

            return dt;

        }

        /// <summary>
        /// 03版Excel读取
        /// </summary>
        /// <returns></returns>
        private DataTable ReadDataBy03(string fileName)
        {
            DataTable dt = new DataTable();
            HSSFWorkbook hssfworkbook;
            HSSFRow row;
            int rowNum = 0;
            int sheetNum = 0;
            #region 初始化信息
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion
            foreach (HSSFSheet sheet in hssfworkbook)
            {
                if (sheet.SheetName.Equals("源数据"))
                {
                    #region 只读取源数据sheet页
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    dt.TableName = sheet.SheetName;
                    //构建表头
                    if (sheetNum.Equals(0))
                    {
                        row = (HSSFRow)sheet.GetRow(1);
                    }
                    else
                    {
                        row = (HSSFRow)sheet.GetRow(0);
                    }
                    sheetNum++;
                    for (int j = 0; j < (row.LastCellNum); j++)
                    {
                        if (dt.Columns.Contains(row.Cells[j].ToString()))
                        {
                            dt.Columns.Add(row.Cells[j].ToString() + "_");
                        }
                        else
                        {
                            dt.Columns.Add(row.Cells[j].ToString());
                        }
                    }
                    foreach (HSSFRow xsRow in sheet)
                    {
                        if (rowNum >= 2)
                        {
                            if (!xsRow.GetCell(0).ToString().Contains("公司"))
                            {
                                break;
                            }
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                NPOI.SS.UserModel.ICell cell = xsRow.GetCell(i);
                                if (cell == null)
                                {
                                    dr[i] = DBNull.Value;
                                    continue;
                                }
                                switch (cell.CellType)
                                {
                                    case CellType.Blank:
                                        dr[i] = DBNull.Value;
                                        break;
                                    case CellType.Boolean:
                                        dr[i] = cell.BooleanCellValue;
                                        break;
                                    case CellType.Error:
                                        dr[i] = cell.ErrorCellValue;
                                        break;
                                    case CellType.Formula:
                                        try
                                        {
                                            dr[i] = cell.NumericCellValue;
                                        }
                                        catch
                                        {
                                            dr[i] = cell.ToString();
                                        }
                                        break;
                                    case CellType.Numeric:
                                        dr[i] = cell.NumericCellValue;
                                        break;
                                    case CellType.String:
                                        dr[i] = cell.RichStringCellValue;
                                        break;
                                    case CellType.Unknown:
                                        break;
                                    default:
                                        dr[i] = cell.ToString();
                                        break;
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                        rowNum++;
                    }
                    #endregion
                }
            }

            return dt;
        }
        #endregion
    }
}

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
    /// <summary>
    /// 分公司年汇总
    /// </summary>
    public class BranchOfficeYear
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
        public BranchOfficeYear(List<Payroll> payroll, string path)
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

        public void Run()
        {
            //key:公司名称,value:数据
            Dictionary<string, Dictionary<string, List<ReportPost>>> dicCompanyResult = new Dictionary<string, Dictionary<string, List<ReportPost>>>();

            //1.根据公司(下属单位)分组
            var itemsGroupByOffice = m_Payroll.GroupBy(a => a.SubordinateNnits);
            foreach (var itemsGBO in itemsGroupByOffice)
            {
                //key:所在岗位,value：数据
                Dictionary<string, List<ReportPost>> dicResult = new Dictionary<string, List<ReportPost>>();
                //2.根据所在岗位筛选
                foreach (var position in CommonStrInfo.DicPosition)
                {
                    //3.判断岗位是否是特殊岗位
                    //(1)."所在岗位”和“岗位职级"交换的以及劳务派遣人员信息
                    if (CommonStrInfo.DicPositionChange.Keys.Contains(position.Value))
                    {
                        AddInfoByChange(itemsGBO, dicResult, position.Value, true);
                    }
                    //（2）.正常情况
                    else
                    {
                        AddInfoByPosition(itemsGBO, dicResult, position.Key, position.Value);
                    }
                }

                dicCompanyResult.Add(itemsGBO.Key, dicResult);
            }

            //导出数据

            //导出报表三
            ReportExportByAspose export = new ReportExportByAspose();
            try
            {
                foreach (var key in dicCompanyResult.Keys)
                {
                    var path = Path.Combine(_savePath + "/分公司汇总表/", key + ".xlsx");
                    if (!Directory.Exists(_savePath + "/分公司汇总表/"))
                    {
                        Directory.CreateDirectory(_savePath + "/分公司汇总表/");
                    }
                    export.ExportReportDic(path, dicCompanyResult[key]);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        private void AddInfoByChange(IGrouping<string, Payroll> itemsGBO, Dictionary<string, List<ReportPost>> dicResult, string key, bool isChange = false)
        {
            foreach (var positionList in CommonStrInfo.DicPositionChange.Where(a => a.Key.Equals(key)))
            {
                List<ReportPost> result = new List<ReportPost>();
                AddInfoByPostionList(itemsGBO, positionList.Value, result, isChange);
                dicResult.Add(positionList.Key, result);
            }
        }

        private void AddInfoByPostionList(IGrouping<string, Payroll> itemsGBO, List<string> positionList, List<ReportPost> result, bool isChange = false)
        {
            foreach (var pItem in positionList)
            {
                var items = itemsGBO.Where(a => a.PositionName.Equals(pItem));
                if (items.Count() == 0)
                {
                    continue;
                }
                var item = items.First();
                var notWage = items.Where(a => a.WageAttribute.Equals("未发")).Select(a => a.Name);
                var reuserWage = items.Where(a => a.WageAttribute.Equals("补发")).Select(a => a.Name);
                ReportPost model = new ReportPost()
                {
                    PositionName = item.PositionName,
                    PostRankName = isChange ? item.PositionName : item.PostRankName,
                    AlreadyCount = items.Count(a => string.IsNullOrEmpty(a.WageAttribute) || a.WageAttribute.Equals("正常")),
                    NotCount = notWage.Count(),
                    ReuseCount = reuserWage.Count(),
                    NotName = string.Join(",", notWage),
                    ReuseName = string.Join(",", reuserWage),
                    PostWage = items.Sum(a => a.PostWage),
                    MonthlyPerformancePay = items.Sum(a => a.MonthlyPerformancePay),
                    SeniorityWage = items.Sum(a => a.SeniorityWage),
                    TechnicalAllowance = items.Sum(a => a.TechnicalAllowance),
                    PostAllowance = items.Sum(a => a.PostAllowance),
                    OvertimePay = items.Sum(a => a.OvertimePay),
                    DustCharge = items.Sum(a => a.DustCharge),
                    NightAllowance = items.Sum(a => a.NightAllowance),
                    HardshipAllowance = items.Sum(a => a.HardshipAllowance),
                    TollStationService = items.Sum(a => a.TollStationService),
                    ReplacementPay = items.Sum(a => a.ReplacementPay),
                    HighSubsidies = items.Sum(a => a.HighSubsidies),
                    CommunicationSubsidy = items.Sum(a => a.CommunicationSubsidy),
                    Reserve1 = items.Sum(a => a.Reserve1),
                    Reserve2 = items.Sum(a => a.Reserve2),
                    Other = items.Sum(a => a.Other),
                    NaturalYearEndPerformance = items.Sum(a => a.NaturalYearEndPerformance),
                    AnnualYearEndPerformance = items.Sum(a => a.AnnualYearEndPerformance)
                };
                result.Add(model);
            }
        }

        /// <summary>
        /// 正常情况
        /// </summary>
        /// <param name="itemsGBO"></param>
        /// <param name="dicResult"></param>
        /// <param name="position"></param>
        private void AddInfoByPosition(IGrouping<string, Payroll> itemsGBO, Dictionary<string, List<ReportPost>> dicResult, string positionName, string positionNameEn)
        {
            //根据岗位名称查数据库所有数据
            var itemsGBOByPN = itemsGBO.Where(a => a.PositionName.Equals(positionName));
            if (itemsGBOByPN.Count() == 0)
            {
                return;
            }
            //4.根据岗位职级分组
            var itemsGroupByPostRank = itemsGBOByPN.GroupBy(a => a.PostRankName);
            List<ReportPost> result = new List<ReportPost>();

            foreach (var itemsGBPR in itemsGroupByPostRank)
            {
                var item = itemsGBPR.First();

                var notWage = itemsGBPR.Where(a => a.WageAttribute.Equals("未发")).Select(a => a.Name);
                var reuserWage = itemsGBPR.Where(a => a.WageAttribute.Equals("补发")).Select(a => a.Name);
                ReportPost model = new ReportPost
                {
                    PositionName = item.PositionName,
                    PostRankName = item.PostRankName,
                    AlreadyCount = itemsGBPR.Count(a => string.IsNullOrEmpty(a.WageAttribute) || a.WageAttribute.Equals("正常")),
                    NotCount = notWage.Count(),
                    ReuseCount = reuserWage.Count(),
                    NotName = string.Join(",", notWage),
                    ReuseName = string.Join(",", reuserWage),
                    PostWage = itemsGBPR.Sum(a => a.PostWage),
                    MonthlyPerformancePay = itemsGBPR.Sum(a => a.MonthlyPerformancePay),
                    SeniorityWage = itemsGBPR.Sum(a => a.SeniorityWage),
                    TechnicalAllowance = itemsGBPR.Sum(a => a.TechnicalAllowance),
                    PostAllowance = itemsGBPR.Sum(a => a.PostAllowance),
                    OvertimePay = itemsGBPR.Sum(a => a.OvertimePay),
                    DustCharge = itemsGBPR.Sum(a => a.DustCharge),
                    NightAllowance = itemsGBPR.Sum(a => a.NightAllowance),
                    HardshipAllowance = itemsGBPR.Sum(a => a.HardshipAllowance),
                    TollStationService = itemsGBPR.Sum(a => a.TollStationService),
                    ReplacementPay = itemsGBPR.Sum(a => a.ReplacementPay),
                    HighSubsidies = itemsGBPR.Sum(a => a.HighSubsidies),
                    CommunicationSubsidy = itemsGBPR.Sum(a => a.CommunicationSubsidy),
                    Reserve1 = itemsGBPR.Sum(a => a.Reserve1),
                    Reserve2 = itemsGBPR.Sum(a => a.Reserve2),
                    Other = itemsGBPR.Sum(a => a.Other),
                    NaturalYearEndPerformance = itemsGBPR.Sum(a => a.NaturalYearEndPerformance),
                    AnnualYearEndPerformance = itemsGBPR.Sum(a => a.AnnualYearEndPerformance)
                };

                result.Add(model);
            }

            //(3).自动归入工勤人员
            if (CommonStrInfo.DicAddToHandyMan.Keys.Contains(positionNameEn))
            {
                AddInfoByPostionList(itemsGBO, CommonStrInfo.DicAddToHandyMan[positionNameEn], result);
            }

            dicResult.Add(positionNameEn, result);
        }
    }
}

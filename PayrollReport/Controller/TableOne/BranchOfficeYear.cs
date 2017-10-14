﻿using Model;
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

        public void Run(string month = "")
        {
            if (m_Payroll == null || m_Payroll.Count == 0)
            {
                return;
            }

            Dictionary<string, Dictionary<string, List<ReportPost>>> dicCompanyResult = OutUsingBranch();

            //导出数据

            //导出报表三
            ReportExportByAspose export = new ReportExportByAspose();
            try
            {
                foreach (var key in dicCompanyResult.Keys)
                {
                    var path = Path.Combine(_savePath, key + month + ".xlsx");
                    if (!Directory.Exists(_savePath))
                    {
                        Directory.CreateDirectory(_savePath);
                    }
                    export.ExportReportDic(path, dicCompanyResult[key], key, month);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        /// <summary>
        /// 用于外部调用——分公司
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Dictionary<string, List<ReportPost>>> OutUsingBranch()
        {
            //key:公司名称,value:数据
            Dictionary<string, Dictionary<string, List<ReportPost>>> dicCompanyResult = new Dictionary<string, Dictionary<string, List<ReportPost>>>();

            //1.根据公司(下属单位)分组
            var itemsGroupByOffice = m_Payroll.GroupBy(a => a.SubordinateNnits);
            foreach (var itemsGBO in itemsGroupByOffice)
            {
                Dictionary<string, List<ReportPost>> dicResult = OutUsing(itemsGBO.ToList());

                dicCompanyResult.Add(itemsGBO.Key, dicResult);
            }

            return dicCompanyResult;
        }


        /// <summary>
        /// 外部调用——总公司
        /// </summary>
        /// <param name="itemsGBO"></param>
        /// <returns></returns>
        public Dictionary<string, List<ReportPost>> OutUsing(List<Payroll> itemsGBO)
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

            return dicResult;
        }

        private void AddInfoByChange(List<Payroll> itemsGBO, Dictionary<string, List<ReportPost>> dicResult, string key, bool isChange = false)
        {
            foreach (var positionList in CommonStrInfo.DicPositionChange.Where(a => a.Key.Equals(key)))
            {
                List<ReportPost> result = new List<ReportPost>();
                AddInfoByPostionList(itemsGBO, positionList.Value, result, isChange);
                dicResult.Add(positionList.Key, result);
            }
        }

        private void AddInfoByPostionList(List<Payroll> itemsGBO, List<string> positionList, List<ReportPost> result, bool isChange = false)
        {
            foreach (var pItem in positionList)
            {
                var values = itemsGBO.Where(a => a.PositionName.Equals(pItem));
                if (values.Count() == 0)
                {
                    continue;
                }
                var itemss = values.GroupBy(a => a.PostRankName);
                foreach (var items in itemss)
                {
                    var item = items.First();
                    var notWage = items.Where(a => a.WageAttribute.Equals("未发")).Select(a => a.Name);
                    var reuserWage = items.Where(a => a.WageAttribute.Equals("补发")).Select(a => a.Name);
                    ReportPost model = new ReportPost();
                    model.PositionName = isChange ? item.PostRankName : item.PositionName;
                    model.PostRankName = isChange ? item.PositionName : item.PostRankName;
                        //AlreadyCount = items.Count(a => string.IsNullOrEmpty(a.WageAttribute) || a.WageAttribute.Equals("正常")),
                    model.AlreadyCount = items.Count(a => a.WhetherOnDuty.Equals(1));
                    model.NotCount = notWage.Count();
                    model.ReuseCount = reuserWage.Count();
                    model.NotName = string.Join(",", notWage);
                    model.ReuseName = string.Join(",", reuserWage);
                    model.PostWage = items.Sum(a => a.PostWage);
                    model.MonthlyPerformancePay = items.Sum(a => a.MonthlyPerformancePay);
                    model.PerformancePay = items.Sum(a => a.PerformancePay);
                    model.SeniorityWage = items.Sum(a => a.SeniorityWage);
                    model.TechnicalAllowance = items.Sum(a => a.TechnicalAllowance);
                    model.ProfessionalAllowances = items.Sum(a => a.ProfessionalAllowances);
                    model.QuasiVehicleAllowances = items.Sum(a => a.QuasiVehicleAllowances);
                    model.PostAllowance = items.Sum(a => a.PostAllowance);
                    model.StaffServiceAllowance = items.Sum(a => a.StaffServiceAllowance);
                    model.OvertimePay = items.Sum(a => a.OvertimePay);
                    model.DustCharge = items.Sum(a => a.DustCharge);
                    model.NightAllowance = items.Sum(a => a.NightAllowance);
                    model.HardshipAllowance = items.Sum(a => a.HardshipAllowance);
                    model.TollStationService = items.Sum(a => a.TollStationService);
                    model.JobReplacement = items.Sum(a => a.JobReplacement);
                    model.ReplacementPay = items.Sum(a => a.ReplacementPay);
                    model.PluggingIncome = items.Sum(a => a.PluggingIncome);
                    model.Debit = items.Sum(a => a.Debit);
                    model.SmileStar = items.Sum(a => a.SmileStar);
                    model.HighSubsidies = items.Sum(a => a.HighSubsidies);
                    model.CommunicationSubsidy = items.Sum(a => a.CommunicationSubsidy);
                    model.Reserve1 = items.Sum(a => a.Reserve1);
                    model.Reserve2 = items.Sum(a => a.Reserve2);
                    model.Other = items.Sum(a => a.Other);
                    model.NaturalYearEndPerformance = items.Sum(a => a.NaturalYearEndPerformance);
                    model.AnnualYearEndPerformance = items.Sum(a => a.AnnualYearEndPerformance);
                    result.Add(model);
                }
            }
        }

        /// <summary>
        /// 正常情况
        /// </summary>
        /// <param name="itemsGBO"></param>
        /// <param name="dicResult"></param>
        /// <param name="position"></param>
        private void AddInfoByPosition(List<Payroll> itemsGBO, Dictionary<string, List<ReportPost>> dicResult, string positionName, string positionNameEn)
        {
            //根据岗位名称查数据库所有数据
            var itemsGBOByPN = itemsGBO.Where(a => a.PositionName.Equals(positionName));
            List<ReportPost> result = new List<ReportPost>();
            if (itemsGBOByPN.Count() != 0)
            {
                //4.根据岗位职级分组
                var itemsGroupByPostRank = itemsGBOByPN.GroupBy(a => a.PostRankName);

                foreach (var itemsGBPR in itemsGroupByPostRank)
                {
                    var item = itemsGBPR.First();

                    var notWage = itemsGBPR.Where(a => a.WageAttribute.Equals("未发")).Select(a => a.Name);
                    var reuserWage = itemsGBPR.Where(a => a.WageAttribute.Equals("补发")).Select(a => a.Name);
                    ReportPost model = new ReportPost
                    {
                        PositionName = item.PositionName,
                        PostRankName = item.PostRankName,
                        //AlreadyCount = itemsGBPR.Count(a => string.IsNullOrEmpty(a.WageAttribute) || a.WageAttribute.Equals("正常")),
                        AlreadyCount = itemsGBPR.Count(a => a.WhetherOnDuty.Equals(1)),
                        NotCount = notWage.Count(),
                        ReuseCount = reuserWage.Count(),
                        NotName = string.Join(",", notWage),
                        ReuseName = string.Join(",", reuserWage),
                        PostWage = itemsGBPR.Sum(a => a.PostWage),
                        MonthlyPerformancePay = itemsGBPR.Sum(a => a.MonthlyPerformancePay),
                        PerformancePay = itemsGBPR.Sum(a => a.PerformancePay),
                        SeniorityWage = itemsGBPR.Sum(a => a.SeniorityWage),
                        TechnicalAllowance = itemsGBPR.Sum(a => a.TechnicalAllowance),
                        ProfessionalAllowances = itemsGBPR.Sum(a => a.ProfessionalAllowances),
                        QuasiVehicleAllowances = itemsGBPR.Sum(a => a.QuasiVehicleAllowances),
                        PostAllowance = itemsGBPR.Sum(a => a.PostAllowance),
                        StaffServiceAllowance = itemsGBPR.Sum(a => a.StaffServiceAllowance),
                        OvertimePay = itemsGBPR.Sum(a => a.OvertimePay),
                        DustCharge = itemsGBPR.Sum(a => a.DustCharge),
                        NightAllowance = itemsGBPR.Sum(a => a.NightAllowance),
                        HardshipAllowance = itemsGBPR.Sum(a => a.HardshipAllowance),
                        TollStationService = itemsGBPR.Sum(a => a.TollStationService),
                        JobReplacement = itemsGBPR.Sum(a => a.JobReplacement),
                        ReplacementPay = itemsGBPR.Sum(a => a.ReplacementPay),
                        PluggingIncome = itemsGBPR.Sum(a => a.PluggingIncome),
                        Debit = itemsGBPR.Sum(a => a.Debit),
                        SmileStar = itemsGBPR.Sum(a => a.SmileStar),
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

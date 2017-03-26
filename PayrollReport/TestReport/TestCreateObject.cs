using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ReportExport;
using Model;

namespace TestReport
{
    [TestFixture]
    public class TestCreateObject
    {
        private ReportExportByAspose report = new ReportExportByAspose();
        [Test]
        public void Test1()
        {
            Dictionary<string, List<ReportPost>> dicReportLeader = new Dictionary<string, List<ReportPost>>();
            List<ReportPost> list1 = new List<ReportPost>();
            list1.Add(new ReportPost()
            {
                PositionName="管理人员",
                PostRankName = "主办一",
                AlreadyCount=1,
                NotCount=1,
                NotName="罗唐坤、蒋波",
                SmileStar=1,
                AnnualYearEndPerformance=10,
                CommunicationSubsidy=10,
                Debit=10,
                DustCharge=21,
                HardshipAllowance=31,
                HighSubsidies=11,
                JobReplacement=13,
                MonthlyPerformancePay=13,
                NaturalYearEndPerformance=100,
                NightAllowance=12,
                Other=12,
                OvertimePay=12,
                PerformancePay=12,
                PostAllowance=12,
                Reserve1=12,
                Reserve2=13,
                ReuseCount=1,
                ReuseName="蒋波"
            });
            list1.Add(new ReportPost()
            {
                PositionName = "管理人员",
                PostRankName = "主办一",
                AlreadyCount = 1,
                NotCount = 1,
                NotName = "罗唐坤1",
                SmileStar = 1,
                AnnualYearEndPerformance = 10,
                CommunicationSubsidy = 10,
                Debit = 10,
                DustCharge = 21,
                HardshipAllowance = 31,
                HighSubsidies = 11,
                JobReplacement = 13,
                MonthlyPerformancePay = 13,
                NaturalYearEndPerformance = 100,
                NightAllowance = 12,
                Other = 12,
                OvertimePay = 12,
                PerformancePay = 12,
                PostAllowance = 12,
                Reserve1 = 12,
                Reserve2 = 13,
                ReuseCount = 1,
                ReuseName = "蒋波1"
            });

            List<ReportPost> list2 = new List<ReportPost>();
            list2.Add(new ReportPost()
            {
                PositionName = "公司领导正职",
                AlreadyCount = 1,
                NotCount = 1,
                NotName = "王娇",
                SmileStar = 1,
                AnnualYearEndPerformance = 1,
                CommunicationSubsidy = 1,
                Debit = 1,
                DustCharge = 1,
                HardshipAllowance = 1,
                HighSubsidies = 1,
                JobReplacement = 1,
                MonthlyPerformancePay = 1,
                NaturalYearEndPerformance = 100,
                NightAllowance = 12,
                Other = 12,
                OvertimePay = 12,
                PerformancePay = 12,
                PostAllowance = 12,
                Reserve1 = 12,
                Reserve2 = 13,
                ReuseCount = 1,
                ReuseName = "余明其"
            });
            list2.Add(new ReportPost()
            {
                PositionName = "公司领导KK职",
                AlreadyCount = 1,
                NotCount = 1,
                NotName = "雪雪",
                SmileStar = 1,
                AnnualYearEndPerformance = 1,
                CommunicationSubsidy = 1,
                Debit = 1,
                DustCharge = 1,
                HardshipAllowance = 1,
                HighSubsidies = 1,
                JobReplacement = 1,
                MonthlyPerformancePay = 1,
                NaturalYearEndPerformance = 100,
                NightAllowance = 12,
                Other = 12,
                OvertimePay = 12,
                PerformancePay = 12,
                PostAllowance = 12,
                Reserve1 = 12,
                Reserve2 = 13,
                ReuseCount = 1,
                ReuseName = "小潘"
            });
            List<ReportPost> list3 = new List<ReportPost>();
            list3.Add(new ReportPost()
            {
                PositionName = "公司领导正职",
                AlreadyCount = 1,
                NotCount = 1,
                NotName = "王娇",
                SmileStar = 1,
                AnnualYearEndPerformance = 1,
                CommunicationSubsidy = 1,
                Debit = 1,
                DustCharge = 1,
                HardshipAllowance = 1,
                HighSubsidies = 1,
                JobReplacement = 1,
                MonthlyPerformancePay = 1,
                NaturalYearEndPerformance = 100,
                NightAllowance = 12,
                Other = 12,
                OvertimePay = 12,
                PerformancePay = 12,
                PostAllowance = 12,
                Reserve1 = 12,
                Reserve2 = 13,
                ReuseCount = 1,
                ReuseName = "余明其"
            });
            dicReportLeader["Artisan"] = list3;
            dicReportLeader["ReportLeader"] = list2;
            dicReportLeader["Manage"] = list1;
            report.ExportPostWage("公司:柳州分公司", "月份:12", dicReportLeader);
        }

        [Test]
        public void TestAnnualWage()
        {
            List<ReportAnnualWage> list = new List<ReportAnnualWage>();
            list.Add(new ReportAnnualWage()
            {
                CompanyName="柳州公司",
                January=10,
                February=20,
                March=30,
                April=10,
                May=22,
                June=11,
                July=32,
                August=32,
                September=30,
                October=10,
                November=20,
                December=30,
                NaturalYearEndPerformance=40,
                NaturalYearEndSum=32,
                AnnualYearEndPerformance=30,
                AnnualYearEndSum=20
            });
            list.Add(new ReportAnnualWage()
            {
                CompanyName = "桂林公司",
                January = 20,
                February = 320,
                March = 330,
                April = 130,
                May = 223,
                June = 131,
                July = 323,
                August = 332,
                September = 330,
                October = 310,
                November = 320,
                December = 330,
                NaturalYearEndPerformance = 430,
                NaturalYearEndSum = 323,
                AnnualYearEndPerformance = 330,
                AnnualYearEndSum = 230
            });
            report.ExportReportAnnualWage(list);
        }
    }
}

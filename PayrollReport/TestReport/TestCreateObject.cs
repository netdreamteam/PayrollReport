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
            List<ReportPost> list = new List<ReportPost>();
            list.Add(new ReportPost()
            {
                PositionName="公司正职领导",
                AlreadyCount=1,
                NotCount=1,
                NotName="罗唐坤",
                SmileStar=1,
                AnnualYearEndPerformance=1,
                CommunicationSubsidy=1,
                Debit=1,
                DustCharge=1,
                HardshipAllowance=1,
                HighSubsidies=1,
                JobReplacement=1,
                MonthlyPerformancePay=1,
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
            dicReportLeader["ReportLeader"] = list;
            report.ExportPostWage("公司:柳州分公司", "月份:12", dicReportLeader);
        }
    }
}

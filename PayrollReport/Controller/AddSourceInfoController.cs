using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Controller
{
    /// <summary>
    /// 添加从excel中获取的数据到数据库中
    /// </summary>
    public class AddSourceInfoController
    {
        /// <summary>
        /// 入口
        /// </summary>
        /// <param name="data">excel数据</param>
        /// <returns>是否保存成功</returns>
        public bool Run(DataSet data)
        {
            if (data == null || data.Tables.Count == 0)
            {
                return true;
            }

            DataTable dataDt = new DataTable();

            foreach (DataTable dt in data.Tables)
            {
                if (dt.TableName.Contains(CommonModel.DataSourceSheetName))
                {
                    dataDt = dt.Copy();
                }
            }

            if (dataDt == null || dataDt.Rows.Count == 0)
            {
                return true;
            }

            using (var scope = new TransactionScope())
            {
                if (AddPayroll(dataDt))
                {
                    scope.Complete();
                    scope.Dispose();

                    return true;
                }

                scope.Dispose();

                return false;
            }
        }

        /// <summary>
        /// 添加工资表
        /// </summary>
        /// <param name="dataDt"></param>
        /// <returns>是否添加成功</returns>
        public bool AddPayroll(DataTable dataDt)
        {
            BusinessContext dbContext = new BusinessContext();

            for (var i = 2; i < dataDt.Rows.Count; i++)
            {
                DataRow dr = dataDt.Rows[i];
                float coefficient = 0;
                float.TryParse(dr[6].ToString(), out coefficient);
                int whetherOnDuty = 0;
                int.TryParse(dr[7].ToString(), out whetherOnDuty);
                float postWage = 0;
                float.TryParse(dr[10].ToString(), out postWage);
                float monthlyPerformancePay = 0;
                float.TryParse(dr[11].ToString(), out monthlyPerformancePay);
                float performancePay = 0;
                float.TryParse(dr[12].ToString(), out performancePay);
                float seniorityWage = 0;
                float.TryParse(dr[13].ToString(), out seniorityWage);
                float technicalAllowance = 0;
                float.TryParse(dr[14].ToString(), out technicalAllowance);
                float professionalAllowances = 0;
                float.TryParse(dr[15].ToString(), out professionalAllowances);
                float quasiVehicleAllowances = 0;
                float.TryParse(dr[16].ToString(), out quasiVehicleAllowances);
                float postAllowance = 0;
                float.TryParse(dr[17].ToString(), out postAllowance);
                float staffServiceAllowance = 0;
                float.TryParse(dr[18].ToString(), out staffServiceAllowance);
                float dustCharge = 0;
                float.TryParse(dr[19].ToString(), out dustCharge);
                float nightAllowance = 0;
                float.TryParse(dr[20].ToString(), out nightAllowance);
                float hardshipAllowance = 0;
                float.TryParse(dr[21].ToString(), out hardshipAllowance);
                float tollStationService = 0;
                float.TryParse(dr[22].ToString(), out tollStationService);
                float smileStar = 0;
                float.TryParse(dr[23].ToString(), out smileStar);
                float jobReplacement = 0;
                float.TryParse(dr[24].ToString(), out jobReplacement);
                float replacementPay = 0;
                float.TryParse(dr[25].ToString(), out replacementPay);
                float pluggingIncome = 0;
                float.TryParse(dr[26].ToString(), out pluggingIncome);
                float other = 0;
                float.TryParse(dr[27].ToString(), out other);
                float reserve1 = 0;
                float.TryParse(dr[28].ToString(), out reserve1);
                float reserve2 = 0;
                float.TryParse(dr[29].ToString(), out reserve2);
                float subtotal = 0;
                float.TryParse(dr[30].ToString(), out subtotal);
                float highSubsidies = 0;
                float.TryParse(dr[31].ToString(), out highSubsidies);
                float communicationSubsidy = 0;
                float.TryParse(dr[32].ToString(), out communicationSubsidy);
                float overtimePay = 0;
                float.TryParse(dr[33].ToString(), out overtimePay);
                float debit = 0;
                float.TryParse(dr[34].ToString(), out debit);
                float totalShouldBeIssued = 0;
                float.TryParse(dr[35].ToString(), out totalShouldBeIssued);
                float naturalYearEndPerformance = 0;
                float.TryParse(dr[36].ToString(), out naturalYearEndPerformance);
                float annualYearEndPerformance = 0;
                float.TryParse(dr[37].ToString(), out annualYearEndPerformance);

                try
                {
                    dbContext.Payroll.Add(new Payroll
                    {
                        SubordinateNnits = dr[0].ToString(),
                        Years = dr[1].ToString(),
                        Name = dr[2].ToString(),
                        SocialSecurityNumber = dr[3].ToString(),
                        PositionID = AddPosition(dbContext, dr),
                        PostRankID = AddPostRank(dbContext, dr),
                        Coefficient = coefficient,
                        WhetherOnDuty = whetherOnDuty,
                        ProbationPeriod = dr[8].ToString(),
                        WageAttribute = string.IsNullOrEmpty(dr[9].ToString()) ? "正常" : dr[9].ToString(),
                        PostWage = postWage,
                        MonthlyPerformancePay = monthlyPerformancePay,
                        PerformancePay = performancePay,
                        SeniorityWage = seniorityWage,
                        TechnicalAllowance = technicalAllowance,
                        ProfessionalAllowances = professionalAllowances,
                        QuasiVehicleAllowances = quasiVehicleAllowances,
                        PostAllowance = postAllowance,
                        StaffServiceAllowance = staffServiceAllowance,
                        DustCharge = dustCharge,
                        NightAllowance = nightAllowance,
                        HardshipAllowance = hardshipAllowance,
                        TollStationService = tollStationService,
                        SmileStar = smileStar,
                        JobReplacement = jobReplacement,
                        ReplacementPay = replacementPay,
                        PluggingIncome = pluggingIncome,
                        Other = other,
                        Reserve1 = reserve1,
                        Reserve2 = reserve2,
                        Subtotal = subtotal,
                        HighSubsidies = highSubsidies,
                        CommunicationSubsidy = communicationSubsidy,
                        OvertimePay = overtimePay,
                        Debit = debit,
                        TotalShouldBeIssued = totalShouldBeIssued,
                        NaturalYearEndPerformance = naturalYearEndPerformance,
                        AnnualYearEndPerformance = annualYearEndPerformance
                    });

                    dbContext.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 添加所在岗位表
        /// </summary>
        /// <param name="dbContext">数据实体</param>
        /// <param name="dr">一行数据</param>
        /// <returns>编号</returns>
        public string AddPosition(BusinessContext dbContext, DataRow dr)
        {
            var item = dbContext.Position.FirstOrDefault(a => a.PositionName.Equals(dr[4].ToString()));
            if (item != null)
            {
                return item.PositionID;
            }

            string id = Guid.NewGuid().ToString();
            dbContext.Position.Add(new Position
            {
                PositionID = id,
                PositionName = dr[4].ToString()
            });

            dbContext.SaveChanges();

            return id;
        }

        /// <summary>
        /// 添加岗位职级表
        /// </summary>
        /// <param name="dbContext">数据实体</param>
        /// <param name="dr">一行数据</param>
        /// <returns>编号</returns>
        public string AddPostRank(BusinessContext dbContext, DataRow dr)
        {
            var item = dbContext.PostRank.FirstOrDefault(a => a.PostRankName.Equals(dr[5].ToString()));
            if (item != null)
            {
                return item.PostRankID;
            }

            string id = Guid.NewGuid().ToString();
            dbContext.PostRank.Add(new PostRank
            {
                PostRankID = id,
                PostRankName = dr[5].ToString()
            });
            dbContext.SaveChanges();

            return id;
        }
    }
}

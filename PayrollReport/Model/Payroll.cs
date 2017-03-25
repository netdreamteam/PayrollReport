using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class PayCost
    {
        /// <summary>
        /// 岗位工资
        /// </summary>
        public float PostWage { get; set; }
        /// <summary>
        /// 月绩效工资
        /// </summary>
        public float MonthlyPerformancePay { get; set; }
        /// <summary>
        /// 考核绩效工资
        /// </summary>
        public float PerformancePay { get; set; }
        /// <summary>
        /// 工龄工资
        /// </summary>
        public float SeniorityWage { get; set; }
        /// <summary>
        /// 技术津贴
        /// </summary>
        public float TechnicalAllowance { get; set; }
        /// <summary>
        /// 专业津贴
        /// </summary>
        public float ProfessionalAllowances { get; set; }
        /// <summary>
        /// 准驾车型补贴
        /// </summary>
        public float QuasiVehicleAllowances { get; set; }
        /// <summary>
        /// 岗位津贴
        /// </summary>
        public float PostAllowance { get; set; }
        /// <summary>
        /// 排障员业务补贴
        /// </summary>
        public float StaffServiceAllowance { get; set; }
        /// <summary>
        /// 防尘费
        /// </summary>
        public float DustCharge { get; set; }
        /// <summary>
        /// 夜班补贴
        /// </summary>
        public float NightAllowance { get; set; }
        /// <summary>
        /// 艰苦边远补贴
        /// </summary>
        public float HardshipAllowance { get; set; }
        /// <summary>
        /// 收费站业务补贴
        /// </summary>
        public float TollStationService { get; set; }
        /// <summary>
        /// 微笑之星
        /// </summary>
        public float SmileStar { get; set; }
        /// <summary>
        /// 补发岗位工资
        /// </summary>
        public float JobReplacement { get; set; }
        /// <summary>
        /// 补发工资
        /// </summary>
        public float ReplacementPay { get; set; }
        /// <summary>
        /// 堵漏增收
        /// </summary>
        public float PluggingIncome { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public float Other { get; set; }
        /// <summary>
        /// 预留1
        /// </summary>
        public float Reserve1 { get; set; }
        /// <summary>
        /// 预留2
        /// </summary>
        public float Reserve2 { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public float Subtotal { get; set; }
        /// <summary>
        /// 高温补贴
        /// </summary>
        public float HighSubsidies { get; set; }
        /// <summary>
        /// 通讯补贴
        /// </summary>
        public float CommunicationSubsidy { get; set; }
        /// <summary>
        /// 加班费
        /// </summary>
        public float OvertimePay { get; set; }
        /// <summary>
        /// 扣款
        /// </summary>
        public float Debit { get; set; }
        /// <summary>
        /// 应发合计
        /// </summary>
        public float TotalShouldBeIssued { get; set; }
        /// <summary>
        /// 自然年度年终绩效
        /// </summary>
        public float NaturalYearEndPerformance { get; set; }
        /// <summary>
        /// 所属年度年终绩效
        /// </summary>
        public float AnnualYearEndPerformance { get; set; }
    }

    /// <summary>
    /// 源数据(工资表)
    /// </summary>
    public class Payroll:PayCost
    {
        public Payroll()
        { }
        #region Model

        /// <summary>
        /// 社保编号
        /// </summary>
        public string SocialSecurityNumber { get; set; }
        /// <summary>
        /// 下属单位
        /// </summary>
        public string SubordinateNnits { get; set; }
        /// <summary>
        /// 年月
        /// </summary>
        public string Years { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所在岗位ID
        /// </summary>
        [ForeignKey("PositionLink")]
        public string PositionID { get; set; }
        /// <summary>
        /// 岗位职级ID
        /// </summary>
        [ForeignKey("PostRankLink")]
        public string PostRankID { get; set; }
        /// <summary>
        /// 系数
        /// </summary>
        public float Coefficient { get; set; }
        /// <summary>
        /// 是否在岗
        /// </summary>
        public int WhetherOnDuty { get; set; }
        /// <summary>
        /// 试用期
        /// </summary>
        public string ProbationPeriod { get; set; }
        /// <summary>
        /// 工资属性
        /// </summary>
        public string WageAttribute { get; set; }
       
        #endregion Model

        #region 外键
        public virtual Position PositionLink { get; set; }
        public virtual PostRank PostRankLink { get; set; }

        #endregion
    }
}

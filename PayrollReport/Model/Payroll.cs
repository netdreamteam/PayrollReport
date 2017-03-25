using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 源数据
    /// </summary>
    class Payroll
    {
        public Payroll()
        { }
        #region Model
        
        /// <summary>
        /// 
        /// </summary>
        public string SocialSecurityNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SubordinateNnits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Years { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("Position")]
        public string PositionID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("PostRank")]
        public string PostRankID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Coefficient { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WhetherOnDuty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProbationPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WageAttribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal PostWage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal MonthlyPerformancePay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal PerformancePay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal SeniorityWage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal TechnicalAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal professionalAllowances { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal QuasiVehicleAllowances { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal PostAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal StaffServiceAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal DustCharge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal NightAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal HardshipAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal TollStationService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal SmileStar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal JobReplacement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ReplacementPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal PluggingIncome { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Other { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Reserve1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Reserve2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Subtotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal HighSubsidies { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CommunicationSubsidy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal OvertimePay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Debit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalShouldBeIssued { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal NaturalYearEndPerformance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal AnnualYearEndPerformance { get; set; }
        #endregion Model
    }
}

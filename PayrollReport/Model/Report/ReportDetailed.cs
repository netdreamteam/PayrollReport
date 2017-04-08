using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 年收入明细
    /// </summary>
    public class ReportDetailed : MonthPay
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 岗位职级
        /// </summary>
        public string PostRankName { get; set; }

        /// <summary>
        /// 工作月数量
        /// </summary>
        public int WorkTime { get; set; }
        /// <summary>
        /// 社保编号
        /// </summary>
        public string SocialSecurityNumber { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 高温补贴
        /// </summary>
        public float HighSubsidies { get; set; }
        /// <summary>
        /// 通讯补贴
        /// </summary>
        public float CommunicationSubsidy { get; set; }

        /// <summary>
        /// 自然年度绩效
        /// </summary>
        public float NaturalYearEndPerformance { get; set; }
        /// <summary>
        /// 所属年度绩效
        /// </summary>
        public float AnnualYearEndPerformance { get; set; }

        /// <summary>
        /// 预留1
        /// </summary>
        public float Reserve1 { get; set; }
        /// <summary>
        /// 预留2
        /// </summary>
        public float Reserve2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 职工工资年报
    /// </summary>
    public class ReportAnnualWage
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 1月
        /// </summary>
        public float January { get; set; }
        /// <summary>
        /// 2月
        /// </summary>
        public float February { get; set; }
        /// <summary>
        /// 3月
        /// </summary>
        public float March { get; set; }
        /// <summary>
        /// 4月
        /// </summary>
        public float April { get; set; }
        /// <summary>
        /// 5月
        /// </summary>
        public float May { get; set; }
        /// <summary>
        /// 6月
        /// </summary>
        public float June { get; set; }
        /// <summary>
        /// 7月
        /// </summary>
        public float July { get; set; }
        /// <summary>
        /// 8月
        /// </summary>
        public float August { get; set; }
        /// <summary>
        /// 9月
        /// </summary>
        public float September { get; set; }
        /// <summary>
        /// 10月
        /// </summary>
        public float October { get; set; }
        /// <summary>
        /// 11月
        /// </summary>
        public float November { get; set; }
        /// <summary>
        /// 12月
        /// </summary>
        public float December { get; set; }
        /// <summary>
        /// 自然年度绩效
        /// </summary>
        public float NaturalYearEndPerformance { get; set; }

        /// <summary>
        /// 自然年度合计
        /// </summary>
        public float NaturalYearEndSum { get; set; }

        /// <summary>
        /// 所属年度绩效
        /// </summary>
        public float AnnualYearEndPerformance { get; set; }
        /// <summary>
        /// 所属年度合计
        /// </summary>
        public float AnnualYearEndSum { get; set; }
    }
}

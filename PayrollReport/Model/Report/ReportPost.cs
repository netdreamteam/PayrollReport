using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 岗位工资报表
    /// </summary>
    public class ReportPost:PayCost
    {

        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 职级名称
        /// </summary>
        public string PostRankName { get; set; }
        /// <summary>
        /// 实际发放工资人数
        /// </summary>
        public int AlreadyCount { get; set; }
        /// <summary>
        /// 未发工资人数
        /// </summary>
        public int NotCount { get; set; }
        /// <summary>
        /// 补发工资人数
        /// </summary>
        public int ReuseCount { get; set; }
        /// <summary>
        /// 未发工资名单
        /// </summary>
        public string NotName { get; set; }

        /// <summary>
        /// 补发工资名单
        /// </summary>
        public string ReuseName { get; set; }
    }
}

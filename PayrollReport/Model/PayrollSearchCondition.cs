using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class PayrollSearchCondition
    {
        #region 查询model

        /// <summary>
        /// 主键
        /// </summary>
        public List<string> ID { get; set; }

        /// <summary>
        /// 社保编号
        /// </summary>
        public List<string> SocialSecurityNumber { get; set; }
        /// <summary>
        /// 下属单位
        /// </summary>
        public List<string> SubordinateNnits { get; set; }
        /// <summary>
        /// 年月
        /// </summary>
        public DateTime StartYears { get; set; }
        /// <summary>
        /// 年月
        /// </summary>
        public DateTime EndYears { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public List<string> Name { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public List<string> PositionName { get; set; }
        /// <summary>
        /// 岗位职级名称
        /// </summary>
        public List<string> PostRankName { get; set; }
        /// <summary>
        /// 系数
        /// </summary>
        public float? Coefficient { get; set; }
        /// <summary>
        /// 是否在岗
        /// </summary>
        public int? WhetherOnDuty { get; set; }
        /// <summary>
        /// 试用期
        /// </summary>
        public List<string> ProbationPeriod { get; set; }
        /// <summary>
        /// 工资属性
        /// </summary>
        public List<string> WageAttribute { get; set; }
        #endregion
    }
}

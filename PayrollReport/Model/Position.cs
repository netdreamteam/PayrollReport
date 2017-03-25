using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class Position
    {
        public Position()
        { }
        #region Model
        /// <summary>
        /// 岗位id
        /// </summary>
        [Key]
        public string PositionID { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PositionName { get; set; }
        #endregion Model
    }
}

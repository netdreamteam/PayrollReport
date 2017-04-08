using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 岗位(所在岗位表)
    /// </summary>
    [Table("Position")]
    public class Position
    {
        public Position()
        { }
        #region Model
        /// <summary>
        /// 岗位id
        /// </summary>
        [Key]
        [Column("Position_ID")]
        public string PositionID { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        [Column("Position_Name")]
        public string PositionName { get; set; }
        #endregion Model
    }
}

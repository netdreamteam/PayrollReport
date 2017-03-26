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
    /// 岗位职级(岗位职级表)
    /// </summary>
    [Table("PostRank")]
    public class PostRank
    {
        public PostRank()
        { }
        #region Model
        /// <summary>
        /// 岗位职级ID
        /// </summary>
        [Key]
        [Column("PostRank_ID")]
        public string PostRankID { get; set; }
        /// <summary>
        /// 岗位职级名称
        /// </summary>
        [Column("PostRank_Name")]
        public string PostRankName { get; set; }
        #endregion Model
    }
}

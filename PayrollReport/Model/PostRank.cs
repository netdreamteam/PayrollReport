using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 岗位职级
    /// </summary>
    public class PostRank
    {
        public PostRank()
        { }
        #region Model
        /// <summary>
        /// 职级id
        /// </summary>
        [Key]
        public string PostRankID { get; set; }
        /// <summary>
        /// 职级名称
        /// </summary>
        public string PostRankName { get; set; }
        #endregion Model
    }
}

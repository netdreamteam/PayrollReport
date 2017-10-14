using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 公共数据信息
    /// </summary>
    public class CommonStrInfo
    {
        #region 表1数据

        /// <summary>
        /// 存储所在岗位信息——“所在岗位与导出数据保持一致”
        /// </summary>
        public static Dictionary<string, string> DicPosition { get; set; }

        /// <summary>
        /// 存储所在岗位信息——"所在岗位”和“岗位职级"交换的
        /// </summary>
        public static Dictionary<string, List<string>> DicPositionChange { get; set; }

        /// <summary>
        /// 存储所在岗位信息——自动归入工勤人员
        /// </summary>
        public static Dictionary<string, List<string>> DicAddToHandyMan { get; set; }

        public CommonStrInfo()
        {
            /*岗位信息*/
            DicPosition = new Dictionary<string, string>();
            DicPosition.Add("公司领导正职", "ReportLeader");
            DicPosition.Add("公司领导副职", "ReportDeputyLeader");
            DicPosition.Add("部门正职", "DepartmentChief");
            DicPosition.Add("部门副职", "DeputyDepartment");
            DicPosition.Add("管理人员", "Manage");
            DicPosition.Add("养护技术员", "MaintenanceTechnician");
            DicPosition.Add("机电技术员", "MechanicalTechnician");
            DicPosition.Add("服务区管理人员", "ServiceAreaManager");
            DicPosition.Add("服务区水电工", "ServiceAreaElectrician");

            DicPosition.Add("收费站站长", "TollStationMaster");
            DicPosition.Add("收费站副站长", "TollStationDeputyMaster");
            DicPosition.Add("站务员", "TicketClerk");
            DicPosition.Add("稽查员", "Inspector");
            DicPosition.Add("收费员", "TollCollector");

            DicPosition.Add("隧道站技术员", "TunnelStationTechnician");
            DicPosition.Add("隧道站人员", "TunnelStationPersonnel");
            DicPosition.Add("工勤人员", "HandyMan");
            DicPosition.Add("分流人员", "TriagePersonnel");
            DicPosition.Add("收费站水电工", "TollStationElectrician");
            DicPosition.Add("隧道监控员", "TunnelMonitor");
            DicPosition.Add("收费站管理", "TollStationManagement");
            DicPosition.Add("生产一线", "ProductionLine");
            DicPosition.Add("劳务派遣人员", "LaborDispatchPersonnel");

            /* 存储所在岗位信息——"所在岗位”和“岗位职级"交换的*/
            DicPositionChange = new Dictionary<string, List<string>>();
            List<string> tollList = new List<string>();
            //tollList.Add("收费站站长");
            //tollList.Add("收费站副站长");
            //tollList.Add("票证员");
            //tollList.Add("稽查员");
            tollList.Add("监控员");
            DicPositionChange.Add("TollStationManagement", tollList);
            List<string> productList = new List<string>();
            productList.Add("收费班长");
            productList.Add("收费副班长");
            productList.Add("金牌+收费员");
            productList.Add("金牌收费员");
            //productList.Add("收费员");
            DicPositionChange.Add("ProductionLine", productList);

            /*存储所在岗位信息——自动归入工勤人员*/
            DicAddToHandyMan = new Dictionary<string, List<string>>();
            List<string> handyList = new List<string>();
            handyList.Add("排障员");
            handyList.Add("司机");
            handyList.Add("水电工");
            DicAddToHandyMan.Add("HandyMan", handyList);

            /*劳务派遣人员信息*/
            List<string> lList = new List<string> { "服务区保安", "服务区保洁", "厨师", "门卫", "其他勤杂人员" };
            DicPositionChange.Add("LaborDispatchPersonnel", lList);
        }

        #endregion
    }
}

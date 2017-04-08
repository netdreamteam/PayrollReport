using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// 按条件查询数据库
    /// </summary>
    public class SearchConditionController
    {
        public List<Payroll> SearchByCondition(PayrollSearchCondition model)
        {
            BusinessContext dbContext = new BusinessContext();
            var result = dbContext.Payroll.ToList();

            if (model == null)
            {
                return result;
            }

            if (!string.IsNullOrEmpty(model.ID))
            {
                result = result.Where(a => a.ID.Equals(model.ID)).ToList();
            }
            if (!string.IsNullOrEmpty(model.SocialSecurityNumber))
            {
                result = result.Where(a => a.SocialSecurityNumber.Equals(model.SocialSecurityNumber)).ToList();
            }
            if (model.SubordinateNnits != null && model.SubordinateNnits.Count() > 0)
            {
                result = result.Where(a => model.SubordinateNnits.Contains(a.SubordinateNnits)).ToList();
            }

            List<string> timeStr = new List<string>();

            DateTime s = model.StartYears;
            while ((s.Year < model.EndYears.Year) || (s.Year == model.EndYears.Year && s.Month <= model.EndYears.Month))
            {
                timeStr.Add(s.ToString("yyyyMM"));
                s = s.AddMonths(1);
            }

            if (model.StartYears != new DateTime() && model.EndYears != new DateTime())
            {
                result = result.Where(a => timeStr.Contains(a.Years)).ToList();
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                result = result.Where(a => a.Name.Equals(model.Name)).ToList();
            }
            if (!string.IsNullOrEmpty(model.PositionName))
            {
                result = result.Where(a => a.PositionLink.PositionName.Equals(model.PositionName)).ToList();
            }
            if (!string.IsNullOrEmpty(model.PostRankName))
            {
                result = result.Where(a => a.PostRankLink.PostRankName.Equals(model.PostRankName)).ToList();
            }
            if (model.Coefficient != null)
            {
                result = result.Where(a => a.Coefficient.Equals(model.Coefficient)).ToList();
            }
            if (model.WhetherOnDuty != null)
            {
                result = result.Where(a => a.WhetherOnDuty.Equals(model.WhetherOnDuty)).ToList();
            }
            if (!string.IsNullOrEmpty(model.ProbationPeriod))
            {
                result = result.Where(a => a.ProbationPeriod.Equals(model.ProbationPeriod)).ToList();
            }
            if (!string.IsNullOrEmpty(model.WageAttribute))
            {
                result = result.Where(a => a.WageAttribute.Equals(model.WageAttribute)).ToList();
            }

            return result;
        }
    }
}

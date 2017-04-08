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

            if (model.ID != null && model.ID.Count() != 0)
            {
                result = result.Where(a => a.ID.Equals(model.ID)).ToList();
            }
            if (model.SocialSecurityNumber != null && model.SocialSecurityNumber.Count() != 0)
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

            if (model.Name != null && model.Name.Count() > 0)
            {
                result = result.Where(a => model.Name.Contains(a.Name)).ToList();
            }
            if (model.PositionName != null && model.PositionName.Count() > 0)
            {
                result = result.Where(a => model.PositionName.Contains(a.PositionLink.PositionName)).ToList();
            }
            if (model.PostRankName != null && model.PostRankName.Count() > 0)
            {
                result = result.Where(a => model.PostRankName.Contains(a.PostRankLink.PostRankName)).ToList();
            }
            if (model.Coefficient != null)
            {
                result = result.Where(a => a.Coefficient.Equals(model.Coefficient)).ToList();
            }
            if (model.WhetherOnDuty != null)
            {
                result = result.Where(a => a.WhetherOnDuty.Equals(model.WhetherOnDuty)).ToList();
            }
            if (model.ProbationPeriod != null && model.ProbationPeriod.Count() > 0)
            {
                result = result.Where(a => model.ProbationPeriod.Contains(a.ProbationPeriod)).ToList();
            }
            if (model.WageAttribute != null && model.WageAttribute.Count() > 0)
            {
                result = result.Where(a => model.WageAttribute.Contains(a.WageAttribute)).ToList();
            }

            return result;
        }
    }
}

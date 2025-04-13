using HRManagementMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementMVC.Controller
{
    public class RankController
    {
        public tbl_rank InsertRank(tbl_rank rank)
        {
            try
            {
                using (HrDBDataContext db = new HrDBDataContext())
                {
                    db.tbl_ranks.InsertOnSubmit(rank);
                    db.SubmitChanges();
                    return rank;
                }
            }catch (Exception ex)
            {
                return null;
            }
         
        }
        public bool UpdateRank(Guid id, tbl_rank rank)
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    var existingRankID = db.tbl_ranks.FirstOrDefault(x => x.RankID == id);
                    if (existingRankID != null)
                    {
                        existingRankID.Rank = rank.Rank;
                        existingRankID.RankName = rank.RankName;
                        existingRankID.Salary = rank.Salary;
                        existingRankID.UpdatedDate = rank.UpdatedDate;
                        existingRankID.ActiveFlag = true;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                  

                }
            }catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<tbl_rank> GetAllRank()
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    return db.tbl_ranks.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public tbl_rank SearchRankByID(Guid id)
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    var existingRabkID = db.tbl_ranks.FirstOrDefault(x =>x.RankID == id);
                    if(existingRabkID != null)
                    {
                        return existingRabkID;
                    }else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteRank(Guid id)
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    var existingRankID = db.tbl_ranks.FirstOrDefault(y =>y.RankID == id);
                    if(existingRankID != null)
                    {
                        existingRankID.ActiveFlag = false;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}

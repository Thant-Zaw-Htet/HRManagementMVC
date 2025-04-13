using HRManagementMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementMVC.Controller
{
    public class EmployeeManagementController
    {
        public tbl_employee InsertEmployee(tbl_employee employee)
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    var rankData = db.tbl_ranks.FirstOrDefault(x => x.Rank ==  employee.Rank);
                    if (rankData != null)
                    {
                        employee.RankID = rankData.RankID;
                        db.tbl_employees.InsertOnSubmit(employee);
                        db.SubmitChanges();
                    }
                    else
                    {
                      return null;
                      
                    }
                    return employee;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UpdateEmployee(Guid id, tbl_employee employee)
        {
            try
            {
                using (HrDBDataContext db = new HrDBDataContext())
                {
                    var exisitingEmployeeID = db.tbl_employees.FirstOrDefault(x => x.EmployeeID == id);         
                    var rankData = db.tbl_ranks.FirstOrDefault(x => x.Rank == employee.Rank);
              
                    if (exisitingEmployeeID != null && rankData != null)
                    {
                        exisitingEmployeeID.EmployeeName = employee.EmployeeName;
                        exisitingEmployeeID.Gender = employee.Gender;
                        exisitingEmployeeID.Age = employee.Age;
                        exisitingEmployeeID.Address = employee.Address;
                        exisitingEmployeeID.Position = employee.Position;
                        exisitingEmployeeID.Rank = employee.Rank;
                        exisitingEmployeeID.Salary = employee.Salary;
                        exisitingEmployeeID.UpdatedDate = DateTime.Now;
                        exisitingEmployeeID.ActiveFlag = true;

                        exisitingEmployeeID.RankID = rankData.RankID;
                        db.SubmitChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteEmployee(Guid employeeID)
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    var existingEmployeeId = db.tbl_employees.FirstOrDefault(x => x.EmployeeID == employeeID);
                    if (existingEmployeeId != null)
                    {
                        existingEmployeeId.ActiveFlag = false;
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
        public tbl_employee SearchEmployeeByID(Guid employeeID)
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    var existingEmployeeID = db.tbl_employees.FirstOrDefault(x => x.EmployeeID == employeeID);
                    if (existingEmployeeID != null && existingEmployeeID.ActiveFlag == true)
                    {
                        return existingEmployeeID;
                    }
                    else
                    {
                        return null;
                    }
                }
            }catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<tbl_employee> GetAllEmployee()
        {
            try
            {
                using(HrDBDataContext db = new HrDBDataContext())
                {
                    if (db.tbl_employees == null)
                    {
                        return null ;
                    }
                    else
                    {
                        return db.tbl_employees.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}

using HRManagementMVC.Controller;
using HRManagementMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementMVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome HR Management Software: ");
            Console.WriteLine("(1) Add New Employee \n(2) Add Rank");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Welcome from Marvo \n1. Add New Employee \n2. Check All Employee Data \n3. Update Current Employee \n4. Search Employee \n5. Delete Employee");
                    int choiceEmployeeMenu = int.Parse(Console.ReadLine());
                    switch (choiceEmployeeMenu)
                    {
                        case 1:
                            tbl_employee employee = new tbl_employee();
                            tbl_rank employeeRank = new tbl_rank();
                            Console.Write("Enter Employee Name: ");
                            employee.EmployeeName = Console.ReadLine();
                            Console.Write("Enter Employee Gender: ");
                            employee.Gender = Console.ReadLine();
                            Console.Write("Enter Employee Age: ");
                            employee.Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Employee Address: ");
                            employee.Address = Console.ReadLine();
                            Console.Write("Enter Employee Position: ");
                            employee.Position = Console.ReadLine();
                            Console.Write("Enter Employee Rank: ");
                            employee.Rank = int.Parse(Console.ReadLine());
                            Console.Write("Enter Employee Salary: ");
                            employee.Salary = decimal.Parse(Console.ReadLine());

                            employee.EmployeeID = Guid.NewGuid();
                            employee.CreatedDate = DateTime.Now;
                            employee.ActiveFlag = true;
                            employee.RankID = employeeRank.RankID;

                            EmployeeManagementController employeeManagementController = new EmployeeManagementController();
                            var objEmployee = employeeManagementController.InsertEmployee(employee);
                            if (objEmployee == null)
                            {
                                Console.WriteLine("Add Emplyee Failed!");
                            }
                            else
                            {
                                Console.WriteLine("Add Employee Successfully");
                            }                           
                            break;
                        case 2:
                            tbl_employee employeeGetALl = new tbl_employee();
                            EmployeeManagementController emp = new EmployeeManagementController();
                            var getAllEmployeeResult = emp.GetAllEmployee();
                            if (getAllEmployeeResult == null)
                            {
                                Console.WriteLine("No Customer!");
                            }
                            else
                            {
                                foreach (var employeeList in getAllEmployeeResult)
                                {
                                    Console.WriteLine($"EmployeeID: {employeeList.EmployeeID} \nEmployee name: {employeeList.EmployeeName} \nEmployee gender: {employeeList.Gender} \nEmployee age: " +
                                     $"{employeeList.Age} \nEmployee address: {employeeList.Address} \nEmployee position: {employeeList.Position}\n" +
                                     $"Employee rank: {employeeList.Rank} \nEmployee salary: {employeeList.Salary}");
                                }
                            }
                            break;
                        case 3:
                            Console.Write("Enter Employee ID: ");
                            Guid updateId = Guid.Parse(Console.ReadLine());

                            tbl_employee employeUpdate = new tbl_employee();
                            Console.Write("Enter Employee Name: ");
                            employeUpdate.EmployeeName = Console.ReadLine();
                            Console.Write("Enter Employee Gender: ");
                            employeUpdate.Gender = Console.ReadLine();
                            Console.Write("Enter Employee Age: ");
                            employeUpdate.Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Employee Address: ");
                            employeUpdate.Address = Console.ReadLine();
                            Console.Write("Enter Employee Position: ");
                            employeUpdate.Position = Console.ReadLine();
                            Console.Write("Enter Employee Rank: ");
                            employeUpdate.Rank = int.Parse(Console.ReadLine());
                            Console.Write("Enter Employee Salary: ");
                            employeUpdate.Salary = decimal.Parse(Console.ReadLine());

                            employeUpdate.UpdatedDate = DateTime.Now;
                            employeUpdate.ActiveFlag = true;

                            EmployeeManagementController updateEmployeeManagementController = new EmployeeManagementController();
                            bool result = updateEmployeeManagementController.UpdateEmployee(updateId, employeUpdate);

                            if (result)
                            {
                                Console.WriteLine("Updated Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Update Failed");
                            }                              
                            break;
                        case 4:
                            tbl_employee employeeSearchByID = new tbl_employee();
                            Console.WriteLine("Enter Employee ID to search: ");
                            employeeSearchByID.EmployeeID = Guid.Parse(Console.ReadLine());
                            EmployeeManagementController searchEmployeeManagementController = new EmployeeManagementController();
                            var searchResult = searchEmployeeManagementController.SearchEmployeeByID(employeeSearchByID.EmployeeID);
                            if (searchResult == null)
                            {
                                Console.WriteLine("Customer not found");
                            }
                            else
                            {
                                Console.WriteLine($"EmployeeID: {searchResult.EmployeeID} \nEmployee name: {searchResult.EmployeeName} \nEmployee gender: {searchResult.Gender} \nEmployee age: " +
                                     $"{searchResult.Age} \nEmployee address: {searchResult.Address} \nEmployee position: {searchResult.Position}\n" +
                                     $"Employee rank: {searchResult.Rank} \nEmployee salary: {searchResult.Salary}");

                            }
                            break;
                        case 5:
                            tbl_employee employeeDelete = new tbl_employee();
                            Console.WriteLine("Enter Employee ID to delete: ");
                            employeeDelete.EmployeeID = Guid.Parse(Console.ReadLine());
                            EmployeeManagementController deleteEmployeeManagementController = new EmployeeManagementController();
                            bool deleteResult = deleteEmployeeManagementController.DeleteEmployee(employeeDelete.EmployeeID);
                            if (deleteResult)
                                Console.WriteLine("Deleted Successfully");
                            else
                                Console.WriteLine("Deleted Failed");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice...");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Welcome from Marvo  \n1. Add New Rank \n2. Check All Rank \n3. Update Current Rank \n4. Search Rank \n5. Delete Rank");
                    int choiceRankMenu = int.Parse(Console.ReadLine());
                    switch (choiceRankMenu)
                    {
                        case 1:
                            tbl_rank rank = new tbl_rank();
                            Console.Write("Enter Rank: ");
                            rank.Rank = int.Parse(Console.ReadLine());
                            Console.Write("Enter RankName: ");
                            rank.RankName = Console.ReadLine();
                            Console.Write("Enter Salary: ");
                            rank.Salary = decimal.Parse(Console.ReadLine());

                            rank.RankID = Guid.NewGuid();
                            rank.CreatedDate = DateTime.Now;
                            rank.ActiveFlag = true;
                            RankController rk = new RankController();
                            var obj = rk.InsertRank(rank);
                            if (obj == null)
                            {
                                Console.WriteLine("Add Failed");
                            }
                            else
                            {
                                Console.WriteLine("Add Successfully");
                            }                         
                            break;
                        case 2:
                            tbl_rank getAllRank= new tbl_rank();
                            RankController rkGetAll = new RankController();
                            var objGetRankAll = rkGetAll.GetAllRank();
                            if(objGetRankAll == null)
                            {
                                Console.WriteLine("No Rank to show");
                            }
                            else
                            {
                                foreach(var rankList in objGetRankAll)
                                {
                                    Console.WriteLine($"Rank ID: {rankList.RankID} \nRanK name: {rankList.RankName} \nRank: {rankList.Rank} \nSalary: {rankList.Salary}");
                                    Console.WriteLine("--------------------------------");
                                }
                            }
                            break;
                        case 3:
                            tbl_rank rankUpdate = new tbl_rank();
                            Console.Write("Enter rank ID: ");
                            rankUpdate.RankID = Guid.Parse(Console.ReadLine());
                         
                            Console.Write("Enter Rank: ");
                            rankUpdate.Rank = int.Parse(Console.ReadLine());
                            Console.Write("Enter RankName: ");
                            rankUpdate.RankName = Console.ReadLine();
                            Console.Write("Enter Salary: ");
                            rankUpdate.Salary = decimal.Parse(Console.ReadLine());

                            rankUpdate.UpdatedDate = DateTime.Now;
                            RankController rankUpdateController = new RankController();
                            bool rankUpdateObj = rankUpdateController.UpdateRank(rankUpdate.RankID, rankUpdate);

                            if (rankUpdateObj)
                            {
                                Console.WriteLine("Rank update successfully");
                            }else
                            {
                                Console.WriteLine("Rank update failed..");
                            }

                            break;
                        case 4:
                            tbl_rank rankSearchbyID = new tbl_rank();
                            Console.Write("Enter rank ID to search: ");
                            rankSearchbyID.RankID = Guid.Parse(Console.ReadLine());
                            RankController rankSearchController = new RankController();
                            var objRankSearch = rankSearchController.SearchRankByID(rankSearchbyID.RankID);
                            if (objRankSearch != null)
                            {
                                Console.WriteLine($"Rank ID: {objRankSearch.RankID} \nRanK name: {objRankSearch.RankName} \nRank: {objRankSearch.Rank} \nSalary: {objRankSearch.Salary}");
                             
                            }
                            break;
                        case 5:
                            tbl_rank rankDelete = new tbl_rank();
                            Console.Write("Enter rank ID to delete: ");
                            rankDelete.RankID = Guid.Parse(Console.ReadLine());
                            RankController deleteRankController = new RankController();
                            bool deleteObj = deleteRankController.DeleteRank(rankDelete.RankID);
                            if (deleteObj)
                            {
                                Console.WriteLine("Delete rank successfully");
                            }
                            else
                            {
                                Console.WriteLine("Delete rank failed");
                            }

                            break;
                    }
                    break ;
            }
        }
    }
}

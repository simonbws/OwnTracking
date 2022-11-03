using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
            try
            {
                db.EMPLOYEEs.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DeleteEmployee(int employeeID)
        {
            try
            {
                EMPLOYEE e = db.EMPLOYEEs.First(x => x.ID == employeeID);
                db.EMPLOYEEs.DeleteOnSubmit(e);
                db.SubmitChanges();
                ////each employee has a task so we have to remove it from a list and also another properties like salary
                //List<TASK> tasks = db.TASKs.Where(x => x.EmployeeID == employeeID).ToList();
                //db.TASKs.DeleteAllOnSubmit(tasks);
                //db.SubmitChanges();

                //List<SALARY2> salary = db.SALARY2s.Where(x => x.ID == employeeID).ToList();
                //db.SALARY2s.DeleteAllOnSubmit(salary);
                //db.SubmitChanges();

                //List<PERMISSION> permissions = db.PERMISSIONs.Where(x => x.ID == employeeID).ToList();
                //db.PERMISSIONs.DeleteAllOnSubmit(permissions);
                //db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EmployeePropertiesDTO> GetEmployees()
        {
            //we have to return 3 tables for all necessary info
            List<EmployeePropertiesDTO> employeeList = new List<EmployeePropertiesDTO>();
            var listJoin = (from e in db.EMPLOYEEs
                            join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
                            join p in db.POSITIONs on e.PositionID equals p.ID
                            select new
                            {
                                UserNo = e.UserNumber,
                                Name = e.Name,
                                Surname = e.Surname,
                                EmplooyeeID = e.ID,
                                Password = e.Password,
                                DepartmentName = d.DepartmentName,
                                PositionName = p.PositionName,
                                DepartmentID = e.DepartmentID,
                                PositionID = e.PositionID,
                                isAdmin = e.isAdmin,
                                Salary = e.Salary,
                                ImagePath = e.ImagePath,
                                BirthDay = e.Birthday,
                                Address = e.Address

                            }).OrderBy(x => x.UserNo).ToList();
            foreach (var item in listJoin)
            {
                EmployeePropertiesDTO dto = new EmployeePropertiesDTO();
                dto.Name = item.Name;
                dto.UserNumber = item.UserNo;
                dto.Surname = item.Surname;
                dto.EmployeeID = item.EmplooyeeID;
                dto.Password = item.Password;
                dto.DepartmentID = item.DepartmentID;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionID = item.PositionID;
                dto.PositionName = item.PositionName;
                dto.Salary = item.Salary;
                dto.isAdmin = item.isAdmin;
                dto.BirthDay = item.BirthDay;
                dto.Address = item.Address;
                dto.ImagePath = item.ImagePath;
                employeeList.Add(dto); // we added this dto to employee list
            }


            return employeeList;
        }

        public static List<EMPLOYEE> GetEmployees(int v, string text)
        {
            try
            {
                List<EMPLOYEE> list = db.EMPLOYEEs.Where(x => x.UserNumber == v && x.Password == text).ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EMPLOYEE> GetUsers(int v)
        {
            return db.EMPLOYEEs.Where(x => x.UserNumber == v).ToList();
        }

        public static void UpdateEmployee(int employeeID, int amount)
        {
            try
            {
                EMPLOYEE empl = db.EMPLOYEEs.First(x => x.ID == employeeID); //select employee with empl id
                //set salary
                empl.Salary = amount;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void UpdateEmployee(EMPLOYEE employee)
        {
            try
            {
                EMPLOYEE e = db.EMPLOYEEs.First(x=>x.ID == employee.ID);
                e.UserNumber = employee.UserNumber;
                e.Name = employee.Name;
                e.Surname = employee.Surname;
                e.Password = employee.Password;
                e.isAdmin = employee.isAdmin;
                e.Birthday = employee.Birthday;
                e.Address = employee.Address;
                e.DepartmentID = employee.DepartmentID;
                e.PositionID = employee.PositionID;
                e.Salary = employee.Salary;
                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateEmployee(POSITION position)
        {
            List<EMPLOYEE> list = db.EMPLOYEEs.Where(x =>x.PositionID == position.ID).ToList();
            foreach (var item in list)
            {
                item.DepartmentID = position.DepartmentID;
            }

            db.SubmitChanges();
        }
    }
}

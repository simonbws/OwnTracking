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
                employeeList.Add(dto); // we added this dto to employee list
            }


            return employeeList;
        }

        public static List<EMPLOYEE> GetUsers(int v)
        {
            return db.EMPLOYEEs.Where(x => x.UserNumber == v).ToList();
        }
    }
}

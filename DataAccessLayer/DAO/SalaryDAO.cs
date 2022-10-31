using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class SalaryDAO : EmployeeContext
    {
        public static void AddSalary(SALARY2 salary)
        {
            try
            {
               db.SALARY2s.InsertOnSubmit(salary);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<MONTH> GetMonths()
        {
            return db.MONTHs.ToList();
        }

        public static List<SalaryPropertiesDTO> GetSalaries()
        {
            List<SalaryPropertiesDTO> salaryList = new List<SalaryPropertiesDTO>();
            var list = (from s in db.SALARY2s
                        join e in db.EMPLOYEEs on s.EmployeeID equals e.ID
                        join m in db.MONTHs on s.MonthID equals m.ID
                        select new
                        {
                            UserNumber = e.UserNumber,
                            name = e.Name,
                            surname = e.Surname,
                            EMPLOYEEID = s.EmployeeID,
                            SalaryAmount = s.Amount,
                            year = s.Year,
                            monthname = m.MonthName,
                            monthID = s.MonthID,
                            salaryID = s.ID,
                            departmentid = e.DepartmentID,
                            positionID = e.PositionID
                        }).OrderBy(x => x.year).ToList();
            foreach (var l in list)
            {
                SalaryPropertiesDTO dto=new SalaryPropertiesDTO();
                dto.UserNumber = l.UserNumber;
                dto.Name = l.name;
                dto.Surname = l.surname;
                dto.EmployeeID = l.EMPLOYEEID;
                dto.SalaryAmount = l.SalaryAmount;
                dto.SalaryYear = l.year;
                dto.MonthName = l.monthname;
                dto.MonthID = l.monthID;
                dto.SalaryID = l.salaryID;
                dto.DepartmentID = l.departmentid;
                dto.PositionID = l.positionID;
                dto.OldSalaryForUpdate = l.SalaryAmount;
                salaryList.Add(dto);

            }
            return salaryList;
        }
    }
}

using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAO;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class SalaryBLL
    {
        public static void AddSalary(SALARY2 salary, bool isSalaryBiggerThanOld)
        {
            SalaryDAO.AddSalary(salary);
            if (isSalaryBiggerThanOld)
            {
                EmployeeDAO.UpdateEmployee(salary.EmployeeID, salary.Amount);
            }
        }

        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Employees = EmployeeDAO.GetEmployees(); // we added and get employee to that list
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Months = SalaryDAO.GetMonths();
            dto.Salaries = SalaryDAO.GetSalaries();
            return dto;

        }

        public static void UpdateSalary(SALARY2 salary, bool isSalaryBiggerThanOld)
        {
            SalaryDAO.UpdateSalary(salary);
            if (isSalaryBiggerThanOld)
            {
                EmployeeDAO.UpdateEmployee(salary.EmployeeID, salary.Amount);
            }
        }
    }
}

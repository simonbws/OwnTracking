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
        public static void AddSalary(SALARY2 salary)
        {
            SalaryDAO.AddSalary(salary);
        }

        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Employees = EmployeeDAO.GetEmployees(); // we added and get employee to that list
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Months = SalaryDAO.GetMonths();
            return dto;

        }
    }
}

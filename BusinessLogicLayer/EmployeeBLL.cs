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
    public class EmployeeBLL
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
            EmployeeDAO.AddEmployee(employee);
        }

        public static EmployeeDTO GetAll()
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto.Departments=DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Employees = EmployeeDAO.GetEmployees();
            return dto;
        }

        public static List<EMPLOYEE> GetEmployee(int v, string text)
        {
            return EmployeeDAO.GetEmployees(v, text);
        }

        public static bool isUnique(int v)
        {
            List<EMPLOYEE> list = EmployeeDAO.GetUsers(v);
            if (list.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

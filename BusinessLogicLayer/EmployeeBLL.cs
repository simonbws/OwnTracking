using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAO;

namespace BusinessLogicLayer
{
    public class EmployeeBLL
    {
        public static EmployeeDTO GetAll()
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto.Departments=DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            return dto;
        }
    }
}

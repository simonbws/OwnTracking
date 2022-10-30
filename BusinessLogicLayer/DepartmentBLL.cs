using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAO;

namespace BusinessLogicLayer
{
    public class DepartmentBLL
    {
        public static void AddDepartment(DEPARTMENT department)
        {
            DepartmentDAO.AddDepartment(department);
        }

        public static List<DEPARTMENT> GetDepartments()
        {
            return DepartmentDAO.GetDepartments();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class SalaryDTO
    {
        public List<SalaryPropertiesDTO> Salaries { get; set; }
        public List<EmployeePropertiesDTO> Employees { get; set; }
        public List<MONTH> Months { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<DEPARTMENT> Departments { get; set; }
    }
}

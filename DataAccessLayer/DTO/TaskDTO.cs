using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class TaskDTO
    {
        public List<EmployeePropertiesDTO> Employees { get; set; }
        public List<DEPARTMENT> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<TASKSTATE> TaskStates { get; set; }
        public List<TaskPropertiesDTO> Tasks { get; set; }

        
    }
}

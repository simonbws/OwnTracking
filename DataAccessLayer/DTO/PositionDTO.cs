using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class PositionDTO:POSITION
    {
        public string DepartmentName { get; set; }
        public int DepartmentToChangeID { get; set; }
    }
}

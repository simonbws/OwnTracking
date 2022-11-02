using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAO;
using DataAccessLayer.DTO;

namespace BusinessLogicLayer
{
    public class PositionBusinessLL
    {
        public static void AddPosition(POSITION position)
        {
            PositionDAO.AddPosition(position);
        }

        public static List<PositionDTO> GetPositions()
        {
            return PositionDAO.GetPositions();
        }

        public static void UpdatePosition(POSITION position, bool isChangeOrNot)
        {
            PositionDAO.UpdatePosition(position);
            if (isChangeOrNot)
            {
                EmployeeDAO.UpdateEmployee(position);
            }
        }
    }
}

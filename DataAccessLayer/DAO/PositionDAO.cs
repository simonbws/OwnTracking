using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class PositionDAO : EmployeeContext
    {
        public static void AddPosition(POSITION position)
        {
            try
            {
                db.POSITIONs.InsertOnSubmit(position);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DeletePosition(int iD)
        {
            try
            {
                POSITION position = db.POSITIONs.First(x => x.ID == iD);
                db.POSITIONs.DeleteOnSubmit(position);
                db.SubmitChanges();
                //if we delete any position, that means, we have to delete all properties related to this employee
                //so we need to make a trigger
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<PositionDTO> GetPositions()
        {
            try
            {
                var list = (from p in db.POSITIONs
                            join d in db.DEPARTMENTs on p.DepartmentID equals d.ID
                            select new
                            {
                                positionID = p.ID,
                                positionName = p.PositionName,
                                departmentName = d.DepartmentName,
                                departmentID = p.DepartmentID
                            }).OrderBy(x => x.positionID).ToList();
                List<PositionDTO> posList = new List<PositionDTO>();
                foreach (var item in list)
                {
                    PositionDTO dto = new PositionDTO();
                    dto.ID = item.positionID;
                    dto.PositionName = item.positionName;
                    dto.DepartmentName = item.departmentName;
                    dto.DepartmentID = item.departmentID;
                    posList.Add(dto);
                }
                return posList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void UpdatePosition(POSITION position)
        {
            try
            {
                POSITION p = db.POSITIONs.First(x => x.ID == position.ID);
                p.PositionName = position.PositionName;
                p.DepartmentID = position.DepartmentID;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

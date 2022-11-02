using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class PermissionDAO : EmployeeContext
    {
        public static void AddPermission(PERMISSION permission)
        {
            try
            {
                db.PERMISSIONs.InsertOnSubmit(permission);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<PERMISSIONSTATE> GetStates()
        {
            return db.PERMISSIONSTATEs.ToList();
        }

        public static List<PermissionDetailDTO> GetPermissions()
        {
            List<PermissionDetailDTO> permissions = new List<PermissionDetailDTO>();

            var list = (from p in db.PERMISSIONs
                        join s in db.PERMISSIONSTATEs on p.PermissionState equals s.ID
                        join e in db.EMPLOYEEs on p.EmployeeID equals e.ID
                        select new
                        {
                            UserNumber = e.UserNumber,
                            name = e.Name,
                            Surname = e.Surname,
                            StateName = s.StateName,
                            startID = p.PermissionState,
                            startDate = p.PermissionStartDate,
                            endDate = p.PermissionEndDate,
                            employeeID = p.EmployeeID,
                            PermissionID = p.ID,
                            exaplanation = p.PermissionExplanation,
                            DayAmount = p.PermissionDay,
                            DepartmentID = e.DepartmentID,
                            positionID = e.PositionID
                        }).OrderBy(x => x.startID).ToList();
            //we need to asign this list to permissionDetailDTO

            foreach (var item in list)
            {
                PermissionDetailDTO dto = new PermissionDetailDTO();
                dto.UserNumber = item.UserNumber;
                dto.Name = item.name;
                dto.Surname = item.Surname;
                dto.EmployeeID = item.employeeID;
                dto.PermissionDayAmount = item.DayAmount;
                dto.StartDate = item.startDate;
                dto.EndDate = item.endDate;
                dto.DepartmentID = item.DepartmentID;
                dto.PositionID = item.positionID;
                dto.StateName = item.StateName;
                dto.PermissionID = item.PermissionID;
                permissions.Add(dto);

            }
            return permissions;
        }

        public static void UpdatePermission(PERMISSION permission)
        {
            try
            {
                //fro update, first we have to select data from the table
                PERMISSION perm = db.PERMISSIONs.First(d => d.ID == permission.ID);
                perm.PermissionStartDate = permission.PermissionStartDate;
                perm.PermissionEndDate = permission.PermissionEndDate;
                perm.PermissionExplanation = permission.PermissionExplanation;
                perm.PermissionDay = permission.PermissionDay;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void UpdatePermission(int permissionID, int accepted)
        {
            try
            {
                PERMISSION perm = db.PERMISSIONs.First(d=>d.ID == permissionID);
                perm.PermissionState = accepted;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DeletePermission(int permissionID)
        {
            try
            {
                PERMISSION p = db.PERMISSIONs.First(x => x.ID == permissionID);
                db.PERMISSIONs.DeleteOnSubmit(p);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

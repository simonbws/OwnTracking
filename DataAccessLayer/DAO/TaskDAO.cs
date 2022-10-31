using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class TaskDAO : EmployeeContext
    {
        public static void AddTask(TASK task)
        {
            try
            {
                db.TASKs.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<TaskPropertiesDTO> GetTasks()
        {
            List<TaskPropertiesDTO> taskList = new List<TaskPropertiesDTO>();

            var listTasks = (from t in db.TASKs
                             join s in db.TASKSTATEs on t.TaskState equals s.ID
                             join e in db.EMPLOYEEs on t.EmployeeID equals e.ID
                             join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
                             join p in db.POSITIONs on e.PositionID equals p.ID
                             select new
                             {
                                 taskID = t.ID,
                                 title = t.TaskTitle,
                                 content = t.TaskContent,
                                 startdate = t.TaskStartDate,
                                 deliveryDate = t.TaskDeliveryDate,
                                 taskStateName = s.StateName,
                                 taskStateID = t.TaskState,
                                 UserNumber = e.UserNumber,
                                 Name = e.Name,
                                 EmployeeId = t.EmployeeID,
                                 Surname = e.Surname,
                                 positionName = p.PositionName,
                                 departmentName = d.DepartmentName,
                                 positionID = e.PositionID,
                                 departmentID = e.DepartmentID

                             }).OrderBy(x => x.startdate).ToList();
            foreach (var item in listTasks)
            {
                TaskPropertiesDTO dto = new TaskPropertiesDTO();
                dto.TaskID = item.taskID;
                dto.Title = item.title;
                dto.Content = item.content;
                dto.TaskStartDate = item.startdate;
                dto.TaskDeliveryDate = item.deliveryDate;
                dto.TaskStateName = item.taskStateName;
                dto.taskStateID = item.taskStateID;
                dto.UserNumber = item.UserNumber;
                dto.Name = item.Name;
                dto.Surname=item.Surname;
                dto.DepartmentName = item.departmentName;
                dto.PositionID = item.positionID;
                dto.PositionName = item.positionName;
                dto.EmployeeID = item.EmployeeId;
                taskList.Add(dto);
            }
            return taskList;
        }

        public static List<TASKSTATE> GetTaskStates()
        {
            return db.TASKSTATEs.ToList();
        }
    }
}

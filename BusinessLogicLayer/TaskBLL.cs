﻿using DataAccessLayer;
using DataAccessLayer.DAO;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLogicLayer
{
    public class TaskBLL
    {
        public static void AddTask(TASK task)
        {
            TaskDAO.AddTask(task);
        }

        public static TaskDTO GetAll()
        {
            TaskDTO taskDTO = new TaskDTO();
            taskDTO.Employees=EmployeeDAO.GetEmployees();
            taskDTO.Departments=DepartmentDAO.GetDepartments();
            taskDTO.Positions = PositionDAO.GetPositions();
            taskDTO.TaskStates = TaskDAO.GetTaskStates();
            return taskDTO;
        }
    }
}

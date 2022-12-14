using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class DepartmentDAO : EmployeeContext
    {
        public static void AddDepartment(DEPARTMENT department)
        {
            try
            {
                db.DEPARTMENTs.InsertOnSubmit(department);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DeleteDepartment(int iD)
        {
            try
            {
                DEPARTMENT d = db.DEPARTMENTs.First(x => x.ID == iD);
                db.DEPARTMENTs.DeleteOnSubmit(d);
                db.SubmitChanges();
                //now we are making a trigger
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<DEPARTMENT> GetDepartments()
        {
            return db.DEPARTMENTs.ToList();
        }

        public static void UpdateDepartment(DEPARTMENT department)
        {
            try
            {
                DEPARTMENT dep = db.DEPARTMENTs.First(x => x.ID == department.ID);
                //set name
                dep.DepartmentName = department.DepartmentName;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

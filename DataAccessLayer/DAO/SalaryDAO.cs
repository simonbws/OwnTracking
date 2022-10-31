using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class SalaryDAO : EmployeeContext
    {
        public static void AddSalary(SALARY2 salary)
        {
            try
            {
               db.SALARY2s.InsertOnSubmit(salary);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<MONTH> GetMonths()
        {
            return db.MONTHs.ToList();
        }
    }
}

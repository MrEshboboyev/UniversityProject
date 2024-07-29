using BOL.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class StudentsDataDAL : IStudentsDataDAL
    {
        public List<Students> GetStudentsListDAL()
        {
            return new List<Students>();    
        }
    }
}

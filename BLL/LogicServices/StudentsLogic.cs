using BOL.DatabaseEntities;
using DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BLL.LogicServices
{
    public class StudentsLogic : IStudentsLogic
    {
        private readonly IStudentsDataDAL _studentsDataDAL;

        public StudentsLogic(IStudentsDataDAL studentsDataDAL)
        {
            _studentsDataDAL = studentsDataDAL;
        }

        public List<Students> GetStudentsListLogic()
        {
            List<Students> result = new List<Students>();

            result = _studentsDataDAL.GetStudentsListDAL();

            return result;
        }
    }
}

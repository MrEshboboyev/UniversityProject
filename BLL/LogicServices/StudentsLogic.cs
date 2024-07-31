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

        public string CreateStudentLogic(Students student)
        {
            string result = String.Empty;

            if (student.Email.StartsWith("al"))
            {
                result = "Email should not be start with 'al'";
                return result;
            }

            result = _studentsDataDAL.CreateStudentsDAL(student);
            if(result == "Saved successfully")
            {
                return result;
            }
            else
            {
                result = "An error occurred. PLease try again!";
                return result;
            }

        }
    }
}

using BOL.DatabaseEntities;
using DAL.DataContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public class StudentsDataDAL : IStudentsDataDAL
    {
        private readonly IDapperOrmHelper _dapperOrmHelper;
        public StudentsDataDAL(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }

        public List<Students> GetStudentsListDAL()
        {
            List<Students> students = new List<Students>();

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string sqlQuery = "SELECT * FROM \"Students\"";
                    students = dbConnection.Query<Students>(sqlQuery, commandType: 
                        CommandType.Text).ToList();   
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;    
            }

            return students;
        }

        #region Create Students

        public string CreateStudentsDAL(Students student)
        {
            string result = String.Empty;

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    dbConnection.Execute(@"INSERT INTO ""Students"" (FirstName, LastName, Email) 
                        VALUES (@FirstName, @LastName, @Email)", 
                        new
                        {
                            FirstName = student.FirstName, LastName = student.LastName, Email = student.Email 
                        },
                        commandType: CommandType.Text);

                    result = "Saved successfully";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return result;
        }

        #endregion
    }
}

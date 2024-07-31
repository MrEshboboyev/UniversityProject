using BLL.LogicServices;
using BOL.CommonEntities;
using BOL.DatabaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsLogic _studentsLogic;

        public StudentsController(IStudentsLogic studentsLogic)
        {
            _studentsLogic = studentsLogic;
        }

        public IActionResult StudentsList()
        {
            // main model
            StudentModule model = new StudentModule();

            // get students list
            model.studentsList = _studentsLogic.GetStudentsListLogic().ToList();

            return View(model);
        }

        #region Create Student

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudentPost(Students model)
        {
            if (ModelState.IsValid)
            {
                var result = _studentsLogic.CreateStudentLogic(model);

                if (result != "Saved successfully")
                {
                    TempData["ErrorTemp"] = result;
                }
                return RedirectToAction("StudentsList", "Students");
            }

            return View(model);
        }

        #endregion

        #region Update Student

        [HttpGet]
        public IActionResult UpdateStudent(int studentId)
        {
            var student = _studentsLogic.GetStudentByIdLogic(studentId);
            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudentPost(Students student)
        {
            if (ModelState.IsValid)
            {
                var result = _studentsLogic.UpdateStudentLogic(student);

                if(result == "Updated Successfully!")
                {
                    return RedirectToAction("StudentsList");
                }
                else
                {
                    TempData["ErrorTemp"] = "An error occurred updating Student.PLease, try again";
                    return RedirectToAction("StudentsList");
                }
            }

            return View(student);
        }
        #endregion

        #region Delete Student

        [HttpGet]
        public IActionResult DeleteStudent(int studentId)
        {
            var student = _studentsLogic.GetStudentByIdLogic(studentId);
            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteStudentPost(int studentId)
        {
            var result = _studentsLogic.DeleteStudentLogic(studentId);

            if(result != "Deleted Successfully!")
            {
                TempData["ErrorTemp"] = result;
            }
            
            return RedirectToAction("StudentsList");
        }

        #endregion
    }
}

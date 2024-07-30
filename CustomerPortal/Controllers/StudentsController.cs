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
    }
}

using BOL.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.CommonEntities
{
    public class StudentModule
    {
        public List<Students>? studentsList { get; set; }
        public List<Courses>? coursesList { get; set; }
    }
}

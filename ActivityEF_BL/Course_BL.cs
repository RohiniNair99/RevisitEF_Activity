using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityEF_DTO;
using ActivityEF_DAL;

namespace ActivityEF_BL
{
    public class Course_BL
    {
        Course_DAL dalObj = new Course_DAL();
        public List<Course_DTO> GetAllCourses()
        {
            try
            {
                var lstCourse = dalObj.GetAllCourses();
                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityEF_DTO;
using ActivityEF_DAL;

namespace ActivityEF_BL
{
    public class Faculty_BL
    {
        Faculty_DAL facultyDalObj;
        public Faculty_BL()
        {
            facultyDalObj = new Faculty_DAL();
        }
        public List<Faculty_DTO> GetAllFaculties()
        {
            try
            {
                var lstFaculty = facultyDalObj.GetAllFaculties();
                return lstFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseFacultyMap_DTO> GetCoursesByFacultyName(string facName)
        {
            try
            {

                var courseList = facultyDalObj.GetCoursesByFacultyName(facName);
                return courseList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseFacultyMap_DTO> GetFacultiesByCourseId(string courseId)
        {
            try
            {
                var facultyList = facultyDalObj.GetFacultyFromCId(courseId);
                return facultyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

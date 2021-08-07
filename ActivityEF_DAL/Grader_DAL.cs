using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityEF_DTO;

namespace ActivityEF_DAL
{
    public class Grader_DAL
    {
        ConnectX connect;

        public Grader_DAL()
        {

            connect = new ConnectX();
        }


        public List<Grader_DTO> GetParticipantsbyCourse(string courseId)
        {
            List<Grader_DTO> listOfParticipants = new List<Grader_DTO>();
            try
            {

                var dataFromDb = connect.Graders.Join(connect.BatchCourseFacultyMappings, x => x.BCFId, y => y.BCFId, (x, y) => new { grader = x, bcf = y }).Where(xy => xy.bcf.CourseId == courseId).Select(xy => new { xy.grader.PSNO, xy.grader.Score });
                foreach (var item in dataFromDb)
                {
                    listOfParticipants.Add(
                        new Grader_DTO
                        {

                            PSNO = item.PSNO,
                            Score = item.Score
                        }); ;
                }
                return listOfParticipants;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Grader_DTO> TopPerformers(string cid)
        {
            List<Grader_DTO> lstToppers = new List<Grader_DTO>();

            try
            {

                var resultFromDb = connect.Graders.Join(connect.BatchCourseFacultyMappings, x => x.BCFId, y => y.BCFId, (x, y) => new { grader = x, bcf = y }).Where(xy => xy.bcf.CourseId == cid).Select(xy => new { xy.grader.PSNO, xy.grader.Score }).OrderByDescending(xy => xy.Score).Take(5);
                foreach (var item in resultFromDb)
                {
                    lstToppers.Add(
                        new Grader_DTO
                        {
                            PSNO = item.PSNO,
                            Score = item.Score
                        });
                }
                return lstToppers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Grader_DTO> BottomPerformance(string cid)
        {
            List<Grader_DTO> lstBottomPerformers = new List<Grader_DTO>();
            try
            {

                var resultFromDb = connect.Graders.Join(connect.BatchCourseFacultyMappings, x => x.BCFId, y => y.BCFId, (x, y) => new { grader = x, bcf = y }).Where(xy => xy.bcf.CourseId == cid).Select(xy => new { xy.grader.PSNO, xy.grader.Score }).OrderBy(xy => xy.Score).Take(5);
                foreach (var item in resultFromDb)
                {
                    lstBottomPerformers.Add(
                        new Grader_DTO
                        {
                            PSNO = item.PSNO,
                            Score = item.Score
                        });
                }
                return lstBottomPerformers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Grader_DTO> GetCoursesFromFacultyId(string psno)
        {
            List<Grader_DTO> lstGraderCourses = new List<Grader_DTO>();
            try
            {
                var dataFromDb = connect.Graders.Join(connect.BatchCourseFacultyMappings, x => x.BCFId, y => y.BCFId, (x, y) => new { grader = x, bcf = y }).Where(xy => xy.bcf.FacultyId == psno).Select(xy => new { xy.grader.PSNO, xy.grader.Score, xy.bcf.CourseId });
                foreach (var item in dataFromDb)
                {
                    lstGraderCourses.Add(
                        new Grader_DTO
                        {
                            PSNO = item.PSNO,
                            Score = item.Score,
                            CourseId = item.CourseId
                        }); ;
                }
                return lstGraderCourses;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

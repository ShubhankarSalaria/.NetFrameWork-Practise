using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using modeldesign;
namespace databank
{
    /// <summary>
    /// this is the databank for the static value that are already present 
    /// </summary>
    public static class DataBank
    {
        /// <summary>
        /// list for taking the  sessions is  specified here  
        /// </summary>
        public static List<StudentSession>?sessions = new List<StudentSession>() ; 

        /// <summary>
        /// list for taking the students is specified here 
        /// </summary>
        public static List<Student>?students = new List<Student>();

        /// <summary>
        /// list for taking the students is specified here 
        /// </summary>
        public static List<StudentsAndSession>?stusessions = new List<StudentsAndSession>();


        /// <summary>
        /// static constructor are called when one of the method is called and it work only once 
        /// </summary>
        static DataBank()
        {

            /// <summary>
            /// value that i want to always be present is specified here for students  
            /// </summary>
            students.Add(new Student()
            {
                Id=1,
                Name="Anu"
            });
            students.Add(new Student()
            {
                Id=2,
                Name="bhanu"
            });
            students.Add(new Student()
            {
                Id=3,
                Name="manu"
            });
            students.Add(new Student()
            {
                Id=4,
                Name="sonu"
            });
            /// <summary>
            /// value that i want to always be present is specified here for session 
            /// </summary>
            sessions.Add(new StudentSession()
            {
                Id=1,
                Name="sn1",
                Detail="yes man"
            });
            sessions.Add(new StudentSession()
            {
                Id=2,
                Name="sn2",
                Detail="damn"
            });
            sessions.Add(new StudentSession()
            {
                Id=3,
                Name="sn3",
                Detail="doom"
            });
            sessions.Add(new StudentSession()
            {
                Id=4,
                Name="sn4",
                Detail ="shame"
            });
        }
        /// <summary>
        /// students 
        /// </summary>
        /// <returns>students</returns>
        public static List<Student> GetStudents()
        {
            return students;
        }
        public static List<StudentSession> GetSessions()
        {
            return sessions;
        }
        public static List<StudentsAndSession> GetStudentsAndSessions()
        {
            return stusession;
        }
    }
}



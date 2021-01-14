using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repositories;



namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static private List<Student> students = new List<Student>()
        {
            new Student(){Id = 1 , Name = "Slava" , LastName = "Dzhus"},
            new Student(){Id = 2 , Name = "Max" , LastName = "Davis"},
            new Student(){Id = 3 , Name = "Ted" , LastName = "Brown"},
        };
        private StudentRepository repoStudent = new StudentRepository(students);



        /// <summary>
        /// Returns All Students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public List<Student> Get()
        {
            return students;
        }

     
        /// <summary>
        ///  Returns a specific Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        public Student Get(int id)
        {
            return repoStudent.Get(id);
        }

        /// <summary>
        /// Creates a Student
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Students
        ///     {
        ///        "id": 1,
        ///        "name": "Student name",
        ///        "lastname": "Student lastname"
        ///     }
        ///
        /// </remarks>
        /// <param name="student"></param>
        /// <response code="200">Returns the newly created student</response>
        /// <response code="400">If something wrong</response>  
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post(Student student)
        {
            repoStudent.Create(student);
        }

 
        /// <summary>
        /// Updates already existed Student
        /// </summary>
        /// <param name="student"></param>
        [HttpPut]
        public void Put(Student student)
        {
            repoStudent.Update(student);
        }


        /// <summary>
        /// Deletes a specific Student
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repoStudent.Remove(repoStudent.Get(id));
        }
    }
}

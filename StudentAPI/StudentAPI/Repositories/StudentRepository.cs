using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentAPI.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private  List<Student> students;
        public StudentRepository(List<Student> students)
        {
            this.students = students;
        }
        public void Create(Student entity)
        {
            students.Add(entity);
        }

        public Student Get(int id)
        {
            return students.Where(x => x.Id == id).FirstOrDefault();
        }


        public void Remove(Student entity)
        {
            students.Remove(entity);
        }

        public void Update(Student entity)
        {
            students.Where(x => x.Id == entity.Id).FirstOrDefault().Name = entity.Name;
            students.Where(x => x.Id == entity.Id).FirstOrDefault().LastName = entity.LastName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; } = 0;
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webcoreapi.Model;


namespace webcoreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> listStudent = new List<Student>()
        {
            new Student(){Id=1,Name="An",Roll=1001},
            new Student(){Id=2,Name="Bình",Roll=1002},
            new Student(){Id=3,Name="Châu",Roll=1003},
            new Student(){Id=4,Name="Dương",Roll=1004},
            new Student(){Id=5,Name="Đức",Roll=1005},
        };

        [HttpGet]
        public IActionResult GET()
        {
            if (listStudent.Count == 0)
            {
                return NotFound();
            }
            return Ok(listStudent);
        }

        [HttpGet("GetStudent")]
        public IActionResult GET(int id)
        {
            var student = listStudent.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound("No Student Found.");
            }
            return Ok(student);
        }

        [HttpGet("UpdateStudent")]
        [HttpPost]
        public IActionResult POST(Student student)
        {
            listStudent.Add(student);
            if (listStudent.Count == 0)
            {
                return NotFound("no List found");
            }
            return Ok(listStudent);
        }

        [HttpGet("DeleteStudent")]
        [HttpDelete]
        public IActionResult DELETE(int id)
        {
            var student = listStudent.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound("No Student Found");
            }
            listStudent.Remove(student);
            if (listStudent.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(listStudent);
        }
    }
}

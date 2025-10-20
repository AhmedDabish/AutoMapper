using AutoMapper;
using AutoMapperExample.Data;
using AutoMapperExample.DTOs;
using AutoMapperExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        
        public StudentsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>>  GetAll()
        {
            var s= await _db.Students.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(s));
            
        }



        [HttpGet("id")]
        public async Task<ActionResult<StudentDto>> GeById(int id)
        {
            var s= await _db.Students.SingleOrDefaultAsync(x => x.Id==id);
           if (s != null)
            
                return Ok(_mapper.Map<StudentDto>(s));
            else
                return BadRequest();

        }



        [HttpPost]
        public async Task<IActionResult>Add_Student(CreateStudentDto student) 
        {
            var s=_mapper.Map<Student>(student);

             await _db.Students.AddAsync(s);
            _db.SaveChangesAsync();
            return Ok(s);
        }



        [HttpPut("id")]
       public async Task <IActionResult> update_row(int id ,StudentDto ss)
        {
            var s=await _db.Students.SingleOrDefaultAsync(x =>x.Id==id);
            if (s == null)
                return NotFound();
            _mapper.Map<Student>(ss);
            await _db.SaveChangesAsync();
            return Ok();


        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var s= await _db.Students.SingleOrDefaultAsync( x => x.Id==id);
            if(s == null)
                return NotFound();
            _db.Students.Remove(s);
            return Ok();
        }




            }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using TestBTlab.Models;
using TestBTLab.Models;

namespace TestBTlab.Controllers
{
    //контроллер API с REST архитектурой
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : Controller
    {
        private readonly ITimeSheetCRUD _crud;
        public TimeSheetsController(ITimeSheetCRUD timeSheetCRUD) 
        {
            _crud = timeSheetCRUD;
        }

        [HttpGet]
        public IEnumerable<TimeSheet> Get()
        {
            return _crud.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_crud.GetOne(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Json(_crud.Delete(id));
        }

        [HttpPost]
        public IActionResult Post(TimeSheet timeSheet)
        {
            return Json(_crud.Create(timeSheet));
        }

        [HttpPut]
        public IActionResult Put(TimeSheet timeSheet)
        {
            return  Json(_crud.Update(timeSheet));
        }

    }
}

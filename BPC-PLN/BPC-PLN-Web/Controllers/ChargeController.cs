using Microsoft.AspNetCore.Mvc;

namespace BPC_PLN_Web.Controllers
{
    public class ChargeController : Controller
    {


        public ChargeController()
        {

        }
        public IActionResult Index()
        {
            //return View();

            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] List<> employees)
        {
            _employees = employees;
            return Ok(new { message = "اطلاعات ذخیره شد!" });
        }
    }
}

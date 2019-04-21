using System.Web.Mvc;

namespace HMS.Web.Controllers
{
    public class TablesController : Controller
    {

        public ActionResult StaticTables()
        {
            return View();
        }

        public ActionResult DataTables()
        {
            return View();
        }

        public ActionResult FooTables()
        {
            return View();
        }

        public ActionResult jqGrid()
        {
            return View();
        }
    }
}
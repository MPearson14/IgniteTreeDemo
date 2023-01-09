using IgniteTreeDemo.Models;
using Infragistics.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IgniteTreeDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private IQueryable<TreeItemModel> GetDefaultDataSource()
        {
            IList<TreeItemModel> myReturn = new List<TreeItemModel>
            {
                new TreeItemModel("Parent1", "Parent 1", "Parent1", new List<TreeItemModel>()),
				new TreeItemModel("Parent2", "Parent 2", "Parent2", new List<TreeItemModel>()),
				new TreeItemModel("Parent3", "Parent 3", "Parent3", new List<TreeItemModel>()),
				new TreeItemModel("Parent4", "Parent 4", "Parent4", new List<TreeItemModel>())
			};

            return myReturn.AsQueryable();
        }

        public IActionResult Index()
        {
            HomeModel myModel = new() { TreeDataSource = GetDefaultDataSource() };

            return View(myModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		[ActionName("GetTreeDataOnDemand")]
		public JsonResult GetTreeDataOnDemand(string path, string binding, int depth)
		{
			TreeModel model = new();

            model.DataSource = new List<TreeItemModel>
            {
                new TreeItemModel("Parent1", "Parent 1", "Parent1", new List<TreeItemModel>()
                {
                    new TreeItemModel("Child1", "Child 1", "Child1", new List<TreeItemModel>()),
                    new TreeItemModel("Child2", "Child 2", "Child2", new List<TreeItemModel>()),
                    new TreeItemModel("Child3", "Child 3", "Child3", new List<TreeItemModel>()),
                    new TreeItemModel("Child4", "Child 4", "Child4", new List<TreeItemModel>()),
                })
            }.AsQueryable();

			JsonResult myResult = model.GetData(path, binding);

            return myResult;
		}
	}
}
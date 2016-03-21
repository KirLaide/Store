using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int Id)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == Id);
            return View(product);
        }
    }
}
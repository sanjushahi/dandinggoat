using System.CodeDom;
using DancingGoat.Models;
using KenticoCloud.Delivery;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DancingGoat.Controllers
{
    public partial class CoffeesController : ControllerBase
    {

        public async Task<ActionResult> Index()
        {
            var response = await client.GetItemsAsync<Coffee>(
                new EqualsFilter("system.type", Coffee.Codename),
                CoffeeThumbnailViewModel.GetProjectionQueryParameter(),
                new OrderParameter("elements." + Coffee.CoffeeNameCodename),                
                new DepthParameter(0)
            );

            var coffeeThumbails = response.Items.Select(coffee => new CoffeeThumbnailViewModel(coffee));

            return View(coffeeThumbails);
        }
    }
}
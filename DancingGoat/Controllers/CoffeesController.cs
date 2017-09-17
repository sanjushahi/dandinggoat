using System.CodeDom;
using DancingGoat.Models;
using KenticoCloud.Delivery;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DancingGoat.Models.ViewModels;

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

            var coffeeThumbails = response.Items.Select(CoffeeThumbnailViewModel.ConvertFromCoffee);

            return View(coffeeThumbails);
        }

        public async Task<ActionResult> Show(string urlSlug)
        {
            var response = await client.GetItemsAsync<Coffee>(
                new EqualsFilter("system.type", Coffee.Codename),
                new EqualsFilter("elements." + Coffee.UrlLabelCodename, urlSlug),
                new DepthParameter(1)
            );            

            if (response.Items.Count == 0)
            {
                throw new HttpException(404, "Not found");
            }
            else
            {
                var coffee = response.Items[0];
                return View(CoffeeDetailViewModel.GetCoffeeDetailForPersona(coffee, "some-persona"));
            }
        }
    }
}
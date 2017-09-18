using DancingGoat.Models;
using KenticoCloud.Delivery;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DancingGoat.Models.ViewModels;

namespace DancingGoat.Controllers
{
    public class CafesController : ControllerBase
    {
        public async Task<ActionResult> Index()
        {
            var queryParameters = FindCafesViewModel.GetQueryParameters();
            queryParameters.Add(new DepthParameter(2));

            var response = await client.GetItemsAsync<SelectedCafes>(queryParameters);
            var findCafesDataModel = response.Items.FirstOrDefault();
            var viewModel = FindCafesViewModel.GetCafesForPersona(findCafesDataModel, "defaultPersona");

            return View(viewModel);
        }
    }
}
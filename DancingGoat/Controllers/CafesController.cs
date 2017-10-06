using DancingGoat.Models;
using KenticoCloud.Delivery;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DancingGoat.Models.ViewModels;
using KenticoCloud.Personalization.MVC;

namespace DancingGoat.Controllers
{
    public class CafesController : ControllerBase
    {
        public async Task<ActionResult> Index()
        {
            var queryParameters = FindCafesViewModel.GetQueryParameters();
            queryParameters.Add(new DepthParameter(2));

            var response = await client.GetItemsAsync<SelectedCafes>(queryParameters);
            var visitorSegments =
                await personalizationClient.GetVisitorSegmentsAsync(Request.GetCurrentPersonalizationUid());

            var findCafesDataModel = response.Items.FirstOrDefault();
            var viewModel = FindCafesViewModel.GetCafesForPersona(findCafesDataModel, visitorSegments.Segments);

            return View(viewModel);
        }
    }
}
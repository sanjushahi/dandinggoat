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
            var response = await client.GetItemsAsync<SelectedCafes>(FindCafesViewModel.GetQueryParameters());
            var findCafesDataModel = response.Items.FirstOrDefault();
            var viewModel = FindCafesViewModel.GetCafesForPersona(findCafesDataModel, "defaultPersona");

            return View(viewModel);
        }
    }
}
using System.Threading.Tasks;
using System.Web.Mvc;
using DancingGoat.Models;

namespace DancingGoat.Controllers
{
    public class PartnershipController : ControllerBase
    {
        public async Task<ActionResult> Index()
        {
            var partnershipBenefitsResponse = await client.GetItemAsync<PartnershipBenefits>("partnership_benefits");
            ViewBag.PartnershipRequested = TempData["formApplied"] ?? false;
            return View(partnershipBenefitsResponse.Item);
        }
        
        /// <summary>
        /// Dummy action; form information is being handed over to Kentico Cloud Engagement management service through JavaScript.
        /// </summary>
        [HttpPost]
        public ActionResult Application()
        {
            // If needed, put your code here to work with the uploaded data in MVC.
            TempData["formApplied"] = true;
            return RedirectToAction("Index");
        }
    }
}

using System.Threading.Tasks;
using System.Web.Mvc;
using DancingGoat.Models.ViewModels;
using KenticoCloud.Personalization.MVC;

namespace DancingGoat.Controllers
{
    public class ImpersonationController : ControllerBase
    {
        // GET: Impersonation
        public async Task<ActionResult> Index()
        {
            var segmentsResponse = await personalizationClient.GetVisitorSegmentsAsync(Request.GetCurrentPersonalizationUid());
            return View("Index", new ImpersonationViewModel { Segments = segmentsResponse.Segments });
        }

        public ActionResult Impersonate(string email)
        {
            return RedirectToAction("Index");
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using KenticoCloud.Delivery;

namespace DancingGoat.Models.ViewModels
{
    public class FindCafesViewModel
    {
        public CallToAction CallToAction { get; set; }
        public IEnumerable<Cafe> HandpickedCafes { get; set; }

        public FindCafesViewModel(CallToAction callToAction, IEnumerable<Cafe> handpickedCafes)
        {
            CallToAction = callToAction;
            HandpickedCafes = handpickedCafes;
        }

        public static FindCafesViewModel GetCafesForPersona(SelectedCafes dataModel, string persona)
        {
            var cta = dataModel.CallToActions?.FirstOrDefault() as CallToAction;
            var cafes = dataModel.HandpickedCafes.Cast<Cafe>();

            return new FindCafesViewModel(cta, cafes);
        }

        public static List<IQueryParameter> GetQueryParameters()
        {
            return new List<IQueryParameter>
            {
                new EqualsFilter("system.type", SelectedCafes.Codename),
                new DepthParameter(1),
            };
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using DancingGoat.Helpers;
using KenticoCloud.Delivery;
using KenticoCloud.Personalization;

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

        public static FindCafesViewModel GetCafesForPersona(SelectedCafes dataModel, Segment[] visitorSegments)
        {
            // Personalize call to action
            var callToActions = dataModel.CallToActions.Cast<CallToAction>().ToList();
            var callToAction = PersonalizationHelper.GetPersonalizedCallToAction(visitorSegments, callToActions);

            var cta = callToAction ?? callToActions.FirstOrDefault();
            var cafes = dataModel.HandpickedCafes.Cast<Cafe>();

            return new FindCafesViewModel(cta, cafes);
        }

        public static List<IQueryParameter> GetQueryParameters()
        {
            return new List<IQueryParameter>
            {
                new EqualsFilter("system.type", SelectedCafes.Codename),                
            };
        }
    }
}
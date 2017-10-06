using System;
using System.Collections.Generic;
using System.Linq;
using DancingGoat.Models;
using KenticoCloud.Personalization;

namespace DancingGoat.Helpers
{
    public class PersonalizationHelper
    {
        public const string CafeOwnerSegmentName = "Cafe owners";
        public const string CafeOwnerPersonaCodename = "cafe_owner_15bb692";
        public const string CoffeeEnthusiastSegmentName = "Coffee enthusiasts";
        public const string CoffeeEnthusiastPersonaCodename = "coffee_enthusiast";

        public static CallToAction GetPersonalizedCallToAction(Segment[] visitorSegments,
            IEnumerable<CallToAction> callToActions)
        {
            // Prioritize enthusiast
            if (ContainsSegment(visitorSegments, CoffeeEnthusiastSegmentName))
            {
                return GetCtaByTaxonomy(callToActions, CoffeeEnthusiastPersonaCodename);
            }

            if (ContainsSegment(visitorSegments, CafeOwnerSegmentName))
            {
                return GetCtaByTaxonomy(callToActions, CafeOwnerPersonaCodename);
            }

            // For unknown persona, pick enthusiast
            return GetCtaByTaxonomy(callToActions, CoffeeEnthusiastPersonaCodename);
        }

        public static bool ContainsSegment(IEnumerable<Segment> segments, string segmentName)
        {
            return segments.Any(x => string.Equals(x.Name, segmentName, StringComparison.InvariantCultureIgnoreCase));
        }

        public static CallToAction GetCtaByTaxonomy(IEnumerable<CallToAction> callToAction, string personaTaxonomyTermCodename)
        {
            return callToAction.FirstOrDefault(cta => cta.Persona.Any(term => string.Equals(term.Codename,
                personaTaxonomyTermCodename, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
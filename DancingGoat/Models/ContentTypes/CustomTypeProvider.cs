using System;
using KenticoCloud.Delivery;

namespace DancingGoat.Models
{
    public class CustomTypeProvider : ICodeFirstTypeProvider
    {
        public Type GetType(string contentType)
        {
            switch (contentType)
            {
                case "about_us":
                    return typeof(AboutUs);
                case "article":
                    return typeof(Article);
                case "cafe":
                    return typeof(Cafe);
                case "call_to_action":
                    return typeof(CallToAction);
                case "coffee":
                    return typeof(Coffee);
                case "fact_about_us":
                    return typeof(FactAboutUs);
                case "hero_unit":
                    return typeof(HeroUnit);
                case "home":
                    return typeof(Home);
                case "hosted_video":
                    return typeof(HostedVideo);
                case "navigation":
                    return typeof(Navigation);
                case "navigation_item":
                    return typeof(NavigationItem);
                case "office":
                    return typeof(Office);
                case "partnership_benefits":
                    return typeof(PartnershipBenefits);
                case "planned_facebook_post":
                    return typeof(PlannedFacebookPost);
                case "planned_tweet":
                    return typeof(PlannedTweet);
                case "selected_cafes":
                    return typeof(SelectedCafes);
                case "tweet":
                    return typeof(Tweet);
                default:
                    return null;
            }
        }
    }
}
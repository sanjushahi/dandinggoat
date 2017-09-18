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
                case "accessory":
                    return typeof(Accessory);
                case "article":
                    return typeof(Article);
                case "brewer":
                    return typeof(Brewer);
                case "cafe":
                    return typeof(Cafe);
                case "coffee":
                    return typeof(Coffee);
                case "fact_about_us":
                    return typeof(FactAboutUs);
                case "grinder":
                    return typeof(Grinder);
                case "hero_unit":
                    return typeof(HeroUnit);
                case "home":
                    return typeof(Home);
                case "office":
                    return typeof(Office);
                case "hosted_video":
                    return typeof(HostedVideo);
                case "tweet":
                    return typeof(Tweet);
                case "call_to_action":
                    return typeof(CallToAction);
                case "partnership_benefits":
                    return typeof(PartnershipBenefits);
                case "planned_facebook_post":
                    return typeof(PlannedFacebookPost);
                case "planned_tweet":
                    return typeof(PlannedTweet);
                case "navigation":
                    return typeof(Navigation);
                case "navigation_item":
                    return typeof(NavigationItem);
                default:
                    return null;
            }
        }
    }
}
using System.Linq;
using DancingGoat.Helpers;
using KenticoCloud.Delivery;
using KenticoCloud.Personalization;

namespace DancingGoat.Models.ViewModels
{
    public class CoffeeDetailViewModel
    {
        public string CoffeeName { get; set; }
        public string UrlLabel { get; set; }
        public Asset Photo { get; set; }
        public IRichTextContent LongDescription { get; set; }
        public CallToAction CallToAction { get; set; }
        public string Farm { get; set; }
        public string Country { get; set; }
        public string Variety { get; set; }
        public MultipleChoiceOption Processing { get; set; }
        public string Altitude { get; set; }
        public decimal? Price { get; set; }

        public CoffeeDetailViewModel(string coffeeName, string urlLabel, Asset photo, IRichTextContent longDescription, CallToAction callToAction, string farm, string country, string variety, MultipleChoiceOption processing, string altitude, decimal? price)
        {
            CoffeeName = coffeeName;
            UrlLabel = urlLabel;
            Photo = photo;
            LongDescription = longDescription;
            CallToAction = callToAction;
            Farm = farm;
            Country = country;
            Variety = variety;
            Processing = processing;
            Altitude = altitude;
            Price = price;
        }

        public static CoffeeDetailViewModel GetCoffeeDetailForPersona(Coffee coffee, Segment[] visitorSegments)
        {
            var photo = coffee.Photo.FirstOrDefault();

            // Personalize call to action
            var callToActions = coffee.CallToActions.Cast<CallToAction>().ToList();
            var callToAction = PersonalizationHelper.GetPersonalizedCallToAction(visitorSegments, callToActions); 

            var processing = coffee.Processing.FirstOrDefault();

            return new CoffeeDetailViewModel(coffee.CoffeeName,
                coffee.UrlLabel,
                photo,
                coffee.LongDescription,
                callToAction ?? callToActions.FirstOrDefault(),
                coffee.Farm,
                coffee.Country,
                coffee.Variety,
                processing,
                coffee.Altitude,
                coffee.Price);
        }
    }
}
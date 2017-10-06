using System.Collections.Generic;
using System.Linq;
using KenticoCloud.Delivery;

namespace DancingGoat.Models.ViewModels
{
    public class CoffeeThumbnailViewModel
    {
        public string CoffeeName { get; private set; }
        public string UrlLabel { get; private set; }
        public IEnumerable<Asset> Photo { get; private set; }
        public MultipleChoiceOption Promotion { get; private set; }
        public string CoffeeCategory { get; private set; }
        public string ShortDescription { get; private set; }
        public string ProcessingTechnique { get; private set; }
        public decimal? Price { get; private set; }

        public CoffeeThumbnailViewModel(string coffeeName, string urlLabel, IEnumerable<Asset> photo, MultipleChoiceOption promotion, string coffeeCategory, string shortDescription, string processingTechnique, decimal? price)
        {
            CoffeeName = coffeeName;
            UrlLabel = urlLabel;
            Photo = photo;
            Promotion = promotion;
            CoffeeCategory = coffeeCategory;
            ShortDescription = shortDescription;
            ProcessingTechnique = processingTechnique;
            Price = price;
        }

        public static CoffeeThumbnailViewModel ConvertFromCoffee(Coffee dataModel)
        {
            return new CoffeeThumbnailViewModel(dataModel.CoffeeName,
                dataModel.UrlLabel,
                dataModel.Photo,
                dataModel.Promotion.FirstOrDefault(),
                dataModel.CoffeeCategory.FirstOrDefault()?.Codename,
                dataModel.ShortDescription,
                dataModel.Processing.FirstOrDefault()?.Name,
                dataModel.Price);
        }

        public static ElementsParameter GetProjectionQueryParameter()
        {
            return new ElementsParameter(
                Coffee.CoffeeNameCodename,
                Coffee.UrlLabelCodename,
                Coffee.PhotoCodename,
                Coffee.PromotionCodename,
                Coffee.CoffeeCategoryCodename,
                Coffee.ShortDescriptionCodename,
                Coffee.ProcessingCodename,
                Coffee.PriceCodename);
        }
    }
}
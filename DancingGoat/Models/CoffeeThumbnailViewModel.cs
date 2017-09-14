using System.Collections.Generic;
using System.Linq;
using KenticoCloud.Delivery;

namespace DancingGoat.Models
{
        public  class CoffeeThumbnailViewModel
        {
            public string CoffeeName { get; private set; }
            public string UrlLabel { get; private set; }
            public IEnumerable<Asset> Photo { get; private set; }            
            public MultipleChoiceOption Promotion { get; private set; }
            public string ShortDescription { get; private set; }            
            public string ProcessingTechnique { get; private set; }
            public decimal? Price { get; private set; }

            public CoffeeThumbnailViewModel(Coffee dataModel)
            {
                CoffeeName = dataModel.CoffeeName;
                UrlLabel = dataModel.UrlLabel;
                Photo = dataModel.Photo;
                Promotion = dataModel.Promotion.FirstOrDefault();
                ShortDescription = dataModel.ShortDescription;
                ProcessingTechnique = dataModel.Processing.FirstOrDefault()?.Name;
                Price = dataModel.Price;
            }

            public static ElementsParameter GetProjectionQueryParameter()
            {
                return new ElementsParameter(
                    Coffee.CoffeeNameCodename, 
                    Coffee.UrlLabelCodename, 
                    Coffee.PhotoCodename, 
                    Coffee.PromotionCodename, 
                    Coffee.ShortDescriptionCodename,
                    Coffee.ProcessingCodename,
                    Coffee.PriceCodename);
            }
    }
}
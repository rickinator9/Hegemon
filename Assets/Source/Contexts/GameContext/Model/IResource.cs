using Assets.Source.Contexts.GameContext.Context;
using Assets.Source.Core.Model;
using Assets.Source.Core.Model.Identifiable;
using Assets.Source.Core.Parser.DataParser.Attributes;
using Assets.Source.Core.Parser.DataParser.Properties;
using strange.extensions.injector.api;

namespace Assets.Source.Contexts.GameContext.Model
{
    public interface IResource : IIdentifiable
    {
        string ResourceName { get; }
        
        float BasePrice { get; set; }

        float Price { get; }

        float Supply { get; }
        
        float Demand { get; }

        void UpdateForDayEnd();

        void AddSupply(float supply);

        void AddDemand(float demand);

        void SetData(string resourceName, float basePrice);
    }

    public class ResourceProperty : BaseDataParserProperty<IResource>
    {
        [DefaultValue(1.0f)]
        private float base_price { get; set; }

        public void PopulateModel(ref IResource model)
        {
            model.Identifier = _id;
            model.BasePrice = base_price;
        }

        public override IResource PopulateModel(IInjectionBinder injectionBinder)
        {
            var resource = injectionBinder.GetInstance<IResource>(GameContextKeys.NewInstance);

            resource.Identifier = _id;
            resource.BasePrice = base_price;

            return resource;
        }
    }
}
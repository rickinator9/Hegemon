using Assets.Source.Contexts.GameContext.Model.Managers;

namespace Assets.Source.Contexts.GameContext.Model.Impl
{
    public class Resource : IResource
    {
        public string ResourceName { get; private set; }
        public float BasePrice { get; set; }

        public float Price { get; private set; }

        public float Supply { get; private set; }
        public float Demand { get; private set; }
        public void UpdateForDayEnd()
        {
            Price = BasePrice*Demand/Supply;
        }

        public void AddSupply(float supply)
        {
            Supply += supply;
        }

        public void AddDemand(float demand)
        {
            Demand += demand;
        }

        public void SetData(string resourceName, float basePrice)
        {
            ResourceName = resourceName;
            BasePrice = basePrice;
        }

        private string _id;

        public string Identifier
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(_id))
                    _id = value;
            }
        }
    }

    public class ResourceManager : IdentifiableManager<IResource>
    {
    }
}
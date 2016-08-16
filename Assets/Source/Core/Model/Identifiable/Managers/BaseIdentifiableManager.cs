namespace Assets.Source.Core.Model.Identifiable.Managers
{
    public abstract class BaseIdentifiableManager<T> where T : IIdentifiable
    {
        public abstract T[] ToArray { get; }

        public abstract int Count { get; }

        public T this[string identifier]
        {
            get { return Get(identifier); }
            set { Set(value); }
        }

        public abstract void Set(T element);
        public abstract T Get(string identifier);
    }
}
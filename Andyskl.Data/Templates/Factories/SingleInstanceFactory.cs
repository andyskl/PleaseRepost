namespace Andyskl.Data.Templates.Factories
{
    public abstract class SingleInstanceFactory<T> : IFactory<T>
    {
        private static T _instance; 
        private T Instance
        {
            get
            {
                return ((object)_instance) == null ?
                    (_instance = Instantiate()) :
                    _instance;
            }
        }
        public T Get()
        {
            return Instance;
        }
        protected abstract T Instantiate();
                                                
    }
}

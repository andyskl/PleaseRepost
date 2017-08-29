namespace Andyskl.Data.Templates.Factories
{
    public interface IFactory<out T>
    {
        T Get();
    }  

}

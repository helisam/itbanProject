namespace Domain.Interfaces.Factories
{
    public interface IFactory<TInterface> where TInterface : class
    {
        TInterface Criar();
    }
}

namespace DroneBase.Interfaces
{
    public interface IAbilityDescription : IDescription
    {
        int QuantityOfCarring { get; }
        IAbilityModel Model { get; }
        IAbility GetAbility();
    }
}
using DroneBase.Interfaces;

namespace DroneBase.Models
{
    public class AbilityModel : IAbilityModel
    {
        public int AmountOfCarring { get; }

        public AbilityModel(IAbilityDescription description)
        {
            AmountOfCarring = description.QuantityOfCarring;
        }
    }
}
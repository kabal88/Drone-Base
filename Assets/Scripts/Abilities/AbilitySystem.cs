using System.Collections.Generic;
using DroneBase.Enums;
using DroneBase.Interfaces;
using DroneBase.Libraries;

namespace DroneBase.Abilities
{
    public class AbilitySystem : IAbilitiesSystem
    {
        private Dictionary<DroneAbility, IAbility> _abilities;

        private AbilitySystem(Dictionary<DroneAbility, IAbility> abilities)
        {
            _abilities = abilities;
        }

        public static AbilitySystem CreateAbilitiesSystem(Dictionary<DroneAbility, int> availableAbilitiesMap,
            Dictionary<int, IAbilityDescription> descriptions)
        {
            var abilities = new Dictionary<DroneAbility, IAbility>();

            foreach (var key in availableAbilitiesMap.Keys)
            {
                if (descriptions.TryGetValue(availableAbilitiesMap[key], out var description))
                {
                    abilities.Add(key, description.GetAbility());
                }
            }

            var system = new AbilitySystem(abilities);

            return system;
        }

        public void ExecuteAbility(ISelect owner, DroneAbility index, ITarget target)
        {
            if (_abilities.TryGetValue(index, out var ability))
            {
                ability.Execute(owner, target);
            }
        }
    }
}
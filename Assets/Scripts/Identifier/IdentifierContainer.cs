using DroneBase.Interfaces;
using UnityEngine;

namespace DroneBase.Identifier
{
    [CreateAssetMenu]
    public sealed class IdentifierContainer : ScriptableObject, IIdentifier
    {
        [SerializeField, HideInInspector] private int ID;
    
        public int Id
        {
            get
            {
                if (ID == 0)
                    ID = Animator.StringToHash(name); //можно заменить на любой другой генератор ID

                return ID;
            }
        }
    }
}
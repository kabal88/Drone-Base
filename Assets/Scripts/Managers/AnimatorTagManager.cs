using UnityEngine;

namespace DroneBase.Managers
{
    public static class AnimatorTagManager
    {
        public static readonly int IsOpen = Animator.StringToHash("IsOpen");
        public static readonly int Speed = Animator.StringToHash("Speed");
        public static readonly int Acceleration = Animator.StringToHash("Acceleration");
    }
}
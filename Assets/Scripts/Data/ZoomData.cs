using System;

namespace DroneBase.Data
{
    [Serializable]
    public struct ZoomData
    {
        public float ZoomInLimit;
        public float ZoomOutLimit;
        public float ZoomSpeed;
    }
}
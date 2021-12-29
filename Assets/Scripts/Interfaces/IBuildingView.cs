using DroneBase.Enums;

namespace DroneBase.Interfaces
{
    public interface IBuildingView<T,TM> : IView, ITargetable, ISelectionView where T: IBuildingController where TM : IBuildingModel
    {
        void Init(T controller,TM model);
    }
}
namespace DroneBase.Interfaces
{
    public interface IBuildingView<TController,TModel> : IView, ITargetable, ISelectionView
        where TController: IBuildingController
        where TModel : IBuildingModel
    {
        void Init(TController controller,TModel model);
    }
}
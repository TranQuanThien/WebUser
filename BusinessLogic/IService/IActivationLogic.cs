using BusinessLogic.ViewModels;

namespace BusinessLogic.IService
{
    public interface IActivationLogic
    {
        Response CreateActivation(ActivationViewModel data);
        List<ActivationViewModel> GetAllActivation();
        Response DeleteActivation(ActivationViewModel data);
        List<SerinoViewModel> GetInfoActivationBySerino(string data);
    }
}

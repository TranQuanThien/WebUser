using WebSerino.Data;

namespace DataRepository.IServiceRepo
{
    public interface ISerinoRepoService
    {
        List<Activation> GetAllActivation();
        bool DeleteActivation(Activation data);
        bool CreateActivation(Activation data);
        List<Activation> GetActivationBySerino(string serino);
    }
}

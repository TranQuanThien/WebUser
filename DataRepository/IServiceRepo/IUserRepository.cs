using WebSerino.Data;

namespace DataRepository.IServiceRepo
{
    public interface IUserRepository
    {
        List<UserTemp> GetAllUser();
        Manager GetManagerById(int? id);
        bool ImportListUser(List<UserTemp> user1s);
        int GetManagerIdByName(string name);
    }
}

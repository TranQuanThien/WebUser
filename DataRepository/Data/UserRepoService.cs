using DataRepository.IServiceRepo;
using WebSerino.Data;

namespace DataRepository.Data
{
    public class UserRepoService : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepoService(DataContext context)
        {
            _context = context;
        }

        public List<UserTemp> GetAllUser()
        {
            var response = _context.UserTemps.ToList();
            return response;
        }

        public Manager GetManagerById(int? id)
        {
            var response = _context.Managers.FirstOrDefault(x => x.Id == id);
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public bool ImportListUser(List<UserTemp> user1s)
        {
            try
            {
                foreach (var item in user1s)
                {
                    _context.UserTemps.Add(item);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetManagerIdByName(string name)
        {
            try
            {
                var response = _context.Managers.FirstOrDefault(x => x.Name == name);
                if (response == null)
                {
                    Manager manager = new Manager();
                    manager.Name = name;
                    _context.Managers.Add(manager);
                    _context.SaveChanges();

                    var data = _context.Managers.FirstOrDefault(x => x.Name == name);
                    return data.Id;
                }
                else
                {
                    return response.Id;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

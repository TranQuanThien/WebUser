using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.ViewModels;
using DataRepository.IServiceRepo;
using WebSerino.Data;

namespace BusinessLogic.Business
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private List<UserViewModel> userViewModels = new List<UserViewModel>();
        private List<UserViewModel> userViewModelsTemp = new List<UserViewModel>();
        public UserLogic(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserViewModel> GetAllUser()
        {
            try
            {
                List<UserViewModel> userViewModels = new List<UserViewModel>();
                var response = _userRepository.GetAllUser();
                foreach (var item in response)
                {
                    UserViewModel userViewModel = new UserViewModel();
                    var data = _userRepository.GetManagerById(item.ManagerId);
                    userViewModel.Id = item.Id;
                    userViewModel.Name = item.Name;
                    userViewModel.Dob = item.Dob == null ? DateTime.Now : item.Dob;
                    userViewModel.MangerId = item.ManagerId;
                    userViewModel.Manager = data == null ? "" : data.Name;
                    userViewModels.Add(userViewModel);
                }
                return userViewModels;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<UserViewModel> GetUserTemp()
        {
            try
            {
                return userViewModelsTemp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddUserTemp(UserViewModel userViewModel)
        {
            try
            {
                foreach (var item in userViewModelsTemp)
                {
                    if (item.Name == userViewModel.Name)
                    {
                        return false;
                    }
                }
                UserViewModel user = new UserViewModel();
                user.Id = userViewModel.Id;
                user.Name = userViewModel.Name;
                user.Manager = userViewModel.Manager;
                user.Dob = userViewModel.Dob;
                userViewModelsTemp.Add(user);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ImportListUser()
        {
            if (userViewModelsTemp.Count() <= 10)
            {
                return false;
            }
            else
            {
                List<UserTemp> user = new List<UserTemp>();
                foreach (var item in userViewModelsTemp)
                {
                    UserTemp user1 = new UserTemp();
                    user1.Name = item.Name;
                    user1.Dob = item.Dob;
                    user1.ManagerId = _userRepository.GetManagerIdByName(item.Manager);
                    user.Add(user1);
                }
                var response = _userRepository.ImportListUser(user);
                if (response)
                {
                    userViewModelsTemp.Clear();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteUserTemp(string name) 
        {
            var user = userViewModelsTemp.FirstOrDefault(x => x.Name == name);
            userViewModelsTemp.Remove(user);
            return true;
        }

    }
}

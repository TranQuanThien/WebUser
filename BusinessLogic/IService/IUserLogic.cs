using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface IUserLogic
    {
        List<UserViewModel> GetAllUser();
        List<UserViewModel> GetUserTemp();
        bool AddUserTemp(UserViewModel userViewModel);
        bool ImportListUser();
    }
}

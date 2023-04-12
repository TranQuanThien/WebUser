using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string? Name { get; set; }

        public DateTime? Dob { get; set; }

        public int? MangerId { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Manager { get; set; }
    }
}

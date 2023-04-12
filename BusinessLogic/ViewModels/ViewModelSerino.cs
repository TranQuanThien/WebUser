using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class ViewModelSerino
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; } = null!;
        public DateTime? DateAdded { get; set; }
        public string DeviceType { get; set; } = null!;
        public bool Disabled { get; set; }
        public DateTime? DateModified { get; set; }
    }
}

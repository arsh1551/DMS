using CoreEntites.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IFirmService
    {
        FirmViewModel GetFirm(long FirmId);
        List<FirmViewModel> GetFirmList();
        bool UpdateFirm(FirmViewModel model);
        bool AddFirm(FirmViewModel model);
        bool DeleteFirm(int FirmId);
    }
}

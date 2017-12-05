using CoreEntites.SubDomain;
using CoreEntites.Domain;
using CoreEntites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IFirmRepository
    {

        Firm GetFirm(long ClientId);
        List<Firm> GetFirmList();
        bool UpdateFirm(FirmViewModel model);
        bool AddFirm(FirmViewModel model);

        bool DeleteFirm(long FirmId);
    }
}

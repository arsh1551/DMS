using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IIndividualRepository
    {
        #region For Individual User
        IndividualRegistrationViewModel GetIndividualClientDetail(long? UserID);
        bool UpdateIndividualClient(IndividualRegistrationViewModel IndividualRegistrationViewModel);
        bool IsSSNExistsForIndividualClient(string SSN, long? IndividualRecordId);
        #endregion

    }
}

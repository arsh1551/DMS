using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IIndividualService
    {
        #region For Individual User
        IndividualRegistrationViewModel GetIndividualClientDetail(long? UserID);
        bool UpdateIndividualClient(IndividualRegistrationViewModel IndividualRegistrationViewModel);
        bool IsSSNExistsForIndividualClient(string SSN, long? IndividualRecordId);
        #endregion
    }
}

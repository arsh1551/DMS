using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class IndividualService : IIndividualService
    {
        IIndividualRepository _IIndividualRepository = null;
        public IndividualService(IIndividualRepository IIndividualRepository)
        {
            this._IIndividualRepository = IIndividualRepository;
        }
        #region MyRegion
        public IndividualRegistrationViewModel GetIndividualClientDetail(long? UserID)
        {
            return _IIndividualRepository.GetIndividualClientDetail(UserID);
        }
        public bool UpdateIndividualClient(IndividualRegistrationViewModel IndividualRegistrationViewModel)
        {
            return _IIndividualRepository.UpdateIndividualClient(IndividualRegistrationViewModel);
        }
        public bool IsSSNExistsForIndividualClient(string SSN, long? IndividualRecordId)
        {
            return _IIndividualRepository.IsSSNExistsForIndividualClient(SSN,IndividualRecordId);
        }
        #endregion
    }
}

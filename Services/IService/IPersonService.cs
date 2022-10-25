using System.Collections.Generic;
using sampleApp.Models;

namespace sampleApp.Services.IService
{
    public interface IPersonService
    {
        void AddPerson(PersonViewModel person);
        List<PersonViewModel> GetPersonList();
    }
}
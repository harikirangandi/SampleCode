using Newtonsoft.Json;
using sampleApp.Models;
using sampleApp.Services.IService;

namespace sampleApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly IFileHelper _fileHelper;
        public PersonService(IFileHelper helper)
        {
            _fileHelper = helper;
        }
        public void AddPerson(PersonViewModel person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var persons = GetPersonList();
            if (persons == null)
                persons = new List<PersonViewModel>();

            persons.Add(person);
            _fileHelper.WriteFile(JsonConvert.SerializeObject(persons));
        }

        public List<PersonViewModel> GetPersonList()
        {
            var result = _fileHelper.ReadFile<PersonViewModel>();
            return result;
        }
    }
}
using Raja.Application.Contract.Dto;
using Raja.Application.Contract.IServices;
using Raja.Infrastracture;

namespace Raja.Application.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly IPersonelRepository personelRepository;

        public PersonelService(IPersonelRepository personelRepository)
        {
            this.personelRepository = personelRepository;
        }

        public async Task<int> Add(PersonelDto personel)
        {
            return await personelRepository.Add(personel);
        }

        public  async Task Edit(PersonelDto personel, CancellationToken ct)
        {
            await personelRepository.Edit(personel, ct);
        }

        public async Task<PersonelDto> Get(int id, CancellationToken ct)
        {
            var personel = await personelRepository.Get(id, ct);
            

            return personel;
        }

        public async Task<List<PersonelDto>> GetAll(CancellationToken ct)
           => await personelRepository.GetAll(ct);

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}

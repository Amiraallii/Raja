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

        public async Task<int> AddPersoneDetail(PersonelDetailDto personelDetail)
        {
            return await personelRepository.AddPersoneDetail(personelDetail);
        }

        public  async Task Edit(PersonelDto personelDetail, CancellationToken ct)
        {
            await personelRepository.Edit(personelDetail, ct);
        }

        public async Task EditPersonelDetail(PersonelDetailDto personelDetail, CancellationToken ct)
        {
            await personelRepository.EditPersonelDetail(personelDetail, ct);
        }

        public async Task<PersonelDto> Get(int id, CancellationToken ct)
        {
            var personel = await personelRepository.Get(id, ct);
            

            return personel;
        }

        public async Task<List<PersonelDto>> GetAll(CancellationToken ct)
           => await personelRepository.GetAll(ct);

        public async Task Remove(int id)
            => await personelRepository.Remove(id);

        public async Task RemoveMobileNumber(int id)
            => await personelRepository.RemoveMobileNumber(id);

        
    }
}

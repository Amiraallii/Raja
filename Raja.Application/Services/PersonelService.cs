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

        public async Task<List<PersonelDto>> GetAll(CancellationToken ct)
           => await personelRepository.GetAll(ct);
    }
}

using Raja.Application.Contract.Dto;

namespace Raja.Application.Contract.IServices
{
    public interface IPersonelService
    {
        Task<List<PersonelDto>> GetAll(CancellationToken ct);
        Task<PersonelDto> Get(int id, CancellationToken ct);
        Task<int> Add(PersonelDto translator);
        Task Edit(PersonelDto personel, CancellationToken ct);
        Task Save(CancellationToken ct = default);
        Task Remove(int id);
    }
}

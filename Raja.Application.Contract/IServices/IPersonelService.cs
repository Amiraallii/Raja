using Raja.Application.Contract.Dto;

namespace Raja.Application.Contract.IServices
{
    public interface IPersonelService
    {
        Task<List<PersonelDto>> GetAll(CancellationToken ct);
    }
}

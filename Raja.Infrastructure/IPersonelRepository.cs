using Raja.Application.Contract.Dto;

namespace Raja.Infrastracture
{
    public interface IPersonelRepository
    {
        Task<List<PersonelDto>> GetAll(CancellationToken ct);
    }
}

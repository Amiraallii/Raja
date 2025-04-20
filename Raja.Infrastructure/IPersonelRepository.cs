using Raja.Application.Contract.Dto;

namespace Raja.Infrastracture
{
    public interface IPersonelRepository
    {
        Task<List<PersonelDto>> GetAll(CancellationToken ct);
        Task<PersonelDto> Get(int id, CancellationToken ct);
        Task<int> Add(PersonelDto translator);
        Task<int> AddPersoneDetail(PersonelDetailDto personelDetail);
        Task Edit(PersonelDto personel, CancellationToken ct);
        Task EditPersonelDetail(PersonelDetailDto personel, CancellationToken ct);
        Task Remove(int id);
        Task RemoveMobileNumber(int id);



    }
}

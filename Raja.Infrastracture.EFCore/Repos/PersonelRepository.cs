using Microsoft.EntityFrameworkCore;
using Raja.Application.Contract.Dto;
using Raja.Infrastracture.EFCore.Context;

namespace Raja.Infrastracture.EFCore.Repos
{
    public class PersonelRepository : IPersonelRepository
    {
        private readonly RajaPersonelContext context;

        public PersonelRepository(RajaPersonelContext context)
        {
            this.context = context;
        }

        public async Task<List<PersonelDto>> GetAll(CancellationToken ct)
        {
            var personels = await context.Personels.Include(x=> x.PersonelDetail).Select(x=> new PersonelDto
            {
                LastName = x.LastName,
                Name = x.Name,
                MobileNumbers = x.PersonelDetail.Select(x=> new PersonelDetailDto
                {
                    Id = x.Id,
                    MobileNumber = x.MobileNumber,
                }).ToList(),
                PersonelId = x.Id,
            }).ToListAsync(ct);
            if (!personels.Any())
            {
                throw new Exception("هیج کاربری برلی نمایش وجود ندارد");
            }
            else
            {
                return personels;
            }
        }
    }
}

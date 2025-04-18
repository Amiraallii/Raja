using Microsoft.EntityFrameworkCore;
using Raja.Application.Contract.Dto;
using Raja.Domain.Entities;
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

        public async Task<int> Add(PersonelDto personel)
        {
            var model = new Personel(personel.Name, personel.LastName);
            context.Personels.Add(model);
            await Save();
            return model.Id;
        }

        public async Task Edit(PersonelDto personel, CancellationToken ct)
        {
            var model = await context.Personels.Where(x=> x.Id == personel.PersonelId).FirstOrDefaultAsync(ct);
            model.Edit(personel.Name, personel.LastName);
            await Save();
        }

        public async Task<PersonelDto> Get(int id, CancellationToken ct)
        {
            return await
            context.Personels.Where(x=> x.Id == id).Select(x => new PersonelDto
            {
                PersonelId = id,
                Name = x.Name,
                LastName = x.LastName,
            })
            .FirstOrDefaultAsync(ct);
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

        public async Task Remove(int id)
        {
            var model = await GetPersonel(id);
            model.Remove();
            await Save();

        }

        public async Task Save(CancellationToken ct = default) => await context.SaveChangesAsync(ct);
        private async Task<Personel> GetPersonel(int id) => await context.Personels.FindAsync(id);

    }
}

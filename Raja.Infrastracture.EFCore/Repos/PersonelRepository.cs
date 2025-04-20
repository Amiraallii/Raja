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
            List<PersonelDetail> personelDetailModel = new List<PersonelDetail>();
            foreach (var item in personel.MobileNumbers)
            {
                PersonelDetail PDModel = new PersonelDetail(model.Id, item.MobileNumber);
                personelDetailModel.Add(PDModel);

            }
            context.PersonelsDetails.AddRange(personelDetailModel);
            await Save();
            return model.Id;
        }
        public async Task<int> AddPersoneDetail(PersonelDetailDto personelDetail)
        {
            var model = new PersonelDetail(personelDetail.PersosnelId, personelDetail.MobileNumber);
            context.PersonelsDetails.Add(model);
            await Save();
            return model.Id;
        }

        public async Task Edit(PersonelDto personel, CancellationToken ct)
        {
            var model = await context.Personels.Where(x => x.Id == personel.PersonelId).FirstOrDefaultAsync(ct);
            model.Edit(personel.Name, personel.LastName);
            foreach(var pd in personel.MobileNumbers)
            {
                if (pd.Id != 0)
                {
                    var pdmodel = await context.PersonelsDetails.Where(p => p.Id == pd.Id).FirstOrDefaultAsync(ct);
                    pdmodel.Edit(pd.MobileNumber);
                }
                else
                {
                    await AddPersoneDetail(new PersonelDetailDto { PersosnelId = personel.PersonelId, MobileNumber = pd.MobileNumber });
                }
            }
            await Save();
        }

        public async Task EditPersonelDetail(PersonelDetailDto personel, CancellationToken ct)
        {
            var model = await context.PersonelsDetails.Where(x => x.Id == personel.Id).FirstOrDefaultAsync(ct);
            model.Edit(personel.MobileNumber);
            await Save();
        }

        public async Task<PersonelDto> Get(int id, CancellationToken ct)
        {
            return await
            context.Personels.Include(x=>x.PersonelDetail).Where(x => x.Id == id).Select(x => new PersonelDto
            {
                PersonelId = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                MobileNumbers = x.PersonelDetail.Where(d => !d.IsDelete).Select(x => new PersonelDetailDto
                {
                    Id = x.Id,
                    PersosnelId = x.PersonelId,
                    MobileNumber = x.MobileNumber,
                }).ToList(),
            })
            .FirstOrDefaultAsync(ct);
        }


        public async Task<List<PersonelDto>> GetAll(CancellationToken ct)
        {
            var personels = await context.Personels.Include(x => x.PersonelDetail).Where(x=> !x.IsDelete).Select(x => new PersonelDto
            {
                LastName = x.LastName,
                Name = x.Name,
                MobileNumbers = x.PersonelDetail.Where(d => !d.IsDelete).Select(x => new PersonelDetailDto
                {
                    Id = x.Id,
                    MobileNumber = x.MobileNumber,
                }).ToList(),
                PersonelId = x.Id,
            }).ToListAsync(ct);


            return personels;

        }

        public async Task Remove(int id)
        {
            var model = await GetPersonel(id);
            var pDList = await GetPersonelMobileByPersonel(id);
            model.Remove();
            foreach (var p in pDList)
            {
                await RemoveMobileNumber(p.Id);
            }
            await Save();

        }

        public async Task RemoveMobileNumber(int id)
        {
            var model = await GetPersonelMobile(id);
            model.Remove();
            await Save();

        }

        public async Task Save(CancellationToken ct = default) => await context.SaveChangesAsync(ct);
        private async Task<Personel> GetPersonel(int id) => await context.Personels.FindAsync(id);
        private async Task<PersonelDetail> GetPersonelMobile(int id) => await context.PersonelsDetails.FindAsync(id);
        private async Task<List<PersonelDetail>> GetPersonelMobileByPersonel(int id) => await context.PersonelsDetails.Where(x=> x.PersonelId == id).ToListAsync();

    }
}

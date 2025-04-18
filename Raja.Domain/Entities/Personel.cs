namespace Raja.Domain.Entities
{
    public class Personel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }

        public ICollection<PersonelDetail> PersonelDetail { get; private set; }
    }
}

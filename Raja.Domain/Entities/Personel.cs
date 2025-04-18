namespace Raja.Domain.Entities
{
    public class Personel
    {
        private Personel()
        {

        } 
        public Personel(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            IsDelete = false;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public bool IsDelete { get; set; }

        public ICollection<PersonelDetail> PersonelDetail { get; private set; }

        public void Edit(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        public void Remove()
        {
            IsDelete = true;
        }
    }
}

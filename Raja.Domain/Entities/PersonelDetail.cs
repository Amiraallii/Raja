namespace Raja.Domain.Entities
{
    public class PersonelDetail
    {
        #region ' Ctor '
        private PersonelDetail() 
        {

        }
        public PersonelDetail(int personelId, string mobileNumber)
        {
            PersonelId = personelId;
            MobileNumber = mobileNumber;
        }
        #endregion ' Ctor '
        public int Id { get; set; }
        public int PersonelId { get; private set; }
        public string MobileNumber { get; private set; }

        public Personel Personel { get; private set; }
    }
}

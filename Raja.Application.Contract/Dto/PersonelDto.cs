namespace Raja.Application.Contract.Dto
{
    public class PersonelDto
    {
        public int PersonelId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<PersonelDetailDto> MobileNumbers { get; set; }
    }
}

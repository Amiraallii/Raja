using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Raja.Application.Contract.Dto
{
    public class PersonelDto
    {
        [Range(0, int.MaxValue)]
        public int PersonelId { get; set; }
        [DisplayName("نام")]
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [MaxLength(256, ErrorMessage = "حداکثر تعداد کاراکتر 256 عدد")]
        public string Name { get; set; }
        [DisplayName("نام حانوادگی")]
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [MaxLength(256, ErrorMessage = "حداکثر تعداد کاراکتر 256 عدد")]
        public string LastName { get; set; }
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [MaxLength(256, ErrorMessage = "حداکثر تعداد کاراکتر 256 عدد")]
        public List<PersonelDetailDto> MobileNumbers { get; set; }
    }
}

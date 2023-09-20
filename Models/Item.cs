namespace Anbar.Models
{
    public class Item
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="وارد کردن نام محصول الزامی است")]
        [System.ComponentModel.DataAnnotations.MaxLength(20, ErrorMessage = "شما مجاز به وارد کردن نامی با بیشتر از بیست کرکتر نیستید)]")]
        [System.ComponentModel.DataAnnotations.MinLength(2,ErrorMessage ="شما مجاز به وارد کردن نامی با کمتر از دو کرکتر نیستید")]
        [System.ComponentModel.DataAnnotations.Display(Name ="نام محصول")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن قیمت محصول الزامی است")]
        [System.ComponentModel.DataAnnotations.Display(Name = "قیمت محصول")]
        public string Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "وارد کردن توضیحات الزامی است")]
        public string Description { get; set; }
    }
}

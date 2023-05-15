using PustokTemplate.Models;

namespace PustokTemplate.ViewModels
{
    public class HomeViewModel
    {
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set;}
        public List<Book> DiscountedBooks { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Feature> Features { get; set; }

    }
}

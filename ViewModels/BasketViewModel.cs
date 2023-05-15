namespace PustokTemplate.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItemViewModel> BasketItems { get; set; } = new List<BasketItemViewModel>();
        public double TotalPrice { get; set; }

    }
}

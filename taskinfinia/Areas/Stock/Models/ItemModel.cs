namespace taskinfinia.Areas.Stock.Models
{
    public class ItemModel
    {
        public int qty { get; set; }
        public Decimal item_price { get; set; }
        public string item_name { get; set; }
        public string item_location { get; set; }
        public int cat_id { get; set; }
    }
}

using System.Collections.Generic;
namespace Gifts.Models
{
    public class CartItemModel
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public float ItemRate { get; set; }
        public int ItemQtyOrder { get; set; }
        public string ItemCat_Title { get; set; }
    }
    public class CartItemList
    {
        public List<CartItemModel> Items { get; set; }
    }
}
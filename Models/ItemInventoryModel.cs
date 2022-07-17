
using System;
using System.ComponentModel;

namespace Gifts.Models
{
    public class ItemInventoryModel
    {
        public int Id { get; set; }
        [DisplayName("Item")]
        public string Title { get; set; }
        public string Description { get; set; }
        public float Buying_Rate { get; set; }
        public float Selling_Rate { get; set; }
        public int Quantity { get; set; }
        public int Category_Id { get; set; }
        [DisplayName("Image")]
        public string Image_Path { get; set; }
        [DisplayName("Category")]
        public string Cat_Title { get; set; }
        [DisplayName("Added on")]
        public DateTime Created_At { get; set; }

    }
}
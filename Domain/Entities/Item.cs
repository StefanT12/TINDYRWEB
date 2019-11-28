using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public Item()
        {

        }
        public Item(int ID, string Name, string Description, string ImageURL, double Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.ImageURL = ImageURL;
        }
    }
}

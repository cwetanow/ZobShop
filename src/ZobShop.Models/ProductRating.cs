﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class ProductRating
    {
        public ProductRating()
        {

        }

        public ProductRating(int rating, string content, Product product, User author)
        {
            this.Rating = rating;
            this.Content = content;
            this.Author = author;
            this.Product = product;
        }

        [Key]
        public int ProductRatingId { get; set; }

        public int Rating { get; set; }

        public string Content { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [ForeignKey("Id")]
        public virtual User Author { get; set; }
    }
}

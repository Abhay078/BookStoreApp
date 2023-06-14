using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class WishListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemId { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity UserEntity { get; set; }
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public BookEntity BookEntity { get; set; }

    }
}

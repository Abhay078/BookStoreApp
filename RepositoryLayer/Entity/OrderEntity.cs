using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class OrderEntity
    {
        public OrderEntity()
        {
            Books= new List<BookEntity>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public ICollection<BookEntity> Books { get; set; }
        public DateTime CreatedDate { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity UserEntity { get; set;}

    }
}

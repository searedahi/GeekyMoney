using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GeekyMoney.Data.DTO
{
    public class BaseGeekyDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

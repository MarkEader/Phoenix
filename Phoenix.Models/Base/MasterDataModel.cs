using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Phoenix.Models.Interface;

namespace Phoenix.Models.Base
{
    public class MasterDataModel : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool Archived { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
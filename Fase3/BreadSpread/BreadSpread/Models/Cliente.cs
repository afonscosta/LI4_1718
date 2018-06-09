namespace BreadSpread.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Encomendas = new HashSet<Encomenda>();
        }

        [Key]
        public int idCli { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime dataNasc { get; set; }

        [Required]
        public int NIF { get; set; }

        [Required]
        [StringLength(20)]
        public string sexo { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string rua { get; set; }

        [Required]
        public int numPorta { get; set; }

        [Required]
        [StringLength(50)]
        public string codPostal { get; set; }

        [Required]
        [StringLength(50)]
        public string cidade { get; set; }

        public int? ratingServico { get; set; }

        [Required]
        [StringLength(50)]
        public string contacto { get; set; }

        [Required]
        [StringLength(50)]
        public string freguesia { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(20)]
        public string estadoConta { get; set; }

        public int? idSub { get; set; }

        public virtual Subscricao Subscricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda> Encomendas { get; set; }
    }
}

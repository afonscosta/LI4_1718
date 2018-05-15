namespace BreadSpread.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCli { get; set; }

        [StringLength(100)]
        public string nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime dataNasc { get; set; }

        public int NIF { get; set; }

        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string rua { get; set; }

        public int numPorta { get; set; }

        [StringLength(50)]
        public string codPostal { get; set; }

        [StringLength(50)]
        public string cidade { get; set; }

        public int ratingServico { get; set; }

        [StringLength(50)]
        public string contacto { get; set; }

        [StringLength(50)]
        public string freguesia { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(20)]
        public string estadoConta { get; set; }

        public int idSub { get; set; }

        public virtual Subscricao Subscricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda> Encomendas { get; set; }
    }
}

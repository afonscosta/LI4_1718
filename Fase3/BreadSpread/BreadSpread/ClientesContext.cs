namespace BreadSpread.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClientesContext : DbContext
    {
        public ClientesContext()
            : base("name=ClientesContext")
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Encomenda> Encomendas { get; set; }
        public virtual DbSet<Encomenda_Produto> Encomenda_Produto { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Produto> Produtoes { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<Subscricao> Subscricaos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Encomendas)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Encomenda>()
                .HasMany(e => e.Encomenda_Produto)
                .WithRequired(e => e.Encomenda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Funcionario>()
                .Property(e => e.estadoConta)
                .IsFixedLength();

            modelBuilder.Entity<Funcionario>()
                .HasMany(e => e.Encomendas)
                .WithRequired(e => e.Funcionario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Encomenda_Produto)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscricao>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Subscricao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscricao>()
                .HasMany(e => e.Slots)
                .WithRequired(e => e.Subscricao)
                .WillCascadeOnDelete(false);
        }
    }
}

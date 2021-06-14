using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace Brewtech.Dojo.SQL.Dados
{
    public partial class DojoSQLContext : DbContext
    {
        public DojoSQLContext()
        {
        }

        public DojoSQLContext(DbContextOptions<DojoSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoProduto> PedidoProduto { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaFisica> PessoaFisica { get; set; }
        public virtual DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoPreco> ProdutoPreco { get; set; }
        public virtual DbSet<ProdutoPrecoTipo> ProdutoPrecoTipo { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<TipoVigencia> TipoVigencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(DbLoggerFactory);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=25432;Database=DojoSQL;Username=postgres;Password=Dojo2021!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.IdPessoa).HasColumnName("id_pessoa");

                entity.Property(e => e.Situacao)
                    .HasMaxLength(1)
                    .HasColumnName("situacao");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_pessoa");
            });

            modelBuilder.Entity<PedidoProduto>(entity =>
            {
                entity.ToTable("pedido_produto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.Preco)
                    .HasColumnType("money")
                    .HasColumnName("preco");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoProdutos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_produto_pedido");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.PedidoProdutos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_produto_produto");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("nome");

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.ToTable("pessoa_fisica");

                entity.HasIndex(e => e.Cpf, "pessoa_fisica_cpf_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("cpf");

                entity.Property(e => e.IdPessoa).HasColumnName("id_pessoa");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.PessoaFisicas)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_fisica_pessoa");
            });

            modelBuilder.Entity<PessoaJuridica>(entity =>
            {
                entity.ToTable("pessoa_juridica");

                entity.HasIndex(e => e.Cnpj, "pessoa_juridica_cnpj_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("cnpj");

                entity.Property(e => e.IdPessoa).HasColumnName("id_pessoa");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("razao_social");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.PessoaJuridicas)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_juridica_pessoa");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ean13)
                    .HasMaxLength(13)
                    .HasColumnName("ean13");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("nome");

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<ProdutoPreco>(entity =>
            {
                entity.ToTable("produto_preco");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataFinal)
                    .HasColumnType("date")
                    .HasColumnName("data_final");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("data_inicio")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.Preco)
                    .HasColumnType("money")
                    .HasColumnName("preco");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoPrecos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_preco_produto");
            });

            modelBuilder.Entity<ProdutoPrecoTipo>(entity =>
            {
                entity.HasKey(e => new { e.IdTipo, e.IdProdutoPreco })
                    .HasName("pk_produto_preco_grupo");

                entity.ToTable("produto_preco_tipo");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.IdProdutoPreco).HasColumnName("id_produto_preco");

                entity.Property(e => e.Percentual)
                    .HasColumnName("percentual")
                    .HasDefaultValueSql("0.00");

                entity.HasOne(d => d.IdProdutoPrecoNavigation)
                    .WithMany(p => p.ProdutoPrecoTipos)
                    .HasForeignKey(d => d.IdProdutoPreco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_preco_grupo_produto_preco");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.ProdutoPrecoTipos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_preco_grupo_tipo");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("tipo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("nome");

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<TipoVigencia>(entity =>
            {
                entity.ToTable("tipo_vigencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fim)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("fim");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Inicio)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("inicio");

                entity.Property(e => e.Situacao)
                    .HasColumnName("situacao")
                    .HasDefaultValueSql("true");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.TipoVigencia)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipo_vigencia_tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        private static readonly ILoggerFactory DbLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddConsole();
        });
    }
}

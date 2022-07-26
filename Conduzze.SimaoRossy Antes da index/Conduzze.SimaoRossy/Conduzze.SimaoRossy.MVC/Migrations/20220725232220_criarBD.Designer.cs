﻿// <auto-generated />
using Conduzze.SimaoRossy.Data.Contextt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Conduzze.SimaoRossy.MVC.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220725232220_criarBD")]
    partial class criarBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Divisao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Divisoes");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("DivisaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SetorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("DivisaoId");

                    b.HasIndex("SetorId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DivisaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DivisaoId");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Divisao", b =>
                {
                    b.HasOne("Conduzze.SimaoRossy.Data.Model.Departamento", "Departamento")
                        .WithMany("Divisoes")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Funcionario", b =>
                {
                    b.HasOne("Conduzze.SimaoRossy.Data.Model.Departamento", "Departamento")
                        .WithMany("Funcionarios")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduzze.SimaoRossy.Data.Model.Divisao", "Divisao")
                        .WithMany("Funcionarios")
                        .HasForeignKey("DivisaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduzze.SimaoRossy.Data.Model.Setor", "Setor")
                        .WithMany("Funcionarios")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Divisao");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Setor", b =>
                {
                    b.HasOne("Conduzze.SimaoRossy.Data.Model.Divisao", "Divisao")
                        .WithMany("Setores")
                        .HasForeignKey("DivisaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Divisao");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Departamento", b =>
                {
                    b.Navigation("Divisoes");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Divisao", b =>
                {
                    b.Navigation("Funcionarios");

                    b.Navigation("Setores");
                });

            modelBuilder.Entity("Conduzze.SimaoRossy.Data.Model.Setor", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasks_System.DAL;

namespace Tasks_System.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Tasks_System.Entidades.Tareas", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            Descripcion = "La persona X debe de analizar el sistema que su superior le asignó.",
                            NombreTarea = "Análisis"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

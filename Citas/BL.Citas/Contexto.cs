﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Citas
{
    public class Contexto:DbContext
    {
        /*public Contexto() : base("Medicinas.")
        {

        }*/

        public Contexto() : base("Server=.;Database=PruebaDB;Trusted_Connection=True;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio()); // Agrega datos de inicio a la base de datos despues de eliminarla
        }

        public DbSet<Medicamento> Medicamentos  { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CocktailsApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class isi_projet2_tardymartial_remondvictorEntities : DbContext
    {
        public isi_projet2_tardymartial_remondvictorEntities()
            : base("name=isi_projet2_tardymartial_remondvictorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<alcool> alcool { get; set; }
        public DbSet<cocktail> cocktail { get; set; }
        public DbSet<etaperecette> etaperecette { get; set; }
        public DbSet<ingredientalcool> ingredientalcool { get; set; }
        public DbSet<ingredientsoft> ingredientsoft { get; set; }
        public DbSet<soft> soft { get; set; }
    }
}
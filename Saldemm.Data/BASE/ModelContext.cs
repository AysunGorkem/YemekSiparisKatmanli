using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;
using System.Data.Entity.ModelConfiguration;
using Saldemm.VO;

public class ModelContext : DbContext
{
		public DbSet<Cesitler> Cesitlers { get; set; }

		public DbSet<Kullanici> Kullanicis { get; set; }

		public DbSet<Satis> Satiss { get; set; }

		public DbSet<Yemek> Yemeks { get; set; }


	
    #region Constructor

    public ModelContext()
        : base(CS)
    {

    }

    #endregion

    #region Static

    #region  Field
    private static string CS
    {
        get { return ConfigurationManager.ConnectionStrings["cs"].ConnectionString; }
    }
    #endregion

    #endregion

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
		modelBuilder.Configurations.Add(new CesitlerConfiguration());

		modelBuilder.Configurations.Add(new KullaniciConfiguration());

		modelBuilder.Configurations.Add(new SatisConfiguration());

		modelBuilder.Configurations.Add(new YemekConfiguration());


        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        base.OnModelCreating(modelBuilder);
    }

		public class CesitlerConfiguration : EntityTypeConfiguration<Cesitler>
		{
			public CesitlerConfiguration()
			{
				ToTable("Cesitler");
			}
		}

		public class KullaniciConfiguration : EntityTypeConfiguration<Kullanici>
		{
			public KullaniciConfiguration()
			{
				ToTable("Kullanici");
			}
		}

		public class SatisConfiguration : EntityTypeConfiguration<Satis>
		{
			public SatisConfiguration()
			{
				ToTable("Satis");
			}
		}

		public class YemekConfiguration : EntityTypeConfiguration<Yemek>
		{
			public YemekConfiguration()
			{
				ToTable("Yemek");
			}
		}



}
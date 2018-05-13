using Microsoft.EntityFrameworkCore;

namespace Database.DatabaseContext
{
	public class EventDatabaseContext : DbContext
	{
		public DbSet<DCEvents> NMMEvent { get; set; }
		public DbSet<DCEventDetails> NMMEventDetails { get; set; }

		public readonly string _databasePath;

		public EventDatabaseContext()
		{
			//var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

			var pathForAndroidSystem = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var path = string.Format("{0}/{1}", pathForAndroidSystem, "EventsDatabase.db");
			_databasePath = path;
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlite(string.Format("Filename={0}", _databasePath));

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<DCEventDetails>()
			//.HasKey(exp => new { exp.EventId });

			//modelBuilder.Entity<DCEventDetails>()
			//.HasOne(prop => prop.ParentEvent);


		}
	}
}

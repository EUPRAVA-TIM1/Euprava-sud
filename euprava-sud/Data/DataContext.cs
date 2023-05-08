using eUprava.Court.Model;
using euprava_sud.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace euprava_sud.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Dokument> Dokumenti { get; set; }
        public DbSet<Gradjanin> Gradjani { get; set; }
        public DbSet<OdlukaSudije> OdlukeSudija { get; set; }
        public DbSet<Opstina> Opstine { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<PrekrsajnaPrijava> PrekrsajnePrijave { get; set; }
        public DbSet<Rociste> Rocista { get; set; }
        public DbSet<Sud> Sudovi { get; set; }
        public DbSet<Sudija> Sudije { get; set; }
        public DataContext(DbContextOptions<DataContext> dbContextOptions):base(dbContextOptions) {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gradjanin>()
                .HasOne(g => g.Opstina)
                .WithMany()
                .HasForeignKey(g => g.OpstinaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gradjanin>()
                .HasIndex(j => j.Jmbg).IsUnique();

            modelBuilder.Entity<Opstina>()
                .HasIndex(o => o.PTT).IsUnique();

            modelBuilder.Entity<Rociste>()
                .HasOne(r => r.Sud)
                .WithMany(s => s.Rocista)
                .HasForeignKey(r => r.SudId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Rociste>()
                .HasOne(r => r.Sudija)
                .WithMany()
                .HasForeignKey(r => r.SudijaJmbg)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rociste>()
                .HasOne(r => r.Predmet)
                .WithMany()
                .HasForeignKey(r => r.PredmetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OdlukaSudije>()
                .HasOne(o => o.Rociste)
                .WithMany()
                .HasForeignKey(o => o.RocisteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OdlukaSudije>()
                .HasOne(o => o.Sudija)
                .WithMany()
                .HasForeignKey(o => o.SudijaJmbg)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OdlukaSudije>()
                .HasOne(o => o.Predmet)
                .WithMany()
                .HasForeignKey(o => o.PredmetId)
                .OnDelete(DeleteBehavior.Restrict);

            /*modelBuilder.Entity<PrekrsajnaPrijava>()
                .HasOne(p => p.Optuzeni)
                .WithMany()
                .HasForeignKey(p => p.OptuzeniJmbg)
                .OnDelete(DeleteBehavior.Restrict);*/

            /*modelBuilder.Entity<PrekrsajnaPrijava>()
                .HasOne(p => p.PrijavljenoOd)
                .WithMany()
                .HasForeignKey(p => p.PrijavljenoOdJmbg)
                .OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<PrekrsajnaPrijava>()
                .HasOne(p => p.Sudija)
                .WithMany()
                .HasForeignKey(p => p.SudijaJmbg)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrekrsajnaPrijava>()
                .HasOne(p => p.Opstina)
                .WithMany()
                .HasForeignKey(p => p.OpstinaId)
                .OnDelete(DeleteBehavior.Restrict);


            /*modelBuilder.Entity<PrekrsajnaPrijava>()
                .HasMany(o => o.Svedoci)
                .WithMany()
                .UsingEntity(j => j.ToTable("OdlukaSudijeSvedoci"));*/

            modelBuilder.Entity<PrekrsajnaPrijava>()
                .HasMany(o => o.Dokumenti)
                .WithMany()
                .UsingEntity(j => j.ToTable("OdlukaSudijeDokumenti"));

            modelBuilder.Entity<Sud>()
                .HasMany(s => s.Sudije)
                .WithOne(sj => sj.Sud)
                .HasForeignKey(sj => sj.SudId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sud>()
                .HasOne(s => s.Opstina)
                .WithMany()
                .HasForeignKey(s => s.OpstinaId)
                .OnDelete(DeleteBehavior.Restrict);

            /*modelBuilder.Entity<Sud>()
                .HasMany(o => o.Rocista)
                .WithMany()
                .UsingEntity(j => j.ToTable("SudRocista"));*/

            /*modelBuilder.Entity<Predmet>()
                .HasOne(p => p.Advokat)
                .WithMany()
                .HasForeignKey(p => p.AdvokatJmbg)
                .OnDelete(DeleteBehavior.Restrict);*/
            modelBuilder.Entity<Predmet>()
                .HasOne(p => p.PrekrsajnaPrijava)
                .WithMany()
                .HasForeignKey(p => p.PrekrsajnaPrijavaId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}

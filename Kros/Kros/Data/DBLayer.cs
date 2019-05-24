using System;
using System.Data.Entity;
using System.Linq;

namespace Kros.Data
{
	public class DBLayer : DbContext
	{

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Firma>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Firmy");
			});

			modelBuilder.Entity<Divizia>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Divizie");
			});
			modelBuilder.Entity<Projekt>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Projekty");
			});
			modelBuilder.Entity<Oddelenie>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Oddelenia");
			});
			modelBuilder.Entity<PersonF>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("PeopleF");
			});

			modelBuilder.Entity<PersonD>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("PeopleD");
			});
			modelBuilder.Entity<PersonP>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("PeopleP");
			});
			modelBuilder.Entity<PersonO>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("PeopleO");
			});
		}
		public virtual DbSet<Firma> Firmy { get; set; }
		public virtual DbSet<PersonF> PeopleF { get; set; }
		public virtual DbSet<Divizia> Divizie { get; set; }
		public virtual DbSet<PersonD> PeopleD { get; set; }
		public virtual DbSet<Projekt> Projekty { get; set; }
		public virtual DbSet<PersonP> PeopleP { get; set; }
		public virtual DbSet<Oddelenie> Oddelenia { get; set; }
		public virtual DbSet<PersonO> PeopleO { get; set; }

		internal void Add(TableBase table)
		{
			switch (table)
			{
				case Firma f:
					Firmy.Add(f);
					break;
				case Divizia d:
					Divizie.Add(d);
					break;
				case Projekt p:
					Projekty.Add(p);
					break;
				case Oddelenie o:
					Oddelenia.Add(o);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}


		internal void Remove(TableBase table)
		{
			switch (table)
			{
				case Firma f:
					f.MainPerson = null;
					SaveChanges();
					while (f.SubTable.Any())
						Remove(f.SubTable.First());
					Firmy.Remove(f);
					break;
				case Divizia d:
					d.MainPerson = null;
					SaveChanges();
					while (d.SubTable.Any())
						Remove(d.SubTable.First());
					Divizie.Remove(d);
					break;
				case Projekt p:
					p.MainPerson = null;
					SaveChanges();
					while (p.SubTable.Any())
						Remove(p.SubTable.First());
					Projekty.Remove(p);
					break;
				case Oddelenie o:
					o.MainPerson = null;
					SaveChanges();
					Oddelenia.Remove(o);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		internal void Add(Person person)
		{
			switch (person)
			{
				case PersonF f:
					PeopleF.Add(f);
					break;
				case PersonD d:
					PeopleD.Add(d);
					break;
				case PersonP p:
					PeopleP.Add(p);
					break;
				case PersonO o:
					PeopleO.Add(o);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		internal void Remove(Person person)
		{
			switch (person)
			{
				case PersonF f:
					PeopleF.Remove(f);
					break;
				case PersonD d:
					PeopleD.Remove(d);
					break;
				case PersonP p:
					PeopleP.Remove(p);
					break;
				case PersonO o:
					PeopleO.Remove(o);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

	}
}

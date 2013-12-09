using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using ProjectBoard.Core.Models;
using ProjectBoard.Core.Models.Mapping;

namespace ProjectBoard.Core.Data.Context.Db
{
    public partial class AnswerProjectBoardContext : DbContext
    {
        static AnswerProjectBoardContext()
        {
            Database.SetInitializer<AnswerProjectBoardContext>(null);
        }

        public AnswerProjectBoardContext()
            : base("Name=AnswerProjectBoardContext")
        {
        }

		
		public DbSet<Client> Clients { get; set; }
		
		public DbSet<ClientProjectLinkTest> ClientProjectLinkTests { get; set; }
		
		public DbSet<Project> Projects { get; set; }
		
		public DbSet<ProjectStatus> ProjectStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ClientProjectLinkTestMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ProjectStatusMap());
        }
    }
}

namespace ProjectBoard.Core.Data.Context
{
	using ProjectBoard.Core.Data.Context.Db;
	using ProjectBoard.Core.Data.Contracts;

	public class Repository: IRepository
    {
		private readonly AnswerProjectBoardContext _db = new AnswerProjectBoardContext();

		public IQueryable<Client> Clients 
		{ 
			get
			{
				return _db.Clients.AsQueryable();
			} 
		}
		public IQueryable<ClientProjectLinkTest> ClientProjectLinkTests 
		{ 
			get
			{
				return _db.ClientProjectLinkTests.AsQueryable();
			} 
		}
		public IQueryable<Project> Projects 
		{ 
			get
			{
				return _db.Projects.AsQueryable();
			} 
		}
		public IQueryable<ProjectStatus> ProjectStatus 
		{ 
			get
			{
				return _db.ProjectStatus.AsQueryable();
			} 
		}
		public virtual T Add<T>(T entity) where T : class, IEntity<T>
        {
            return _db.Set<T>().Add(entity);
        }

        public virtual IEnumerable<T> Add<T>(IEnumerable<T> entities) where T : class, IEntity<T>
        {
            var result = new List<T>();

            foreach (var entity in entities)
            {
                result.Add(Add(entity));
            }

            return result;
        }

        public virtual T Remove<T>(T entity) where T : class, IEntity<T>
        {
            return _db.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> Remove<T>(IEnumerable<T> entities) where T : class, IEntity<T>
        {
            var result = new List<T>();

            foreach (var entity in entities)
            {
                result.Add(Remove(entity));
            }

            return result;
        }

		public virtual T FindByKey<T>(params object[] key) where T : class, IEntity<T>
        {
            return _db.Set<T>().Find(key);
        }

        public virtual IQueryable<T> Query<T>() where T : class, IEntity<T>
        {
            return _db.Set<T>().AsQueryable();
        }
        
		public virtual int SaveChanges()
		{
			return _db.SaveChanges();
		}

		public virtual void Dispose()
        {
            _db.Dispose();
        }
    }
}

namespace ProjectBoard.Core.Data.Contracts
{
	public interface IRepository: IDisposable
    {
		IQueryable<Client> Clients { get; }
		IQueryable<ClientProjectLinkTest> ClientProjectLinkTests { get; }
		IQueryable<Project> Projects { get; }
		IQueryable<ProjectStatus> ProjectStatus { get; }
		T Add<T>(T entity) where T : class, IEntity<T>;
		IEnumerable<T> Add<T>(IEnumerable<T> entities) where T : class, IEntity<T>;

		T Remove<T>(T entity) where T : class, IEntity<T>;
		IEnumerable<T> Remove<T>(IEnumerable<T> entities) where T : class, IEntity<T>;

		T FindByKey<T>(params object[] key) where T : class, IEntity<T>;

		IQueryable<T> Query<T>() where T : class, IEntity<T>;

		int SaveChanges();
    }

	public interface IEntity<in TEntity> where TEntity : class
    {        
        void Update(TEntity entity);
    }
}

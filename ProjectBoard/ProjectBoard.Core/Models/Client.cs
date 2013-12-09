using System;
using System.Collections.Generic;
using System.Linq; 
using ProjectBoard.Core.Data.Contracts;
 
using System.ComponentModel.DataAnnotations.Schema; 

namespace ProjectBoard.Core.Models
{
	 
    public partial class Client :IEntity<Client>
    {
        public Client()
        {
            this.ClientProjectLinkTests = new List<ClientProjectLinkTest>();
            this.Projects = new List<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual ICollection<ClientProjectLinkTest> ClientProjectLinkTests { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

		public void Update(Client entity)
		{
			this.Id = entity.Id;
			this.Name = entity.Name;
			this.Description = entity.Description;
			this.CreatedOn = entity.CreatedOn;
		}
    }

	public static class ClientGeneratedFilters 
    {
		public static IQueryable<Client> ForId(this IQueryable<Client> query, int Id)
        {
            return query.Where(o => o.Id == Id);
        }
		public static IQueryable<Client> ForName(this IQueryable<Client> query, string Name)
        {
            return query.Where(o => o.Name == Name);
        }
		public static IQueryable<Client> ForDescription(this IQueryable<Client> query, string Description)
        {
            return query.Where(o => o.Description == Description);
        }
		public static IQueryable<Client> ForCreatedOn(this IQueryable<Client> query, System.DateTime CreatedOn)
        {
            return query.Where(o => o.CreatedOn == CreatedOn);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq; 
using ProjectBoard.Core.Data.Contracts;
 
using System.ComponentModel.DataAnnotations.Schema; 

namespace ProjectBoard.Core.Models
{
	 
    public partial class ClientProjectLinkTest :IEntity<ClientProjectLinkTest>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Client Client { get; set; }
        public virtual Project Project { get; set; }

		public void Update(ClientProjectLinkTest entity)
		{
			this.Id = entity.Id;
			this.ClientId = entity.ClientId;
			this.ProjectId = entity.ProjectId;
			this.CreatedOn = entity.CreatedOn;
		}
    }

	public static class ClientProjectLinkTestGeneratedFilters 
    {
		public static IQueryable<ClientProjectLinkTest> ForId(this IQueryable<ClientProjectLinkTest> query, int Id)
        {
            return query.Where(o => o.Id == Id);
        }
		public static IQueryable<ClientProjectLinkTest> ForClientId(this IQueryable<ClientProjectLinkTest> query, int ClientId)
        {
            return query.Where(o => o.ClientId == ClientId);
        }
		public static IQueryable<ClientProjectLinkTest> ForProjectId(this IQueryable<ClientProjectLinkTest> query, int ProjectId)
        {
            return query.Where(o => o.ProjectId == ProjectId);
        }
		public static IQueryable<ClientProjectLinkTest> ForCreatedOn(this IQueryable<ClientProjectLinkTest> query, System.DateTime CreatedOn)
        {
            return query.Where(o => o.CreatedOn == CreatedOn);
        }
    }
}

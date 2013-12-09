using System;
using System.Collections.Generic;
using System.Linq; 
using ProjectBoard.Core.Data.Contracts;
 
using System.ComponentModel.DataAnnotations.Schema; 

namespace ProjectBoard.Core.Data.Models
{
	 
    public partial class Project :IEntity<Project>
    {
        public Project()
        {
            this.ClientProjectLinkTests = new List<ClientProjectLinkTest>();
        }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public byte StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ProposedStartDate { get; set; }
        public Nullable<System.DateTime> ProposedEndDate { get; set; }
        public Nullable<System.DateTime> ActualStartDate { get; set; }
        public Nullable<System.DateTime> ActualEndDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<ClientProjectLinkTest> ClientProjectLinkTests { get; set; }
        public virtual ProjectStatus ProjectStatu { get; set; }

		public void Update(Project entity)
		{
			this.Id = entity.Id;
			this.ClientId = entity.ClientId;
			this.StatusId = entity.StatusId;
			this.Name = entity.Name;
			this.Description = entity.Description;
			this.CreatedOn = entity.CreatedOn;
			this.ProposedStartDate = entity.ProposedStartDate;
			this.ProposedEndDate = entity.ProposedEndDate;
			this.ActualStartDate = entity.ActualStartDate;
			this.ActualEndDate = entity.ActualEndDate;
		}
    }

	public static class ProjectGeneratedFilters 
    {
		public static IQueryable<Project> ForId(this IQueryable<Project> query, int Id)
        {
            return query.Where(o => o.Id == Id);
        }
		public static IQueryable<Project> ForClientId(this IQueryable<Project> query, int ClientId)
        {
            return query.Where(o => o.ClientId == ClientId);
        }
		public static IQueryable<Project> ForStatusId(this IQueryable<Project> query, byte StatusId)
        {
            return query.Where(o => o.StatusId == StatusId);
        }
		public static IQueryable<Project> ForName(this IQueryable<Project> query, string Name)
        {
            return query.Where(o => o.Name == Name);
        }
		public static IQueryable<Project> ForDescription(this IQueryable<Project> query, string Description)
        {
            return query.Where(o => o.Description == Description);
        }
		public static IQueryable<Project> ForCreatedOn(this IQueryable<Project> query, System.DateTime CreatedOn)
        {
            return query.Where(o => o.CreatedOn == CreatedOn);
        }
		public static IQueryable<Project> ForProposedStartDate(this IQueryable<Project> query, Nullable<System.DateTime> ProposedStartDate)
        {
            return query.Where(o => o.ProposedStartDate == ProposedStartDate);
        }
		public static IQueryable<Project> ForProposedEndDate(this IQueryable<Project> query, Nullable<System.DateTime> ProposedEndDate)
        {
            return query.Where(o => o.ProposedEndDate == ProposedEndDate);
        }
		public static IQueryable<Project> ForActualStartDate(this IQueryable<Project> query, Nullable<System.DateTime> ActualStartDate)
        {
            return query.Where(o => o.ActualStartDate == ActualStartDate);
        }
		public static IQueryable<Project> ForActualEndDate(this IQueryable<Project> query, Nullable<System.DateTime> ActualEndDate)
        {
            return query.Where(o => o.ActualEndDate == ActualEndDate);
        }
    }
}

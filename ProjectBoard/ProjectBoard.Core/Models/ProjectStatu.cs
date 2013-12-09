using System;
using System.Collections.Generic;
using System.Linq; 
using ProjectBoard.Core.Data.Contracts;
 
using System.ComponentModel.DataAnnotations.Schema; 

namespace ProjectBoard.Core.Models
{
	 
    public partial class ProjectStatus :IEntity<ProjectStatus>
    {
        public ProjectStatus()
        {
            this.Projects = new List<Project>();
        }
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

		public void Update(ProjectStatus entity)
		{
			this.Id = entity.Id;
			this.Name = entity.Name;
			this.Description = entity.Description;
			this.CreatedOn = entity.CreatedOn;
		}
    }

	public static class ProjectStatusGeneratedFilters 
    {
		public static IQueryable<ProjectStatus> ForId(this IQueryable<ProjectStatus> query, byte Id)
        {
            return query.Where(o => o.Id == Id);
        }
		public static IQueryable<ProjectStatus> ForName(this IQueryable<ProjectStatus> query, string Name)
        {
            return query.Where(o => o.Name == Name);
        }
		public static IQueryable<ProjectStatus> ForDescription(this IQueryable<ProjectStatus> query, string Description)
        {
            return query.Where(o => o.Description == Description);
        }
		public static IQueryable<ProjectStatus> ForCreatedOn(this IQueryable<ProjectStatus> query, System.DateTime CreatedOn)
        {
            return query.Where(o => o.CreatedOn == CreatedOn);
        }
    }
}

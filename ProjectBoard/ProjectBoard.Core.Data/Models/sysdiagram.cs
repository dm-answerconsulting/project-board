using System;
using System.Collections.Generic;
using System.Linq; 
using ProjectBoard.Core.Data.Contracts;
 
using System.ComponentModel.DataAnnotations.Schema; 

namespace ProjectBoard.Core.Data.Models.Unused
{
	 
    public partial class sysdiagrams :IEntity<sysdiagrams>
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public Nullable<int> version { get; set; }
        public byte[] definition { get; set; }

		public void Update(sysdiagrams entity)
		{
			this.name = entity.name;
			this.principal_id = entity.principal_id;
			this.diagram_id = entity.diagram_id;
			this.version = entity.version;
			this.definition = entity.definition;
		}
    }

	public static class sysdiagramsGeneratedFilters 
    {
		public static IQueryable<sysdiagrams> Forname(this IQueryable<sysdiagrams> query, string name)
        {
            return query.Where(o => o.name == name);
        }
		public static IQueryable<sysdiagrams> Forprincipal_id(this IQueryable<sysdiagrams> query, int principal_id)
        {
            return query.Where(o => o.principal_id == principal_id);
        }
		public static IQueryable<sysdiagrams> Fordiagram_id(this IQueryable<sysdiagrams> query, int diagram_id)
        {
            return query.Where(o => o.diagram_id == diagram_id);
        }
		public static IQueryable<sysdiagrams> Forversion(this IQueryable<sysdiagrams> query, Nullable<int> version)
        {
            return query.Where(o => o.version == version);
        }
		public static IQueryable<sysdiagrams> Fordefinition(this IQueryable<sysdiagrams> query, byte[] definition)
        {
            return query.Where(o => o.definition == definition);
        }
    }
}

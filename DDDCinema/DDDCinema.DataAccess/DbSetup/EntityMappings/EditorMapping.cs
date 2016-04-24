using System.Data.Entity.ModelConfiguration;
using DDDCinema.Promotions;

namespace DDDCinema.DataAccess.DbSetup.EntityMappings
{
	public class EditorMapping : ComplexTypeConfiguration<Editor>
	{
		public EditorMapping()
		{
			Property(m => m.Id);
			Property(m => m.Name);
		}
	}
}

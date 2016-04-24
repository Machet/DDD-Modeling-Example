using System;
using System.Collections.Generic;
using System.Linq;
using DDDCinema.Promotions;

namespace DDDCinema.DataAccess.Business
{
	public class EfUserInRoleRepository : IUserInRoleRepository
	{
		private readonly CinemaContext _context;

		public EfUserInRoleRepository(CinemaContext context)
		{
			_context = context;
		}

		public List<Editor> GetAllEditors()
		{
			return _context.Users
				.Where(u => u.Role == "Editor")
				.Select(u => new { Id = u.Id, Name = u.Name })
				.ToList()
				.Select(u => new Editor(u.Id, u.Name))
				.ToList();

		}

		public Editor GetEditor(Guid editorId)
		{
			var editor = _context.Users
				.Where(u => u.Id == editorId && u.Role == "Editor")
				.Select(u => new { Id = u.Id, Name = u.Name })
				.SingleOrDefault();

			return editor == null ? null : new Editor(editor.Id, editor.Name);
		}
	}
}

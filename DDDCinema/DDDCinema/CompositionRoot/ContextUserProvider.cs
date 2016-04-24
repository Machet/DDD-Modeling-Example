using System;
using System.Web;
using System.Web.Security;
using DDDCinema.Common;

namespace DDDCinema.CompositionRoot
{
	public class ContextUserProvider : ICurrentUserProvider
	{
		private Guid? Id
		{
			get { return HttpContext.Current.Session["UserId"] as Guid?; }
			set { HttpContext.Current.Session["UserId"] = value; }
		}

		private string Role
		{
			get { return HttpContext.Current.Session["Role"] as string; }
			set { HttpContext.Current.Session["Role"] = value; }
		}

		public Guid? GetUserId()
		{
			if (Id == null)
			{
				ParseKey();
			}

			return Id;
		}

		public string GetRole()
		{
			if (Role == null)
			{
				ParseKey();
			}

			return Role;
		}

		public void SetUser(Guid id, string role)
		{
			Role = role;
			Id = id;

			FormsAuthentication.SetAuthCookie(id + "|" + role, false);
		}

		public void Clear()
		{
			Id = null;
			Role = null;
			FormsAuthentication.SignOut();
		}

		private void ParseKey()
		{
			if (string.IsNullOrEmpty(UserKey))
			{
				return;
			}

			var userData = UserKey.Split('|');
			Id = Guid.Parse(userData[0]);
			Role = userData.Length == 2 ? userData[1] : string.Empty;
		}

		private string UserKey
		{
			get { return HttpContext.Current.User.Identity.Name; }
		}
	}
}
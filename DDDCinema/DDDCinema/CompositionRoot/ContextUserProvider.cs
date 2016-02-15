using DDDCinema.Movies.Authentication;
using System;
using System.Web;

namespace DDDCinema.CompositionRoot
{
    public class ContextUserProvider : ICurrentUserProvider
    {
        private Guid? _id;
       
        public string Role
        {
            get { return HttpContext.Current.Session["Role"].ToString(); }
            set { HttpContext.Current.Session["Role"] = value; }
        }

        public Guid? GetUserId()
        {
            return !string.IsNullOrEmpty(StringId)
                ? Guid.Parse(StringId)
                : _id;
        }

        public void SetUser(Guid id, string role)
        {
            if (string.IsNullOrEmpty(StringId))
            {
                _id = id;
                Role = role;
            }
        }

        private string StringId
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
    }
}
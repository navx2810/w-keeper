using System.Collections.Generic;
using Keeper.Code.Auth.Challenges;
using Keeper.Code.Models;

namespace Keeper.Code
{
    public interface IUserChallenge : IChallenge
    {
        bool OwnsEntry(Models.User u, Models.Entry e);
        bool HasName(Models.User u);
        bool HasPassword(Models.User u);
    }

    public class UserChallenge : IUserChallenge
    {
        public IErrors Errors => new BasicErrors();

        public bool HasName(User u)
        {
            bool invalid = u.Name.IsEmpty();
            if(invalid) { Errors.Add("Name", "Name can not be empty."); }
            return invalid;
        }

        public bool HasPassword(User u)
        {
            bool invalid = u.Password.IsEmpty();
            if(invalid) { Errors.Add("Password", "Password can not be empty."); }
            return invalid;
        }

        public bool OwnsEntry(User u, Entry e)
        {
            bool invalid = e.Author.Equals(u);
            if (invalid) { Errors.Add("OwnsEntry", "You do not own this entry."); }
            return invalid;
        }

        bool HasErrors => Errors.HasAny;
    }
}
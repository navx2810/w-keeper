using System.Collections.Generic;
using Xunit;

namespace Keeper.Code.DAO
{
    public class ClientUser
    {
        public int Id { get; set; }
        public string IP { get; set; }
    }
}

namespace Keeper.Code.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private string _password;
        public string Password
        {
            get { return _password;}
            set { _password = Utils.Hash(value);}
        }
    }
    public class Entry
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Entry Parent { get; set; }
        public User Author { get; set; }
        public virtual List<Entry> Entries { get; set; } = null;
    }

}
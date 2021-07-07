using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public Friend(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}

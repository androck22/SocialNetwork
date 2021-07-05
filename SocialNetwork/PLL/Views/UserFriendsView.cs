using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("Друзья");

            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас пока нет друзей");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Ваши друзья: {0} {1}", friend.FirstName, friend.LastName);
            });
        }
    }
}

using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<Friend> GetFriendByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.friend_id);

                friends.Add(new Friend(m.friend_id, senderUserEntity.firstname, senderUserEntity.lastname));
            });

            return friends;
        }

        public void AddFriend(FriendAddnigData friendAddnigData)
        {
            if (!new EmailAddressAttribute().IsValid(friendAddnigData.FriendMail))
                throw new ArgumentNullException();

            var findUserEntity = this.userRepository.FindByEmail(friendAddnigData.FriendMail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddnigData.SenderId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}

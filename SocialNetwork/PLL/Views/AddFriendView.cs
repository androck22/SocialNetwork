using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        FriendService friendService;

        public AddFriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(ref User user)
        {
            var friendAddingData = new FriendAddnigData();

            Console.WriteLine("Введите почту друга: ");
            friendAddingData.FriendMail = Console.ReadLine();

            friendAddingData.SenderId = user.Id;

            try
            {
                friendService.AddFriend(friendAddingData);

                SuccessMessage.Show("Пользователь успешно добавлен в друзья!");

                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении пользователя в друзья!");
            }
        }
    }
}

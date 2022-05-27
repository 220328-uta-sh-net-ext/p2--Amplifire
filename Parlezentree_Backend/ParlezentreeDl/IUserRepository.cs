using System;
using ParlezentreeDl.Entities;

namespace ParlezentreeDl
{
    public interface IUserRepository
    {
        /// <summary>
        /// this methos is used for getting all the users from the database
        /// </summary>
        /// <returns>list of user</returns>
        List<User> getAllUser();

        /// <summary>
        /// This methos is used to add user in databse
        /// </summary>
        /// <param name="user"></param>
        /// <returns>string wether user is added or not</returns>
        string addUser(User user);

        /// <summary>
        /// This methos is used to update the user in the databse
        /// </summary>
        /// <param name="user"></param>
        /// <returns>string wether user is updated or not</returns>
        string updateUser(User user);

    }
}


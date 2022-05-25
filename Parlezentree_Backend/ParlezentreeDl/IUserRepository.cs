using System;
using ParlezentreeDl.Entities;

namespace ParlezentreeDl
{
	public interface IUserRepository
	{
		List<User> getAllUser();

		string addUser(User user);

		

	}
}


using System;
using ParlezentreeDl.Entities;

namespace ParlezentreeDl
{
	public interface IUser
	{
		string getAllUser();

		string addUser(User user);


	}
}


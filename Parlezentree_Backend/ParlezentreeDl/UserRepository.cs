using ParlezentreeDl.Entities;

namespace ParlezentreeDl;
public class UserRepository : IUserRepository
{
    private parlez_entreeContext db;
    public UserRepository(parlez_entreeContext db)
    {
        this.db = db;
    }
    public string addUser(User user)
    {
        var name = user.FirstName;
        db.Users.Add(user);
        var result = db.SaveChanges();
        if (result == 1)
        {
            return "user is added.";
        }
        else
        {
            return "user is not added.";
        }

    }


    public List<User> getAllUser()
    {
        return db.Users.ToList();
    }


    public string updateUser(User user)
    {

        db.Users.Update(user);
        var result = db.SaveChanges();
        if (result == 1)
        {
            return "user is updated.";
        }
        else
        {
            return "user is not updated.";
        }
    }
}


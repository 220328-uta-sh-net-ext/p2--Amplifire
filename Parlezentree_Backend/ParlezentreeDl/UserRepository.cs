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
        throw new NotImplementedException();
    }



    public List<User> getAllUser()
    {
        return db.Users.ToList();
    }
}


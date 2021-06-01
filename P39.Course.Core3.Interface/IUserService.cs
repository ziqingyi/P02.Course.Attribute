

using P39.Course.EntityFrameworkCore3.Model;


namespace P39.Course.Core3.Interface
{
    public interface IUserService :IBaseService
    {
        //add some extra methods required for User Service
        void UpdateLastLogin(User user);
    }
}

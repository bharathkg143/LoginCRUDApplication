using LoginApplication.Models;
using System.Linq.Expressions;

namespace LoginApplication.Repository
{
    public interface ISignUpRepository
    {
        SignUp Get(int id);
        IEnumerable<SignUp> GetAll();
        void Add(SignUp signUp);
        void Update(SignUp signUp);
        void Delete(int id);
    }
}

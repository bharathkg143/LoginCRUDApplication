using LoginApplication.Data;
using LoginApplication.Models;

namespace LoginApplication.Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly ApplicationDbContext _context;

        public SignUpRepository(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public void Add(SignUp signUp)
        {
            _context.SignUps.Add(signUp);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            SignUp? signUp = _context.SignUps.FirstOrDefault(x => x.Id == id);
            if (signUp != null)
            {
                _context.SignUps.Remove(signUp);
                _context.SaveChanges();
            }
        }

        public SignUp Get(int id)
        {
            SignUp? signUp = _context.SignUps.FirstOrDefault(x => x.Id == id);
           
              return signUp;
            
           
        }

        public IEnumerable<SignUp> GetAll()
        {
            IEnumerable<SignUp> logins = _context.SignUps;

            return logins;
        }

        public void Update(SignUp signUp)
        {
            _context.SignUps.Update(signUp);
            _context.SaveChanges();
        }
    }
}

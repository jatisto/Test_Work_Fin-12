using System.Collections.Generic;
using System.Linq;
using test_work_fin_12.Data;
using test_work_fin_12.Models;

namespace test_work_fin_12.Repository {
    public class UserRepository {
        private AppDbContext _context;

        public UserRepository (AppDbContext context) {
            _context = context;
        }
        public List<User> AllUsers () {

            return _context.Users.ToList ();
        }

        public void Create (User user) {
            _context.Users.Add (user);
            _context.SaveChangesAsync ();
        }

        public void Delete (User user) {
            _context.Users.Remove (user);
            _context.SaveChangesAsync ();
        }

        public void Edit (User user) {
            _context.Users.Update (user);
            _context.SaveChangesAsync ();
        }

        public User GetSingleUser (string id) {
            var user = _context.Users.FirstOrDefault (u => u.Id == id);
            return user;
        }
    }
}
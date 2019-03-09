using System.Collections.Generic;
using test_work_fin_12.Models;

namespace test_work_fin_12.Interface {
    public interface IUserRepository {
        void Create (User user);
        void Edit (User user);
        void Delete (User user);
        User GetSingleUser (string id);
        List<User> AllUsers ();
        IEnumerable<User> Useries { get; }
    }
}
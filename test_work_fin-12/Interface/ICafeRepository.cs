using System.Collections.Generic;
using test_work_fin_12.Models;

namespace test_work_fin_12.Interface {
    public interface ICafeRepository {
        IEnumerable<Cafe> CafesList { get; }
        void Create (Cafe cafe);
        void Edit (Cafe cafe);
        void Delete (Cafe cafe);
        List<Cafe> AllCafes ();
        Cafe GetSingleCafeById (string id);
    }
}
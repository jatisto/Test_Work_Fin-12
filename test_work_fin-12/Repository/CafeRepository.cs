using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using test_work_fin_12.Data;
using test_work_fin_12.Interface;
using test_work_fin_12.Models;

namespace test_work_fin_12.Repository {
    public class CafeRepository : ICafeRepository {

        private AppDbContext _context;

        public CafeRepository (AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Cafe> CafesList => _context.Cafes.Include(u => u.User);

        public List<Cafe> AllCafes () {
            return _context.Cafes.ToList ();
        }

        public void Create (Cafe cafe) {
            _context.Cafes.Add (cafe);
            _context.SaveChangesAsync ();
        }

        public void Delete (Cafe cafe) {
            _context.Cafes.Remove (cafe);
            _context.SaveChangesAsync ();
        }

        public void Edit (Cafe cafe) {
            _context.Cafes.Update (cafe);
            _context.SaveChangesAsync ();
        }

        public Cafe GetSingleCafeById (string id) {
            var cafe = _context.Cafes.FirstOrDefault (u => u.Id == id);
            return cafe;
        }

    }
}
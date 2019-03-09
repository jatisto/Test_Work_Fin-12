using System;
using System.Collections.Generic;
using System.Linq;
using test_work_fin_12.Data;
using test_work_fin_12.Interface;
using test_work_fin_12.Models;

namespace test_work_fin_12.Mocks {
    public class MockCafeRepository : ICafeRepository {
        // private readonly IUserRepository _userRepository = new MockCafeRepository ();
        private readonly AppDbContext _context;
        public MockCafeRepository (AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Cafe> CafesList {
            get {
                return new List<Cafe> {
                    new Cafe {
                        Name = "Cafe1",
                            Description = "Кафе которое хочеться посетить",
                            ImageUrl = "https://www.openbusiness.ru/upload/iblock/a22/mini_kafe1000.png",
                            Score = 3,
                            // User = _userRepository.Useries.First ()
                    },
                    new Cafe {
                        Name = "Cafe2",
                            Description = "Кафе которое хочеться посетить дважды",
                            ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/13/28/8c/c5/look-cafe.jpg",
                            Score = 5,
                            // User = _userRepository.Useries.First ()
                    },
                    new Cafe {
                        Name = "Cafe3",
                            Description = "Кафе которое хочеться посетить трижды",
                            ImageUrl = "https://www.openbusiness.ru/upload/iblock/a22/mini_kafe1000.png",
                            Score = 7,
                            // User = _userRepository.Useries.First ()
                    }
                };
            }
        }

        public List<User> AllUsers () {
            throw new NotImplementedException ();
        }

        public void Create (Cafe cafe) {
            throw new NotImplementedException ();
        }

        public void Delete (Cafe cafe) {
            throw new NotImplementedException ();
        }

        public void Edit (Cafe cafe) {
            throw new NotImplementedException ();
        }

        public Cafe GetSingleCafeById (string id) {
            var cafe = _context.Cafes.FirstOrDefault (u => u.Id == id);
            return cafe;
        }

        List<Cafe> ICafeRepository.AllCafes () {
            throw new NotImplementedException ();
        }
    }
}
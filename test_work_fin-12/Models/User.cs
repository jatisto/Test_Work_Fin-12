using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace test_work_fin_12.Models {
    public class User : IdentityUser {
        public List<Cafe> Cafes { get; set; }
    }
}
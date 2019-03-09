using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test_work_fin_12.Models;

namespace test_work_fin_12.ViewModels {
    public class RatingViewModel {

        public IEnumerable<Cafe> CafeListVM { get; set; }

        [HiddenInput]
        public int Rating { get; set; }

        public string IdCafe { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test_work_fin_12.Data;
using test_work_fin_12.Interface;
using test_work_fin_12.Models;
using test_work_fin_12.ViewModels;

namespace test_work_fin_12.Controllers {
    public class HomeController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly ICafeRepository _cafeRepository;
        private readonly FileUploadService _fileUploadService;
        private AppDbContext _context;

        public HomeController (
            ICafeRepository cafeRepository,
            UserManager<User> userManager,
            AppDbContext context) {
            // _userRepository  = userRepository;
            _cafeRepository = cafeRepository;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index () {
            CafeVM vm = new CafeVM ();
            vm.CafeListVM = _cafeRepository.CafesList;
            return View (vm);
        }

        public IActionResult Rating () {
            RatingViewModel model = new RatingViewModel ();
            return View (model);
        }

        [HttpPost]
        public ActionResult Rating (RatingViewModel model, string id) {

            var sCafe = _cafeRepository.GetSingleCafeById (id);
            if (sCafe != null) {
                sCafe.Score = model.Rating;
                _cafeRepository.Edit (sCafe);
                return RedirectToAction (nameof (Index));
            }

            return RedirectToAction (nameof (Index));
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
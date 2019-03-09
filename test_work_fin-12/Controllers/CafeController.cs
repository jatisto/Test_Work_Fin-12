using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test_work_fin_12.Data;
using test_work_fin_12.Interface;
using test_work_fin_12.Models;
using test_work_fin_12.ViewModels;

namespace test_work_fin_12.Controllers {

    [Authorize]
    public class CafeController : Controller {
        // private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly ICafeRepository _cafeRepository;
        private readonly FileUploadService _fileUploadService;
        private readonly IHostingEnvironment _appEnvironment;
        private AppDbContext _context;

        public CafeController (
            ICafeRepository cafeRepository,
            IHostingEnvironment appEnvironment,
            FileUploadService fileUploadService,
            UserManager<User> userManager,
            AppDbContext context) {
            // _userRepository  = userRepository;
            _cafeRepository = cafeRepository;
            _context = context;
            _appEnvironment = appEnvironment;
            _fileUploadService = fileUploadService;
            _userManager = userManager;
        }
        public IActionResult Index () {
            return View ();
        }
        public ViewResult List () {
            var userId = _userManager.GetUserId (User);
            ViewBag.Name = "Cafe";
            CafeVM vm = new CafeVM ();
            vm.CafeListVM = _cafeRepository.CafesList.Where (u => u.UserId == userId);
            return View (vm);
        }

        [HttpGet]
        public IActionResult NewCafe () {
            var cafe = new Cafe ();
            return View (cafe);
        }

        [HttpPost]
        public IActionResult NewCafe (Cafe cafe) {
            var userId = _userManager.GetUserId (User);
            var model = new Cafe {
                Name = cafe.Name,
                Description = cafe.Description,
                UserId = userId,
                Score = cafe.Score,
                Image = cafe.Image,
                Content = cafe.Content
            };

            if (model.Image != null) {
                UploadPhoto (model);
            } else {
                model.ImageUrl = "https://img.pravda.ru/image/article/1/4/2/381142.jpeg?ts=1514200685";
            }
            _cafeRepository.Create (model);
            return RedirectToAction ("List");
        }

        public IActionResult Rating (string id, int rating) {
            var userId = _userManager.GetUserId (User);
            var ratingGet = _cafeRepository.GetSingleCafeById (id);
            ratingGet.Score = rating;
            _cafeRepository.Edit (ratingGet);
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult ContentList (string id, string content) {
            var userId = _userManager.GetUserId (User);
            var ratingGet = _cafeRepository.GetSingleCafeById (id);
            ratingGet.Content = content;
            _cafeRepository.Edit (ratingGet);
            return RedirectToAction ("Index", "Home");
        }

        public IActionResult Details (string id) {
            var cafe = _cafeRepository.GetSingleCafeById (id);
            return View (cafe);
        }

        public IActionResult Delete (string id) {
            var cafe = _cafeRepository.GetSingleCafeById (id);
            _cafeRepository.Delete (cafe);
            return View ();
        }

        #region UploadPhoto

        private void UploadPhoto (Cafe cafe) {
            var path = Path.Combine (_appEnvironment.WebRootPath, $"images\\{cafe.Name}\\image");
            _fileUploadService.Upload (path, cafe.Image.FileName, cafe.Image);
            cafe.ImageUrl = $"images/{cafe.Name}/image/{cafe.Image.FileName}";
        }
        #endregion
    }
}
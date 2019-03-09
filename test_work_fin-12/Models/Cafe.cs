using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using test_work_fin_12.Data;
using test_work_fin_12.Models;
using test_work_fin_12.ViewModels;

namespace test_work_fin_12.Models {
    public class Cafe : Entity {

        public string Name { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}
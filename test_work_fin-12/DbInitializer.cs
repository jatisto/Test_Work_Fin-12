using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using test_work_fin_12.Data;
using test_work_fin_12.Models;

namespace test_work_fin_12 {
    public class DbInitializer {
        public static void Seed (AppDbContext context) {

            if (!context.Cafes.Any ()) {
                context.AddRange (
                    new Cafe {
                        Name = "Cafe1",
                            Description = "Кафе которое хочеться посетить",
                            ImageUrl = "~/Images/1.jpg",
                            Score = 3,
                            UserId = "5b5081c9-aea9-4132-be6a-485e38fbbf45"
                    },
                    new Cafe {
                        Name = "Cafe2",
                            Description = "Кафе которое хочеться посетить дважды",
                            ImageUrl = "~/Images/2.jpg",
                            Score = 5,
                            UserId = "88dfac06-e36d-4c7f-ac3c-f6c1c4b6fdd5"
                    },
                    new Cafe {
                        Name = "Cafe3",
                            Description = "Кафе которое хочеться посетить трижды",
                            ImageUrl = "~/Images/3.jpg",
                            Score = 7,
                            UserId = "9db442b6-5beb-4c4f-9d2b-ef77d629c648"
                    },
                    new Cafe {
                        Name = "Cafe4",
                            Description = "Отличное кафе",
                            ImageUrl = "~/Images/4.jpg",
                            Score = 3,
                            UserId = "373a57cf-a69a-409a-8508-0817644f3467"
                    },
                    new Cafe {
                        Name = "Cafe5",
                            Description = "This is Good",
                            ImageUrl = "~/Images/5.jpg",
                            Score = 9,
                            UserId = "be14eaa2-318f-480b-8278-08a53b380a49"
                    },
                    new Cafe {
                        Name = "Cafe6",
                            Description = "Кафе Eat",
                            ImageUrl = "~/Images/6.jpg",
                            Score = 10,
                            UserId = "5b5081c9-aea9-4132-be6a-485e38fbbf45"
                    }

                );
                context.SaveChangesAsync ();
            }

        }
    }
}
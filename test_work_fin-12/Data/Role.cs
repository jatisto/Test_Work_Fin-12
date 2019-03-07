using Microsoft.AspNetCore.Identity;

namespace test_work_fin_12.Data {
    public class Role {
        public static class IdentityDataInit {
            public static void SeedData (
                RoleManager<IdentityRole> roleManager) {
                SeedRoles (roleManager);
            }

            public static void SeedRoles
                (RoleManager<IdentityRole> roleManager) {

                    if (!roleManager.RoleExistsAsync ("User").Result) {
                        IdentityRole role = new IdentityRole ();
                        role.Name = "User";
                        IdentityResult roleResult = roleManager.CreateAsync (role).Result;
                    }
                }
        }
    }
}
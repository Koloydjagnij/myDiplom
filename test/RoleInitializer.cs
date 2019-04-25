using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "1qaz@WSX";
            //админ
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            // связываем аккаунт админа с ролью
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            //просмотр списка абитуриентов
            if (await roleManager.FindByNameAsync("ListAbitur") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("ListAbitur"));
            }
            //Добавление нового абитуриента
            if (await roleManager.FindByNameAsync("AddAbitur") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("AddAbitur"));
            }
            //Просмотр полной информации об абитуриенте
            if (await roleManager.FindByNameAsync("FullDetailAbitur") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("FullDetailAbitur"));
            }
            //Просмотр редактирование информации об абитуриенте
            if (await roleManager.FindByNameAsync("EditAbitur") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("EditAbitur"));
            }
            //Просмотр удаление абитуриента
            if (await roleManager.FindByNameAsync("DeleteAbitur") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("DeleteAbitur"));
            }
            //пользак обыкновенный
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            /*
            //секретарь
            if (await roleManager.FindByNameAsync("Secretary") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Secretary"));
            }
            //главный секретарь
            if (await roleManager.FindByNameAsync("ChiefSecretary") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("ChiefSecretary"));
            }
            */
        }
    }
}

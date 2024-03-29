using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        services
            .AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddRoleStore<RoleStore<IdentityRole<Guid>, ApplicationDbContext, Guid>>()
            .AddUserStore<UserStore<User, IdentityRole<Guid>, ApplicationDbContext, Guid>>()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;
            options.User.AllowedUserNameCharacters =
                "0123456789";
        });
    }
}

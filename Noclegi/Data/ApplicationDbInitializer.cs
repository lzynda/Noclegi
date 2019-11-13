﻿using System.Linq;
using Noclegi.Helpers;
using Noclegi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Noclegi.Data

{
    public class ApplicationDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationDbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Seed()
        {
            // create database + apply migrations
            _context.Database.Migrate();

            // add example roles
            if (!_context.Roles.Any())
            {
                var roleNames = new[]
                {
                    RoleHelper.Administrator,
                    RoleHelper.Moderator,
                    RoleHelper.User
                };

                foreach (var roleName in roleNames)
                {
                    var role = new IdentityRole(roleName) { NormalizedName = RoleHelper.Normalize(roleName) };
                    _context.Roles.Add(role);
                }
            }

            // add administrator account
            if (!_context.ApplicationUsers.Any())
            {
                const string userName = "admin@admin.com";
                const string userPass = "admin";

                var user = new ApplicationUser { UserName = userName, Email = userName };
                _userManager.CreateAsync(user, userPass).Wait();
                _userManager.AddToRoleAsync(user, RoleHelper.Administrator).Wait();
            }

            _context.SaveChanges();
        }
    }
}

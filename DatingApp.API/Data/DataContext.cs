using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        /// <summary>
        /// To create the initial database setup into database
        /// dotnet ef migrations add InitialCreate
        /// To update the Context and create database file in proj
        /// dotnet ef database update
        /// </summary>
        /// <value></value>
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users{get;set;}

    }
}
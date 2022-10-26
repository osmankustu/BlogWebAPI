using Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak için kullanılır.
    public class BlogContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=95.70.220.175;Database=BlogDatabase;user id=SystemArch;pwd=Developer15; trusted_connection = false");
        }

        public DbSet<Article> Article_Tbl  { get; set; }
        public DbSet<Category> Category_Tbl { get; set; }
        public DbSet<Yonetici> Yonetici_Tbl { get; set; }
        public DbSet<Comment> Comment_Tbl  { get; set; }    
        public DbSet<About> About_Tbl { get; set; }
        public DbSet<Contact> Contact_Tbl   { get; set; }   

    }
}

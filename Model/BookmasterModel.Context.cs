﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookMaster.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookmasterEntities : DbContext
    {
        public BookmasterEntities()
            : base("name=BookmasterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookCover> BookCover { get; set; }
        public DbSet<BookSubject> BookSubject { get; set; }
        public DbSet<Circulation> Circulation { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Cover> Cover { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}

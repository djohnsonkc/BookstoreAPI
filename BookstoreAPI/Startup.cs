using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using BookstoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // registers the in-memory database
            services.AddDbContext<BookstoreContext>(opt => opt.UseInMemoryDatabase());

            // Add framework services.
            services.AddMvc();

            // register the repository with the DI container
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // get the context and use it to add some faked data
            var context = app.ApplicationServices.GetService<BookstoreContext>();
            AddTestData(context);

            app.UseMvc();
        }

        private static void AddTestData(BookstoreContext context)
        {

            context.Books.Add(new Book
            {
                Title = "Where the Red Fern Grows",
                Description = "Where the Red Fern Grows is a 1961 children's novel...",
                PublishedMonth = 0,
                PublishedDay = 0,
                PublishedYear = 1961,
                CoverImageUrl = "//via.placeholder.com/100x100"
            });

            context.Books.Add(new Book
            {
                Title = "Another Book",
                Description = "...",
                PublishedMonth = 4,
                PublishedDay = 1,
                PublishedYear = 1975,
                CoverImageUrl = "//via.placeholder.com/100x100"
            });


            context.Authors.Add(new Author
            {
                FirstName = "Wilson",
                LastName = "Rawls",
                HeadshotImageUrl = "//via.placeholder.com/100x100"
            });

            context.Authors.Add(new Author
            {
                FirstName = "Mark",
                LastName = "Twain",
                HeadshotImageUrl = "//via.placeholder.com/100x100"
            });

            context.Authors.Add(new Author
            {
                FirstName = "John",
                LastName = "Smith",
                HeadshotImageUrl = "//via.placeholder.com/100x100"
            });

            context.BookAuthors.Add(new BookAuthor
            {
                BookID = 1,
                AuthorID = 1
            });

            context.BookAuthors.Add(new BookAuthor
            {
                BookID = 1,
                AuthorID = 2
            });

            context.BookAuthors.Add(new BookAuthor
            {
                BookID = 2,
                AuthorID = 3
            });

            context.Reviews.Add(new Review
            {
                BookID = 1,
                ReviewerName = "John Smith",
                ReviewContent = "Great book!",
                Rating = 5,
                DatePublished = new DateTime()
            });

            context.Reviews.Add(new Review
            {
                BookID = 1,
                ReviewerName = "Bill Jones",
                ReviewContent = "One of the best classics, but sad :-(",
                Rating = 4,
                DatePublished = new DateTime()
            });

            context.SaveChanges();
        }


    }
}

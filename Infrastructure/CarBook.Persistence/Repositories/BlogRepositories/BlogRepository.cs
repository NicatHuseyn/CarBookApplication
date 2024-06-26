﻿using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetLast3BlogWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x=>x.Id).Take(3).ToList();
            return values;
        }

		List<Blog> IBlogRepository.GetAllBlogsWihtAuthors()
		{
            var values = _context.Blogs.Include(x=>x.Author).ToList();
            return values;
		}

        public async Task<List<Blog>> GetBlogByAuthorIdAsync(int id)
        {
            var values = await _context.Blogs.Include(x=>x.Author).Where(y=>y.Id == id).ToListAsync();
            return values;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _db;

        public CommentRepository(ApplicationDBContext context)
        {
            _db = context;
        }
        public Task<List<Comment>> GetAllAsync()
        {
            return _db.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _db.Comments.FindAsync(id);
        }

    }
}
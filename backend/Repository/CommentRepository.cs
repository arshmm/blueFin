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
            return _db.Comments.Include(c => c.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _db.Comments.Include(c => c.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {

            var commentModel = await _db.Comments.FindAsync(id);

            if (commentModel == null)
            {
                return null;
            }

            commentModel.Content = comment.Content;
            commentModel.Title = comment.Title;

            await _db.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _db.Comments.FindAsync(id);

            if (commentModel == null)
            {
                return null;
            }

            _db.Comments.Remove(commentModel);
            await _db.SaveChangesAsync();

            return commentModel;
        }

    }
}
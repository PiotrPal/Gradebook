using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Infrastructure.Repositoires {
    internal class StudentRepository : IStudentRepository {
        private GradebookDbContext _dbContext;

        public StudentRepository(GradebookDbContext dbContext) {
            _dbContext = dbContext;
        }

        //get all async -> przeniesione do readonly

        public async Task<Student> GetByIDAsync(int id, CancellationToken cancellation = default) {
            return await _dbContext.Students.SingleOrDefaultAsync(s => s.ID == id, cancellation);
        }

        public  async Task<Student> GetByEmailAsync(string email, CancellationToken cancellation = default) {
            return await _dbContext.Students.SingleOrDefaultAsync(s => s.Email == email, cancellation);
        }

        public Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellation = default) {
            return _dbContext.Students.AnyAsync(s => s.Email == email, cancellation);
        }

        public void Add(Student student) {
            _dbContext.Students.Add(student);
        }

        public void Update(Student student) {
            _dbContext.Students.Update(student);
        }

        public void Delete(Student student) {
            _dbContext.Students.Remove(student);
        }
    }
}

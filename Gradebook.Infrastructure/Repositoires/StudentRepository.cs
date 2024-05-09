using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Infrastructure.Repositoires {
    internal class StudentRepository : IStudentRepository {

        public Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellation = default) {
            throw new NotImplementedException();
        }

        public Task<Student> GetByIDAsync(int id, CancellationToken cancellation = default) {
            throw new NotImplementedException();
        }

        public Task<Student> GetByEmailAsync(string email, CancellationToken cancellation = default) {
            throw new NotImplementedException();
        }

        public Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellation = default) {
            throw new NotImplementedException();
        }

        public void Add(Student student) {
            throw new NotImplementedException();
        }

        public void Update(Student student) {
            throw new NotImplementedException();
        }

        public void Delete(Student student) {
            throw new NotImplementedException();
        }
    }
}

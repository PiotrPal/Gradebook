using Gradebook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Domain.Abstractions {
    public interface IStudentRepository {
        // metody wykonujace operacje na encji student
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellation = default);
        Task<Student> GetByIDAsync(int id, CancellationToken cancellation = default);
        Task<Student> GetByEmailAsync(string email, CancellationToken cancellation = default);
        Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellation = default);
        //manipulowanie danymi
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}

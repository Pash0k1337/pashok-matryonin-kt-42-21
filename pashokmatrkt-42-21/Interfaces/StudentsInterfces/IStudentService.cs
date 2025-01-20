using pashokmatrkt_42_21.DB;
using pashokmatrkt_42_21.Filter.StudentFilters;
using pashokmatrkt_42_21.Models;
using Microsoft.EntityFrameworkCore;


namespace pashokmatrkt_42_21.Interfaces.StudentsInterfces
{  
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByLastNameAsync(StudentLastNameFilter filter, CancellationToken cancellationToken);
    }

public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
            return students;
        }
        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.FirstName == filter.FirstName).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudentsByLastNameAsync(StudentLastNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.LastName == filter.LastName).ToArrayAsync(cancellationToken);

            return students;
        }
    }
}

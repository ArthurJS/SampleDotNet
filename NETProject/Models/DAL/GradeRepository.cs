using System.Data.Entity;
using System.Linq;
using NETProject.Models.Domain;

namespace NETProject.Models.DAL
{
    public class GradeRepository : IRepository<Grade>
    {
        private DbSet<Grade> Grades;
        private Context context;
        
        public GradeRepository(Context context)
        {
            this.context = context;

            Grades = this.context.Grades;
        }

        public GradeRepository()
        {
            // TODO: Complete member initialization
        }

        public IQueryable<Grade> FindAll()
        {
            return Grades;
        }

        public Grade FindById(int id)
        {
            return Grades.Find(id);
        }
    }
}
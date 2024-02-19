using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastacture.InfrastructureBases;
using SchoolProject.Infrastacture.Repository;
using SchoolProject.Infrustructure.Abstracts;

namespace SchoolProject.Infrustructure.Repositories
{
    public class InstructorsRepository : GenericRepositoryAsync<Instructor>, IInstructorsRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;
        #endregion

        #region Constructors
        public InstructorsRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            instructors=dbContext.Set<Instructor>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}

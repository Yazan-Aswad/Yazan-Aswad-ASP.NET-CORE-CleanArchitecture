using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastacture.InfrastructureBases;
using SchoolProject.Infrastacture.Repository;
using SchoolProject.Infrustructure.Abstracts;


namespace SchoolProject.Infrustructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private DbSet<Department> departments;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            departments=dbContext.Set<Department>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}

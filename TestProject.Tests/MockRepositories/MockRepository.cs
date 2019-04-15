using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using TestProject.Data.Entities;
using TestProject.Repositories;

namespace TestProject.Tests.MockRepositories
{
    public class MockRepository<TEntity, TRepository>
        where TRepository : class, IRepository<TEntity>
        where TEntity : IIdentifiedEntity
    {
        public virtual TRepository Items { get; set; }

        protected Mock<TRepository> MockRepo { get; set; }

        protected IQueryable<TEntity> QueryableCollection { get; set; }

        protected virtual void Setup()
        {
            MockRepo.Setup(mr => mr.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync((long id) => QueryableCollection.FirstOrDefault(x => x.Id == id));

            MockRepo.Setup(mr => mr.Delete(It.IsAny<TEntity>()))
                .Callback<TEntity>(x => QueryableCollection = QueryableCollection.Where(e => e.Id != x.Id));

            MockRepo.Setup(mr => mr.DeleteAsync(It.IsAny<long>()))
                .Callback<long>(id => QueryableCollection = QueryableCollection.Where(e => e.Id != id))
                .ReturnsAsync(true);

            MockRepo.Setup(mr => mr.GetAll(null)).Returns(QueryableCollection);

            MockRepo.Setup(mr => mr.Add(It.IsAny<TEntity>()))
                .Callback<TEntity>(x => QueryableCollection = QueryableCollection.AsEnumerable().Concat(new[] { x }).AsQueryable());

            MockRepo.Setup(mr => mr.AnyAsync(It.IsAny<Expression<Func<TEntity, bool>>>()))
                .ReturnsAsync((Expression<Func<TEntity, bool>> expr) => QueryableCollection.Any(expr.Compile()));

            MockRepo.Setup(mr => mr.CountAsync(It.IsAny<Expression<Func<TEntity, bool>>>()))
                .ReturnsAsync((Expression<Func<TEntity, bool>> expr) => QueryableCollection.Count(expr.Compile()));

            MockRepo.Setup(mr => mr.CountAsync())
                .ReturnsAsync(() => QueryableCollection.Count());

            Items = MockRepo.Object;
        }
    }
}

namespace BlogSite.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public Task CommitAsync();
        public void Commit();
    }
}

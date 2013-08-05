using System.Linq.Expressions;

namespace MoqDemo
{
    public interface IWorkRepository
    {
        void Save(Work entity);
        Work Get(int id);
    }

    public class FakeWorkRepository : IWorkRepository
    {
        public void Save(Work entity)
        {
            throw new System.NotImplementedException();
        }

        public Work Get(int id)
        {
            return new Work() {Description = "aaa"};
        }
    }
}
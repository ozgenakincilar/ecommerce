using System.Collections.Generic;

namespace NS.Business
{
    public interface IRepository<T, TKey>
    {
        IList<T> List();

        T Load(TKey id);

        void Delete(TKey id);

        void Update(T instance);

        void Create(T instance);
    }
}

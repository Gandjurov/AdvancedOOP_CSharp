using System;

namespace SurviceProvider
{
    public interface IServiceCollection
    {
        void AddService<TImplementation, TClass>();

        object CreateInstance(Type type);

        TClass CreateInstance<TClass>();
    }
}

using System;

namespace SurviceProvider
{
    public interface IServiceCollection
    {
        void AddService<TImplementation, TClass>();

        void CreateInstance<TImplementation>();


    }
}

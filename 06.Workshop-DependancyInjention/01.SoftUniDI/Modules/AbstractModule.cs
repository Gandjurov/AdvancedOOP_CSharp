using SoftUniDI.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI.Modules
{
    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;
        private readonly IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        public object GetInstance(Type type)
        {
            throw new NotImplementedException();
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            throw new NotImplementedException();
        }

        public void SetInstance(Type implementation, object instance)
        {
            throw new NotImplementedException();
        }

        private void CreateMapping<TInterface, TImplementation>()
        {
            if (!this.implementations.ContainsKey(typeof(TInterface)))
            {
                this.implementations[typeof(TInterface)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInterface)].Add(typeof(TImplementation).Name, typeof(TImplementation));


        }
    }
}

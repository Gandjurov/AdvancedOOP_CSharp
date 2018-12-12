using SoftUniDI.Attributes;
using SoftUniDI.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniDI.Injectors
{
    public class Injector
    {
        private readonly IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);

            if (desireClass == null)
            {
                return default(TClass);
            }

            var constructors = desireClass.GetConstructors();

            foreach (var constructorInfo in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                var inject = constructorInfo.GetCustomAttributes<InjectAttribute>(true)
                                            .FirstOrDefault();
                var parameterTypes = constructorInfo.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                int i = 0;

                foreach (var parameterInfo in parameterTypes)
                {
                    var named = parameterInfo.GetCustomAttribute<NamedAttribute>();
                    Type dependancy = null;

                    if (named == null)
                    {
                        dependancy = this.module.GetMapping(parameterInfo.ParameterType, inject);
                    }
                    else
                    {
                        dependancy = this.module.GetMapping(parameterInfo.ParameterType, named);
                    }

                    if (parameterInfo.ParameterType.IsAssignableFrom(dependancy))
                    {
                        var instance = this.module.GetInstance(dependancy);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependancy);
                            constructorParams[i++] = instance;
                            this.module.SetInstance(parameterInfo.ParameterType, instance);
                        }
                        else
                        {
                            constructorParams[i++] = instance;
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            var fields = desireClass.GetFields((BindingFlags)62);

            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.GetCustomAttributes<InjectAttribute>(true).Any())
                {
                    var injection = fieldInfo.GetCustomAttributes<InjectAttribute>(true)
                                             .FirstOrDefault();

                    Type dependancy = null;

                    var named = fieldInfo.GetCustomAttribute<NamedAttribute>(true);
                    var type = fieldInfo.FieldType;

                    if (named == null)
                    {
                        dependancy = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependancy = this.module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependancy))
                    {
                        var instance = this.module.GetInstance(dependancy);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependancy);
                            this.module.SetInstance(dependancy, instance);
                        }

                        fieldInfo.SetValue(desireClassInstance, instance);
                    }
                }
            }

            return (TClass)desireClassInstance;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags)62)
                                 .Any(c => c.GetCustomAttributes<InjectAttribute>(true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors((BindingFlags)62)
                                 .Any(c => c.GetCustomAttributes<InjectAttribute>(true).Any());
        }
    }
}

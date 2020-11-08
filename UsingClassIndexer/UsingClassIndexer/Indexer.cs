using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsingClassIndexer
{
    public static class Indexer
    {
        public static object GetPropertyOrMethod(this object classToGet, string name)
        {
            var property = GetProperty(classToGet, name);
            var method = GetMethod(classToGet, name);

            if (property != null)
            {
                return property.GetValue(classToGet);
            }
            else if (method != null)
            {
                return method;
            }
            return null;
        }

        public static PropertyInfo GetProperty(object classToGet, string name)
        {
            return classToGet.GetType().GetProperty(name);
        }

        public static MethodInfo GetMethod(object classToGet, string name)
        {
            return classToGet.GetType().GetMethod(name);
        }

        public static void SetProperty(this object classToGet, string name, params object[] args)
        {
            PropertyInfo property = GetProperty(classToGet, name);

            if (property != null)
            {
                MethodInfo setMethod = property.GetSetMethod();

                if (setMethod != null)
                {
                    setMethod.Invoke(classToGet, args);
                }
                else throw new NullReferenceException();
            }
            else throw new NullReferenceException();
        }
    }
}

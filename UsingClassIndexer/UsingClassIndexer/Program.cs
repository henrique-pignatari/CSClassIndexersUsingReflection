using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsingClassIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithIndexers indexedClass = new ClassWithIndexers();

            string name = "property";
            indexedClass[name] = 50;

            Console.WriteLine(indexedClass[name]);

            name = "Method";

            MethodInfo method = indexedClass[name] as MethodInfo;
            
            Console.WriteLine(method.Invoke(indexedClass, new object[] { }));

            Console.ReadLine();
        }

        public class ClassWithIndexers
        {
            public int property { get; set; }
            private int property2 { get; set; }

            public ClassWithIndexers()
            {
                property = 45;
                property2 = 93;
            }

            public int Method()
            {
                return 60;
            }

            public object this[string name]
            {
                get
                {                   
                    var propertyOrMethod = this.GetPropertyOrMethod(name);

                    if (propertyOrMethod != null)
                    {
                        return propertyOrMethod;
                    }
                    else throw new NullReferenceException();
                }

                set
                {
                    this.SetProperty(name, value);
                }
            }
        }
    }
}
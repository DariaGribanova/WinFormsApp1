using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsApp1
{
    public class AssembleyAdapter
    {
        private readonly Assembly assembly;

        public AssembleyAdapter(string dllPath)
        {
            assembly = Assembly.LoadFrom(dllPath);
        }

        public List<string> GetClassNamesByInterfaceType(string typeName)
        {
            var classNames = new List<string>();
            Type interfaceType = assembly.GetType(typeName);
            foreach (Type type in assembly.GetTypes())
            {
                if (interfaceType.IsAssignableFrom(type) && !type.IsAbstract)
                {
                    classNames.Add(type.FullName);
                }
            }
            return classNames;
        }

        public Type GetClassType(string typeName)
        {
            return assembly.GetType(typeName);
        }
    }
}

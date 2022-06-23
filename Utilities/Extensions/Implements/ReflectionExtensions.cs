namespace Utilities.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class ReflectionExtensions
    {
        /// <summary>
        /// Returns the property value of a specific object, converted to the Type <typeparamref name="O"/> specified.
        /// </summary>
        /// <typeparam name="O">Value type resulting from conversion</typeparam>
        /// <param name="property">The object with overload method.</param>
        /// <param name="nameProperty">The string containing the name of the public property to get.</param>
        /// <returns>The property value of .</returns>
        public static O GetValueOnPropertyByName<O>(this object property, string nameProperty)
        {
            return (O)property.GetType().GetProperty(nameProperty).GetValue(property);
        }

        public static MethodInfo GetMethodsBySignature(this Type type, string nameMethod, Type returnType, params Type[] parameterTypes)
        {
            return type.GetMethods().Where(x => x.Name.Equals(nameMethod)).FirstOrDefault(m =>
             {
                 if (m.Name.NotEquals(nameMethod)) return false;
                 if (m.ReturnType != returnType) return false;

                 ParameterInfo[] parameters = m.GetParameters();

                 if ((parameterTypes == null || parameterTypes.Length == 0))
                     return parameters.Length == 0;
                 if (parameters.Length != parameterTypes.Length)
                     return false;
                 for (int i = 0; i < parameterTypes.Length; i++)
                 {
                     if (parameters[i].ParameterType != parameterTypes[i])
                         return false;
                 }
                 return true;
             });
        }
    }
}

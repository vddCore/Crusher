using System.Reflection;

namespace Crusher.Infrastructure
{
    internal static partial class Extensions
    {
        public static T AddNew<T>(this List<T> list) where T: class
        {
            var type = typeof(T);
            var ret = type.GetConstructor(
                BindingFlags.Public 
                | BindingFlags.NonPublic 
                | BindingFlags.Instance,
                null, 
                Type.EmptyTypes,
                null
            )!.Invoke(null);
            
            list.Add((T)ret);
            return (T)ret;
        }
    }
}
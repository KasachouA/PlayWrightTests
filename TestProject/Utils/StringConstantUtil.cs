using System.Reflection;

namespace CoreTestProject.Utils
{
    public static class StringConstantUtil
    {
        public static List<T> GetAllConstants<T>()
        {
            return typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => (T)x.GetValue(typeof(T))).ToList();
        }
    }
}

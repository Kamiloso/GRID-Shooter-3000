using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace GridShooter
{
    public interface IGlobalSingleton<T> where T : MonoBehaviour
    {
        public static T Instance => _instance;
        private static T _instance; // set by reflection during initialization
    }

    public class EternalScript : MonoBehaviour
    {
        private static EternalScript _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateOnStart()
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("EternalScript");
                _instance = obj.AddComponent<EternalScript>();
                SpawnUnitySingletons(obj);
                DontDestroyOnLoad(obj);
            }
        }

        private static void SpawnUnitySingletons(GameObject obj)
        {
            var interfaceType = typeof(IGlobalSingleton<>);
            var assembliesToSearch = new[]
            {
                typeof(EternalScript).Assembly, // default assembly
            };

            var types = assembliesToSearch
                .SelectMany(assembly =>
                {
                    try
                    {
                        return assembly.GetTypes();
                    }
                    catch
                    {
                        return Array.Empty<Type>();
                    }
                })
                .Where(t => typeof(MonoBehaviour).IsAssignableFrom(t) && !t.IsAbstract)
                .Where(t => t.GetInterfaces()
                    .Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == interfaceType &&
                        i.GenericTypeArguments[0] == t))
                .ToList();

            foreach (var type in types)
            {
                var iface = typeof(IGlobalSingleton<>).MakeGenericType(type);
                MonoBehaviour spawnedInstance = (MonoBehaviour)obj.AddComponent(type);
                var instanceField = iface.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
                instanceField.SetValue(null, spawnedInstance); // set private singleton _instance
            }
        }
    }
}

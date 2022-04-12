using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Dictionary<Type, IManager> managersDictionary = new Dictionary<Type, IManager>();

    public static void RegisterManager<T>(T manager) where T : IManager {
        if (managersDictionary.ContainsKey(manager.GetType())) {
            Debug.LogWarning($"{manager.GetType()} already added.");
            return;
        }
        managersDictionary[manager.GetType()] = manager;
    }

    public static T GetManager<T>() where T : class, IManager {
        if (managersDictionary.ContainsKey(typeof(T))) {
            return (T)managersDictionary[typeof(T)];
        }
        return null;
    }
}

public interface IManager {

}

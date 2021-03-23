using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameHolder
{
    public static PrefabsManager PrefabsManager { get; set; }
}

public class PrefabsManager : MonoBehaviour
{
    public PrefabCatalog prefabs;

    void Awake()
    {
        prefabs = new PrefabCatalog();
        GameHolder.PrefabsManager = this;
        DontDestroyOnLoad(this.gameObject);
    }
}

[System.Serializable]
public class PrefabCatalog
{
    const string path = "Prefabs";

    public Dictionary<string, GameObject> prefabs;
    public GameObject[] prefabsArray;

    public PrefabCatalog()
    {
        prefabs = new Dictionary<string, GameObject>();
        prefabsArray = Resources.LoadAll<GameObject>(path);
        foreach (var prefab in prefabsArray)
        {
            prefabs.Add(prefab.name, prefab);
        }
    }

    public GameObject GetObject(string name)
    {
        GameObject gameObject;
        if (prefabs.TryGetValue(name, out gameObject)) { }
        else
        {
            Debug.LogError($"No item \"{name}\" at path \"{path}\" was found");
        }
        return gameObject;
    }

    public T GetObject<T>(string name) where T : MonoBehaviour
    {
        return GetObject(name).GetComponent<T>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Examples;
using GameSparks.Core;

/// <summary>
/// Repository of commonly used prefabs.
/// </summary>
[AddComponentMenu("Gameplay/ObjectPool")]
public class GameObjectPool : MonoBehaviour
{

    public static GameObjectPool instance { get; private set; }

    #region member
    /// <summary>
    /// Member class for a prefab entered into the object pool
    /// </summary>
    [Serializable]
    public class ObjectPoolEntry
    {
        /// <summary>
        /// the object to pre instantiate
        /// </summary>
        [SerializeField]
        public GameObject Prefab;

        /// <summary>
        /// quantity of object to pre-instantiate
        /// </summary>
        [SerializeField]
        public int Count;
    }
    #endregion

    /// <summary>
    /// The object prefabs which the pool can handle
    /// by The amount of objects of each type to buffer.
    /// </summary>
    public ObjectPoolEntry[] Entries;

    /// <summary>
    /// The pooled objects currently available.
    /// Indexed by the index of the objectPrefabs
    /// </summary>
    [HideInInspector]
    public List<GameObject>[] Pool;

    public List<GameObject> spawnlist;
	public GameObject spawnContainer;
	private GameObject ContainerObject; 

    /// <summary>
    /// The container object that we will keep unused pooled objects so we dont clog up the editor with objects.
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void OnEnable()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        ContainerObject = new GameObject();
        DontDestroyOnLoad(ContainerObject);

        //Loop through the object prefabs and make a new list for each one.
        //We do this because the pool can only support prefabs set to it in the editor,
        //so we can assume the lists of pooled objects are in the same order as object prefabs in the array
        Pool = new List<GameObject>[Entries.Length];

        for (int i = 0; i < Entries.Length; i++)
        {
            var objectPrefab = Entries[i];

            //create the repository
            Pool[i] = new List<GameObject>();

            //fill it
            for (int n = 0; n < objectPrefab.Count; n++)
            {
                    var newObj = Instantiate(objectPrefab.Prefab) as GameObject;
                    DontDestroyOnLoad(newObj);
                    newObj.name = objectPrefab.Prefab.name;
                    PoolObject(newObj);
            }
        }
    }



    /// <summary>
    /// Gets a new object for the name type provided.  If no object type exists or if onlypooled is true and there is no objects of that type in the pool
    /// then null will be returned.
    /// </summary>
    /// <returns>
    /// The object for type.
    /// </returns>
    /// <param name='objectType'>
    /// Object type.
    /// </param>
    /// <param name='onlyPooled'>
    /// If true, it will only return an object if there is one currently pooled.
    /// </param>
    public GameObject GetObjectForType(string objectType,AbstractMap Map,string name, double lat, double lon, double height, int material, float hp, float blockY)
    {

        for (int i = 0; i < Entries.Length; i++)
        {
            var prefab = Entries[i].Prefab;

            if (prefab.name != objectType)
                continue;
			
            if (Pool[i].Count > 0)
            {
                GameObject pooledObject = Pool[i][0];
                Pool[i].RemoveAt(0);
				pooledObject.transform.SetParent(spawnContainer.transform, false);


                pooledObject.SetActiveRecursively(true);
				var llpos = new Vector2d(lat, lon);
				var pos = Conversions.GeoToWorldPosition(llpos, Map.CenterMercator, Map.WorldRelativeScale);
				//Vector3 pos = new Vector3(x, y, z);
				
                if(objectType == "Pin"){pooledObject.transform.position = new Vector3((float)pos.x,0f,(float)pos.y);}
				//if(objectType == "Stack1x1x1"){pooledObject.transform.position = new Vector3((float)pos.x,blockY,(float)pos.y);}
                //heading
                //float h = Mathf.Lerp(360, 0, heading / 255f);
                //					pooledObject.transform.eulerAngles.y = h;
                //pooledObject.transform.localEulerAngles = new Vector3(0, h, 0);
                //if (NPC == 0) { size = 1.4f; pooledObject.transform.localScale = new Vector3(size, size, size); }
                //if (NPC == 1) { pooledObject.transform.localScale = new Vector3((size / 4f), (size / 4f), (size / 4f)); }
                //pooledObject.name = name + ":" + prefab.name;
				pooledObject.GetComponent<PinController>().Map = Map;
                pooledObject.GetComponent<PinController>().name = name;
				pooledObject.GetComponent<PinController>().prefabName = objectType;
				pooledObject.GetComponent<PinController>().lat = lat;
				pooledObject.GetComponent<PinController>().lon = lon;
				pooledObject.GetComponent<PinController>().height = height;
				pooledObject.GetComponent<PinController>().material = material;
				pooledObject.GetComponent<PinController>().hp = hp;
				pooledObject.GetComponent<PinController>().blockY = blockY;

                spawnlist.Add(pooledObject);

                return pooledObject;
            }
        }

        //If we have gotten here either there was no object of the specified type or non were left in the pool with onlyPooled set to true
        return null;
    }

    /// <summary>
    /// Pools the object specified.  Will not be pooled if there is no prefab of that type.
    /// </summary>
    /// <param name='obj'>
    /// Object to be pooled.
    /// </param>
    public void PoolObject(GameObject obj)
    {

        for (int i = 0; i < Entries.Length; i++)
        {
            if (Entries[i].Prefab.name != obj.name)
                continue;

            obj.SetActiveRecursively(false);

            obj.transform.SetParent(ContainerObject.transform, false);
			ContainerObject.name = "Pooled Objects";
            //DontDestroyOnLoad(ContainerObject);
            Pool[i].Add(obj);

            return;
        }
    }
}



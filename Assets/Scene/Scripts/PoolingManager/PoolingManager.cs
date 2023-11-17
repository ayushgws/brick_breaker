using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
	private static PoolingManager instance;
	public List<PoolingObject> ObjectList;

	public static PoolingManager Instance()
	{
		return instance;
	}

	private void Awake()
	{
		instance = this;
	}

    private void Start()
    {
        CreatePoolList();
    }

    public GameObject GetPrefab(string Name)
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			//Selecting correct poolist via prefab.name
			if (ObjectList[i].name == Name)
			{
				PoolingObject PoolObject = ObjectList[i];

				//loop for searching inactive gameobject in poollist
				for (int j = 0; j < PoolObject.poolList.Count; j++)
				{
					if (!PoolObject.poolList[j].activeInHierarchy)
					{
						return PoolObject.poolList[j];
					}
				}
				//Instantiate new prefab if all prefab is active
				GameObject TempPrefab = Instantiate(PoolObject.prefab);
				TempPrefab.SetActive(false);
				PoolObject.poolList.Add(TempPrefab);
				return TempPrefab;

				//Returning inactive prefab in both case
			}
		}
		//Return null if name doesnt match
		return null;
	}

    public void CreatePoolList()
	{
		for (int i = 0; i < ObjectList.Count; i++)
		{
			PoolingObject PoolObject = ObjectList[i];
            
            for (int j = 0; j < PoolObject.count; j++)
			{
                GameObject TempPrefab = Instantiate(PoolObject.prefab);
				TempPrefab.SetActive(false);
				PoolObject.poolList.Add(TempPrefab);
			}
		}
	}

}

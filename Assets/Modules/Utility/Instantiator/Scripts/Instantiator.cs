using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectList;

    private void Awake()
    {
        for(int i=0;i< gameObjectList.Count; i++)
        {
            Instantiate(gameObjectList[i],new Vector3(0,0,0),Quaternion.identity);
        }
        Destroy(gameObject);
    }

}

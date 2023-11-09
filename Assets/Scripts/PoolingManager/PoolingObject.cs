using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolingObject 
{
    public string name;
    public int count;
    public GameObject prefab;
    

    public List<GameObject> poolList;

}

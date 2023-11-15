using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArranger : MonoBehaviour
{

    [SerializeField] private List<AspectRatios> aspectRatioList;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 camPos = transform.position;
        camPos.y -= .7f;
        transform.position = camPos;
        Debug.Log("   " + Camera.main.aspect);

        for (int i = 0; i < aspectRatioList.Count; i++)
        {

            if (aspectRatioList[i].aspect >= Camera.main.aspect)
            {
                Camera.main.orthographicSize = aspectRatioList[i].size;

            }
        }

    }

}

[System.Serializable]
public class AspectRatios
{
    public float aspect;
    public float size;
}
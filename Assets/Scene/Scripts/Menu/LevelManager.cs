using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Button btnClose;

    [SerializeField] private int levelCount;
    [SerializeField] private string levelNamePrefix;

    [SerializeField] private GameObject levelContainer;
    [SerializeField] private GameObject levelButtonPrefab;

    private List<GameObject> levelList = new List<GameObject>();

    private void Start()
    {
        btnClose.onClick.AddListener(Close);

        for(int i =1;i<=levelCount; i++) 
        {
           GameObject levelObj =  Instantiate(levelButtonPrefab, levelContainer.transform);
           levelObj.GetComponent<LevelButton>().SetLevelName(levelNamePrefix + i);
           levelList.Add(levelObj);
        }
    }

    private void Close()
    {
        MenuController.Instance().OpenHome();
    }
}

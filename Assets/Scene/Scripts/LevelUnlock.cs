using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUnlock : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockedLevelsNumber;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("levelsUnlocked"))
        { 
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

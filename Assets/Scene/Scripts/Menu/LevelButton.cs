using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    private Button button;
    [SerializeField] private Image star1;
    [SerializeField] private Image star2;
    [SerializeField] private Image star3;

    private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenLevel);
    }

    private void OpenLevel()
    {
        SceneLoader.Instance().OpenLevel(levelName);
    }

    public void SetLevelName(string levelName)
    {
        this.levelName = levelName;
    }

    public void SetStarCount(int count)
    {
        star1.color = Color.red;
        star2.color = Color.green;
        star3.color = Color.blue;
    }
}

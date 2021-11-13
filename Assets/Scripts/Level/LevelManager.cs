using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    int levelLock;
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        levelLock = PlayerPrefs.GetInt("LevelLock", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < levelLock; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

}

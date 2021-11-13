using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public GameObject levelCompletedText;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            levelCompletedText.SetActive(true);
            Debug.Log("Level finished by the player");
            Invoke("LoadNextLevel", 3f);
        }
    }

    void LoadNextLevel()
    {
        levelCompletedText.SetActive(false);

        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentLevelIndex >= PlayerPrefs.GetInt("levelLock"))
        {
            PlayerPrefs.SetInt("levelLock", currentLevelIndex + 1);

            //for go to next level
            SceneManager.LoadScene(currentLevelIndex + 1);
        }
    }

}

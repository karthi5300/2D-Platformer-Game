using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public GameObject levelCompletedText;
    public GameObject player;
    public GameObject gameCompletedImage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            levelCompletedText.SetActive(true);
            Invoke("LoadNextLevel", 3f);
        }
    }

    void LoadNextLevel()
    {
        levelCompletedText.SetActive(false);

        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentLevelIndex == 5)
        {
            gameCompletedImage.SetActive(true);
        }

        int nextLevelIndex = currentLevelIndex + 1;
        PlayerPrefs.SetInt("levelLock", nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }

}

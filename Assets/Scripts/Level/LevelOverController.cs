using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletedText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameCompletedImage;
    [SerializeField] private AudioClip levelCompletionSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            levelCompletedText.SetActive(true);
            SoundManager.Instance.Play(levelCompletionSound);
            Invoke("LoadNextLevel", 3f);
        }
    }

    void LoadNextLevel()
    {
        levelCompletedText.SetActive(false);

        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentLevelIndex == 6)
        {
            gameCompletedImage.SetActive(true);
        }

        int nextLevelIndex = currentLevelIndex + 1;
        PlayerPrefs.SetInt("levelLock", nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }

}

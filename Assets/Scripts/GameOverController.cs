using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;

    void Awake()
    {
        buttonRestart.onClick.AddListener(RestartLevel);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}

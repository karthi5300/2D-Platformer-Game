using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button buttonRestart;
    [SerializeField] private AudioClip restartLevelSound;

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
        SoundManager.Instance.Play(restartLevelSound);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}

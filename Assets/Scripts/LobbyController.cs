using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{

    public void PlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }

}

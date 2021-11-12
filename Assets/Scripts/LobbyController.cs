using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject levelSelection;

    void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        levelSelection.SetActive(true);
    }

}

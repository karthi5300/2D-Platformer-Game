using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject levelSelection;

    public AudioClip lobbyMusic;

    void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        SoundManager.Instance.PlayMusic(lobbyMusic);
    }

    public void PlayGame()
    {
        levelSelection.SetActive(true);
    }

}

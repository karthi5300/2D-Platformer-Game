using System.Collections;
using System.Collections.Generic;
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
            Invoke("LoadNextLevel", 3f);
        }
    }

    void LoadNextLevel()
    {
        levelCompletedText.SetActive(false);
        SceneManager.LoadScene(2);
    }

}

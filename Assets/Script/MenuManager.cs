using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject stinktext;
    public GameObject videoRaw;
    public GameObject VideoPlay;
    public void StartMenu()
    {
        pauseMenu.SetActive(true);
        FindAnyObjectByType<PlayerMovement>().enabled = false;
        stinktext.SetActive(false);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0f;
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Openveideo()
    {
        StartCoroutine(Waitvideo());
        
    }
    IEnumerator Waitvideo()
    {
        videoRaw.SetActive(true);
        VideoPlay.SetActive(true);
        yield return new WaitForSeconds(8);
        videoRaw.SetActive(false);
        videoRaw.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
}

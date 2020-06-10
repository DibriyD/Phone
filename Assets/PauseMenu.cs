using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Game_paused;
    int high_score;
    public GameObject player;
    public GameObject pauseUI;
    public GameObject Are_you_sure;
    // Start is called before the first frame update
    public void Start()
    {
        player.GetComponent<Pl_move>().enabled = true;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        player.GetComponent<Pl_move>().enabled = false;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Exit()
    {
        //if (player.GetComponent<Pl_move>().score > PlayerPrefs.GetInt("High_score", 10))
        //{
        //    PlayerPrefs.SetInt("High_score", player.GetComponent<Pl_move>().score);
        //}
    //    Are_you_sure.SetActive(true);
        Application.Quit();
    }
}
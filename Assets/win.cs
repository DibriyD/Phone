using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    int score;
    public GameObject winn;
    public GameObject pause;
    public Text current;
    public Text best;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Pl_move>().score += 10;
            score = col.gameObject.GetComponent<Pl_move>().score;
            winn.SetActive(true);
            pause.SetActive(false);
            Time.timeScale =0f;
            
            if (score >= PlayerPrefs.GetInt("High_score"))
            {
             
                best.text = score.ToString();
                current.text = score.ToString();
                PlayerPrefs.SetInt("High_score",score);
            }else if(score <= PlayerPrefs.GetInt("High_score"))
            {
                best.text = PlayerPrefs.GetInt("High_score").ToString();
                current.text = score.ToString();
                
            }
            col.gameObject.GetComponent<Pl_move>().score= 0;
        }
       
       
    }
}

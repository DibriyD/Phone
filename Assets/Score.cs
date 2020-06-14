using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    private void Start()
    {
       score.text = PlayerPrefs.GetInt("High_score").ToString();
        //PlayerPrefs.SetInt("High_score",0);
        //score.text = PlayerPrefs.GetInt("High_score").ToString(); 
    }
   
}

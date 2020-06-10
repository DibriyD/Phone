using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_off : MonoBehaviour
{
    float time;
    public GameObject pl;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    void Awake()
    {
        time = 2f;
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time > 0)
            pl.GetComponent<Pl_move>().enabled = false;
        if (time <= 0)
        {
            pl.GetComponent<Pl_move>().enabled = true;
            this.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public GameObject player;
    AudioManager audio_wind;
    AreaEffector2D area;
   public float time = 5;
    public float reload = 5;
    public float newTime = 5;
    public float newReload = 5;
    public float forseMagnitude = 9;
    bool on=true;
    
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<AreaEffector2D>();
        audio_wind = FindObjectOfType<AudioManager>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        float distance = Mathf.Abs(player.transform.position.y - transform.position.y);
    
        if (distance<4.5)
        {
            time -= Time.deltaTime;
            if (time >= 0 && on == true)
            {
                audio_wind.Play("Wind");
                on = false;
            }
            if (time <= 0)
            {

                this.GetComponent<SpriteRenderer>().enabled = false;
                area.forceMagnitude = 0;
                reload -= Time.deltaTime;
                if (reload <= 0)
                {

                    this.GetComponent<SpriteRenderer>().enabled = true;
                    area.forceMagnitude = 9;
                    if (area.forceAngle == 0)
                        area.forceAngle = 180;
                    else if (area.forceAngle == 180)
                        area.forceAngle = 0;
                    time = newTime;
                    reload = newReload;
                    on = true;
               
                }

            }
         
        }
    }
 
}

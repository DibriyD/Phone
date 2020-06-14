using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
     public AudioManager audio_player;
    Animator anim;
   // float delay = 1f;

    void Start()
    {
        anim = transform.GetComponent<Animator>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
          
        if (col.gameObject.tag == "Player")
        {
            audio_player.Play("Coin");
            anim.SetBool("collected", true);
            col.gameObject.GetComponent<Pl_move>().score += 1;
            Destroy(gameObject, 0.5f);


        }

    }

  
}

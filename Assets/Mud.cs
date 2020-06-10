using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    float height_change = 7f;
    float gravity_change = 0.5f;
    float player_h = 15;
    float play_grav = 2;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            //gravity = 0.6f;
            //max_h = 6;
            //jump_h = 1f;
            col.transform.GetComponent<Pl_move>().max_h = height_change;
            col.transform.GetComponent<Pl_move>().gravity = gravity_change;
         
        }
        //else if (col.gameObject.tag != "Mud")
        //{
        //    gravity = gravityChange;
        //    max_h = maxHChange;
        //    jump_h = jumpHChange;
        //}
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.GetComponent<Pl_move>().max_h = player_h;
            col.transform.GetComponent<Pl_move>().gravity = play_grav;
           
        }
    }

}
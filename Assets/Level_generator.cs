using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_generator : MonoBehaviour
{
    public GameObject[] rooms;
    public Transform[] lvl_pos;
    public Transform pl;

    

 
    void Start()
    {
      
            foreach (Transform i in lvl_pos)
            {
                 Instantiate(rooms[Random.Range(0, rooms.Length)], i.transform.position, Quaternion.identity);
               
            }

    }    
        

        void Add()
        {
            Instantiate(this, new Vector3(this.transform.position.x, this.transform.position.y + 23, this.transform.position.z), Quaternion.identity);
        }
    
}


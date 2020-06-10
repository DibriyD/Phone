using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  //  SpriteRenderer screen;
    public Transform pl;
    [SerializeField]
    float camera_bound=4;
    float camera_changePos = 7;
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
      //  float orth_size = screen.bounds.size.x + Screen.height / Screen.width * 0.5f;
      //  Camera.main.orthographicSize = orth_size;
    }
    void LateUpdate()
    {
        if (transform.position.y + camera_bound < pl.transform.position.y)
            transform.position = new Vector3(transform.position.x,transform.position.y+
                camera_changePos,transform.position.z);
        else if(transform.position.y - camera_bound > pl.transform.position.y)
            transform.position = new Vector3(transform.position.x, 
                transform.position.y + (camera_changePos*(-1)),
               transform.position.z);
    }
}


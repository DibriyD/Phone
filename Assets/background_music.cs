using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_music : MonoBehaviour
{
     AudioManager audio_back;
    [SerializeField] string music;
    // Start is called before the first frame update

        void Start()
        {
        audio_back = FindObjectOfType<AudioManager>();
        }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            audio_back.Play(music);
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            audio_back.Stop(music);
        }
    }
}

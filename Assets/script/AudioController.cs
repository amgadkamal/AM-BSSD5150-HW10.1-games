using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour
{
  
    

    public AudioMixerSnapshot exploring;
    public  AudioMixerSnapshot battling;
    public AudioSource stingSound;
    public AudioSource lose;
    private float transitionTime = 1f;
    
    
    

 

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "BattleZone")
        {
            battling.TransitionTo(transitionTime);
            stingSound.Play();
        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)

    { 
        string collideTag = collision.gameObject.tag;
        if (collideTag == "lose") 
            //play lose track
        {battling.TransitionTo(transitionTime);
            lose.Play();
        }
    }
    


    private void OnTriggerExit(Collider2D collision)
    {
        if (collision.tag == "BattleZone")
        { exploring.TransitionTo(transitionTime); }
        
        if (collision.tag == "lose")
        {
            exploring.TransitionTo(transitionTime); }
    }


}

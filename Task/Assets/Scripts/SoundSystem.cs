using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    private AudioSource finish;
    private AudioSource transferGem;
    private AudioSource background;

   
    void Start()
    {
        
        finish = GetComponent<AudioSource>();
        transferGem = GetComponents<AudioSource>()[1];
        background = GetComponents<AudioSource>()[2];

    }

    
    public AudioSource Finish
    {
        get { return finish; }
    }
    public AudioSource TransferGem
    {
        get { return transferGem; }
    }
    public AudioSource Background
    {
        get { return background; }
    }

}

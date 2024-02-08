using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    private AudioSource finish;
    private AudioSource transferGem;
    

    // Start is called before the first frame update
    void Start()
    {
        
        finish = GetComponent<AudioSource>();
        transferGem = GetComponents<AudioSource>()[1]; 

    }

    // Properties to access private variables
    public AudioSource Finish
    {
        get { return finish; }
    }
    public AudioSource TransferGem
    {
        get { return transferGem; }
    }


}

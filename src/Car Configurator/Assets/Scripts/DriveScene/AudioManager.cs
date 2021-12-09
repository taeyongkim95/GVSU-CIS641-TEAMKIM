using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip startupSound;

    [SerializeField]
    private AudioClip idleSound;

    [SerializeField]
    private AudioClip engineSound;

    private float audioVolume = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(startupSound, audioVolume);
        audioSource.clip = idleSound;
        audioSource.PlayDelayed(0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Vertical"))
        {
            audioSource.clip = engineSound;
        }
        else
        {
            audioSource.clip = idleSound;
        }


        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

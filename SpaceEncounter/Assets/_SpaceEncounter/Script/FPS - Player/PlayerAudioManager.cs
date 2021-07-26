using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public static PlayerAudioManager Instance { get; set; }

    [SerializeField] AudioSource gunAudioSource;

    [Header("Clips")]
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip run;
    [SerializeField] AudioClip shoot;
    
    AudioSource audioSource;
    Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = gunAudioSource.transform.GetComponent<Animator>();
        audioSource.clip = null;
    }

    private void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool horizontal = !Mathf.Approximately(Input.GetAxis("Horizontal"), 0.0f);
        bool vertical = !Mathf.Approximately(Input.GetAxis("Vertical"), 0.0f);

        if (isRunning == true && (horizontal || vertical)) //Running
        {
            audioSource.clip = run;
            audioSource.pitch = 1f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (isRunning == false && (horizontal || vertical)) //Walking
        {
            audioSource.clip = walk;
            audioSource.pitch = 1.3f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else //idle
        {
            audioSource.Stop();
        }

        if(animator.GetBool("IsShooting")) //isShooting
        {
            gunAudioSource.clip = shoot;
            gunAudioSource.pitch = 0.7f;
            if (!gunAudioSource.isPlaying)
                gunAudioSource.Play();
        }
        else
            gunAudioSource.Stop();
    }

}


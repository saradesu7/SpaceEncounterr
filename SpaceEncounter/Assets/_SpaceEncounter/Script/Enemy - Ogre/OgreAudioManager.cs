using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreAudioManager : MonoBehaviour
{
    [Header("Clips")]
    [SerializeField] AudioClip chase;
    [SerializeField] AudioClip die;
    [SerializeField] AudioClip powerattack;
    [SerializeField] AudioClip enrage;
    [SerializeField] AudioClip laugh;

    AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audioSource.clip = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("PowerAttack"))
        {
            audioSource.clip = powerattack;
            audioSource.pitch = 0.5f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}

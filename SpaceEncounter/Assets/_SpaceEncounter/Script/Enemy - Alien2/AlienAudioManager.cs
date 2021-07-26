using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAudioManager : MonoBehaviour
{
    [Header("Clips")]
    [SerializeField] AudioClip chase;
    [SerializeField] AudioClip die;
    [SerializeField] AudioClip shoot;
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
        StartCoroutine(Laugh());
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("InAttackShootRange") && animator.GetBool("CanShoot"))
        {
            audioSource.clip = shoot;
            audioSource.pitch = 0.8f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

        /*if (!animator.GetBool("InAttackShootRange") && !animator.GetBool("CanShoot") && !animator.GetBool("InAttackScratchRange") && !animator.GetBool("IsEnraged") && !animator.GetBool("IsDead"))
        {
            audioSource.clip = shoot;
            audioSource.pitch = 0.8f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }*/

        if (animator.GetBool("IsEnraged"))
        {
            audioSource.clip = enrage;
            audioSource.pitch = 1.1f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

    }

    IEnumerator Laugh()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            if (animator.GetBool("Enable"))
            {
                audioSource.clip = laugh;
                audioSource.pitch = 0.5f;
                audioSource.Play();
            }
            yield return new WaitForSeconds(1.8f);
            audioSource.Stop();

            if(animator.GetBool("IsDead"))
            {
                audioSource.clip = die;
                audioSource.pitch = 1f;
                audioSource.Play();
                yield return new WaitForSeconds(1.5f);
                audioSource.Stop();
                break;
            }

        }
    }

}

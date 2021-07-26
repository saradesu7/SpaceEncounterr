using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAudioManager : MonoBehaviour
{

    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] float fadein;
    [SerializeField] float fadeout;
    AudioSource audioSource;
    SpawnEnemier spawnEnemier;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        spawnEnemier = GetComponent<SpawnEnemier>();

        StartCoroutine(PlayMusic());
        StartCoroutine(StopMusic());
    }


    IEnumerator PlayMusic()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(Time.deltaTime);
            if (SpawnEnemier.AlienObjectPool[0].transform.GetChild(1).GetComponent<Animator>().GetBool("Enable"))
            {
                float startVolume = 0;
                while (audioSource.volume < 0.2)
                {
                    audioSource.volume += startVolume * Time.deltaTime / fadein;
                }
                audioSource.clip = backgroundMusic;
                audioSource.Play();
                audioSource.volume = 0.2f;
                break;
            }
        }
        yield return null;
        // onFinish();
    }

    IEnumerator StopMusic()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (spawnEnemier.ogreEnemy.GetComponent<Animator>().GetBool("Dead"))
            {
                float startVolume = audioSource.volume;
                while (audioSource.volume > 0)
                {
                    audioSource.volume -= startVolume * Time.deltaTime / fadeout;
                }
                audioSource.Stop();
                audioSource.volume = startVolume;
                break;
            }
        }
        yield return null;
        //onFinish();
    }
}

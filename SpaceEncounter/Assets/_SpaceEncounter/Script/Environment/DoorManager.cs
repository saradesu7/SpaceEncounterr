using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] Animator doorAnimator;

    [Header("Door Scan")]
    [SerializeField] GameObject DoorSignal1;
    [SerializeField] GameObject DoorSignal2;
    [SerializeField] GameObject DoorScanner1;
    [SerializeField] GameObject DoorScanner2;

    [Header("Door Scan Lights")]
    [SerializeField] GameObject RedLight;
    [SerializeField] GameObject GreenLight;

    [Header("Materials")]
    [SerializeField] Material green;
    [SerializeField] Material red;
    [SerializeField] Material blue;
    [SerializeField] Material glass;

    MeshRenderer signal1, signal2, scanner1, scanner2;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        signal1 = DoorSignal1.GetComponent<MeshRenderer>();
        signal2 = DoorSignal2.GetComponent<MeshRenderer>();
        scanner1 = DoorScanner1.GetComponent<MeshRenderer>();
        scanner2 = DoorScanner2.GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        //int playerLayer = 1 << 8;
        /*int enemyLayer = 1 << 9;*/

        RaycastHit hit;
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hit, 3) || Physics.Raycast(position, transform.TransformDirection(-Vector3.forward), out hit, 3))
        {
            if(!audioSource.isPlaying)
                audioSource.Play();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            doorAnimator.SetBool("character_nearby", true);
            signal1.material = green;
            signal2.material = green;
            scanner1.material = blue;
            scanner2.material = blue;
            RedLight.SetActive(false);
            GreenLight.SetActive(true);
        }
        else
        {
            Debug.DrawRay(position, transform.TransformDirection(Vector3.forward) * 1, Color.white);
            doorAnimator.SetBool("character_nearby", false);
            signal1.material = red;
            signal2.material = red;
            scanner1.material = glass;
            scanner2.material = glass;
            GreenLight.SetActive(false);
            RedLight.SetActive(true);
            audioSource.Stop();
        }
    }
}

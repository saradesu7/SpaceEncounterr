using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    //public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 0.1f;

    Vector3 originalPos;

    void Awake()
    {
        Instance = this;
        /*if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }*/
    }

    void OnEnable()
    {
        /*originalPos = camTransform.localPosition;*/
    }

    void Update()
    {
        /*if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }*/
    }
    public void Shake(Transform camTransform)
    {
        originalPos = camTransform.localPosition;
        while (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        //else
        {
            shakeDuration = 0.5f;
            camTransform.localPosition = originalPos;
        }
    }
}

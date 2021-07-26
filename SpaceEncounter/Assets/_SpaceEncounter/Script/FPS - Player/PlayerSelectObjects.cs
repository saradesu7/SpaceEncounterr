using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectObjects : MonoBehaviour
{
    [SerializeField] Camera cam;
    public bool selected = false;
    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
    // Start is called before the first frame update
    void Start()
    {
        _sensitivity = 0.4f;
        _rotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; 
        if (Input.GetMouseButton(0) && Physics.Raycast(cam.ScreenPointToRay( new Vector3( Screen.width / 2, Screen.height / 2, 0)), out hit, 10) && !selected && hit.collider.CompareTag("Selectable"))
        {
            /*{
                selected = true;
                Vector3 newPos = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y + 5, hit.collider.gameObject.transform.position.z);
                hit.collider.gameObject.transform.position = Vector3.Slerp(hit.collider.gameObject.transform.position, newPos, 0.2f);
            }*/

            hit.collider.gameObject.transform.parent = gameObject.transform.GetChild(2);
            hit.collider.gameObject.SetActive(false);
                
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleWalk : MonoBehaviour
{
    private float walkingBobbingSpeed = 10f;
    [SerializeField] private float bobbingAmount = 0.05f;
    [SerializeField] private CharacterMovement controller;

    float defaultPosY = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //HeadBob
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool horizontal = !Mathf.Approximately(Input.GetAxis("Horizontal"), 0.0f);
        bool vertical = !Mathf.Approximately(Input.GetAxis("Vertical"), 0.0f);

        if (isRunning == true && (horizontal || vertical)) //Running
        {
            walkingBobbingSpeed = 20f;
        }
        else if (isRunning == false && (horizontal || vertical)) //Walking
        {
            walkingBobbingSpeed = 14f;
        }
        else //idle
        {

        }

        if (Mathf.Abs(controller.moveDirection.x) > 0.1f || Mathf.Abs(controller.moveDirection.z) > 0.1f)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}

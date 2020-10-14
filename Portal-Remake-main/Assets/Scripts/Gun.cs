using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource portalSound;
    public AudioSource errorSound;
    public GameObject bluePortal;
    public GameObject orangePortal;
    public Transform firingPoint;

   // public object Q { get; private set; }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown())

        if (Input.GetMouseButtonDown(0))
        {
            FirePortal(false);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            FirePortal(true);
        }
    }

    void FirePortal(bool isOrange)
    {
        RaycastHit raycastHit;

        if(Physics.Raycast(firingPoint.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity))
        {
            portalSound.Play();
            if(isOrange)
            {
                orangePortal.transform.SetPositionAndRotation(raycastHit.point, Quaternion.FromToRotation(Vector3.forward, raycastHit.normal));
            }
            else
            {
                bluePortal.transform.SetPositionAndRotation(raycastHit.point, Quaternion.FromToRotation(Vector3.forward, raycastHit.normal));
            }
        }
        else
        {
            errorSound.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource portalSound;
    public AudioSource errorSound;
    public GameObject bluePortal;
    public GameObject orangePortal;
    public GameObject cube;
    public Camera cam;
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

        if (Physics.Raycast(firingPoint.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity))
        {          //&& raycastHit.collider.gameObject.name != "OrangePortal" && raycastHit.collider.gameObject.name != "BluePortal"
                   //&& raycastHit.collider.gameObject.GetComponent<Rigidbody>() == null
                   //&& raycastHit.collider.gameObject.tag != "noportal")
        
            portalSound.Play();
            if(isOrange == true)
            {
                orangePortal.transform.SetPositionAndRotation(raycastHit.point, Quaternion.FromToRotation(Vector3.forward, raycastHit.normal));
            }
            else
            {
                //if (raycastHit.collider.gameObject.name != "cube")
                //{
                    bluePortal.transform.SetPositionAndRotation(raycastHit.point, Quaternion.FromToRotation(Vector3.forward, raycastHit.normal));
               // }
                //else
                //{
                 //   cube.transform.SetPositionAndRotation(cam.transform.position, Quaternion.FromToRotation(Vector3.forward, raycastHit.normal));
               // }
            }
        }
        else
        {
            errorSound.Play();
        }
    }
}

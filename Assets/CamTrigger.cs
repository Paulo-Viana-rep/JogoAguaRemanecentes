using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public float Zoom;

    public float FollowSpeed;
    public float Xoffset;
    public float Yoffset;

    CameraController camController;
    // Start is called before the first frame update
    void Start()
    {
        camController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camController.Zoom = Zoom;
            camController.Xoffset = Xoffset;
            camController.Yoffset = Yoffset;
            camController.FollowSpeed = FollowSpeed;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camController.Zoom = camController.DefaultZoom;
            camController.Xoffset = camController.DefaultXoffset;
            camController.Yoffset = camController.DeffaultYoffset;
            camController.FollowSpeed = camController.DefaultFollowSpeed;
        }
    }

}

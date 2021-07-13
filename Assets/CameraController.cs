using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    public float DefaultFollowSpeed = 1;
    public float DefaultXoffset;
    public float DeffaultYoffset;
    public float DefaultZoom;


    public float FollowSpeed;
    public float Xoffset;
    public float Yoffset;
    public float Zoom;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharController>().gameObject;
        
        FollowSpeed = DefaultFollowSpeed;
        Xoffset = DefaultXoffset;
        Yoffset = DeffaultYoffset;
        Zoom = DefaultZoom;
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(
            player.transform.position.x + Xoffset, 
            player.transform.position.y + Yoffset, 
            Zoom);
        transform.position = Vector3.Lerp(transform.position, target, FollowSpeed * Time.deltaTime);
    }
}

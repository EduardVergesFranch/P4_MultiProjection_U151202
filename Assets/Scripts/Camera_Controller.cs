using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to make the camera follow the player
public class Camera_Controller : MonoBehaviour

{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

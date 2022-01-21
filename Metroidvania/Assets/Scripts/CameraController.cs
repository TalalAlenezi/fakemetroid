using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    public BoxCollider2D boundsBox;

    private float halfHieght, halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //at the start os a scene find the player

        halfHieght = Camera.main.orthographicSize;
        halfWidth = halfHieght * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(
               Mathf.Clamp( player.transform.position.x,boundsBox.bounds.min.x + halfWidth, boundsBox.bounds.max.x - halfWidth), 
               Mathf.Clamp( player.transform.position.y,boundsBox.bounds.min.y + halfHieght, boundsBox.bounds.max.y - halfHieght), 
                transform.position.z);
        }
    }
}

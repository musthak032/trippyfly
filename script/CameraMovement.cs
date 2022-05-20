using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;

    Vector3 move;
    // Update is called once per frame
    void Update()
    {

        move = new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        transform.position += move;

        //transform.Translate(Vector3.right*cameraSpeed*Time.deltaTime);

    }
    private void FixedUpdate()
    {
     
        
    }

}

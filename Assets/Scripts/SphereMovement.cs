using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var startingPosition = this.transform.position;
        var deltaPosition = speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A))
        {
            startingPosition.x -= deltaPosition;
        }
        if (Input.GetKey(KeyCode.D))
        {
            startingPosition.x += deltaPosition;
        }
        if (Input.GetKey(KeyCode.W))
        {
            startingPosition.z += deltaPosition;
        }
        if (Input.GetKey(KeyCode.S))
        {
            startingPosition.z -= deltaPosition;
        }

        this.transform.position = startingPosition;
    }
}

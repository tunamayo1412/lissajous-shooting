using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{

    float originspeed = 4;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = originspeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) speed = originspeed / 2;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed = originspeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}

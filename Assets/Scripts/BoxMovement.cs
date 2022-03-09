using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float direction = 0.01f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x > 19)
        {
            direction = -0.01f;
        }
        else if (transform.localPosition.x < 12)
        {
            direction = 0.01f;
        }

        transform.position = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z);
    }

}

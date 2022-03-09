using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingLeft;
    private float leftEdge;
    private float RightEdge;

    public void Awake()
    {

        leftEdge = transform.position.x - movementDistance;
        RightEdge = transform.position.x + movementDistance;

    }
    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                        transform.localScale = new Vector3(5, 5, 1); //skala postaci
            }
            else
            {
                movingLeft = false;
            }

        }
        else
        {
            if (transform.position.x < RightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(-5, 5, 1); //skala postaci
            }
            else
            {
                movingLeft = true;
            }

        }
    }


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }


    }


}

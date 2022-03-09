using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private int onBox;
    private float cooldown = -1;
    [SerializeField] private Transform box;
    [SerializeField] private Transform box2;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetAxis("Horizontal") > 0.01f)   // jeżeli ruch w poziomie jest większy niż 0.01f
        {
            transform.localScale = new Vector3(6, 6, 1); //skala postaci

        }
        else if (Input.GetAxis("Horizontal") < 0.01f) // jeżeli ruch w poziomie jest mniejszy  niż 0.01f
        {
            transform.localScale = new Vector3(-6, 6, 1);//skala postaci

        }


        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        anim.SetBool("run", Input.GetAxis("Horizontal") != 0);
        anim.SetBool("grounded", grounded);
        // print(onBox);


        if (onBox == 1 && Input.GetAxis("Horizontal") == 0)
        {
            transform.localPosition = new Vector3(box.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        if (onBox == 2 && Input.GetAxis("Horizontal") == 0)
        {
            transform.localPosition = new Vector3(box2.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }




        anim.SetBool("run", Input.GetAxis("Horizontal") != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed+cooldown);
        grounded = false;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "wall")
        {
            body.velocity = new Vector2(-Input.GetAxis("Horizontal") * 100, body.velocity.y);
        }

        if (collision.gameObject.tag == "box")
        {
            onBox = 1;
            grounded = true;
        }
        if (collision.gameObject.tag == "box2")
        {
            onBox = 2;
            grounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        // print("opuscil box");

        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "box2")
        {
            onBox = 0;
        }

    }

 


}

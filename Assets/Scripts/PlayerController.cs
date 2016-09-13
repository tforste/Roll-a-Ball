using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Called before rendering a frame
    //Where much of our game code will go
    void Update()
    {

    }

    public float speed;
    private Rigidbody rb;

    //Called on the first frame, often first frame of the game
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Called just before performing any physics calculations
    //Where our phsics cade will go
    //Moving ball by applying forces to the rigid body, this is physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    //Called by Unity when our object touched a trigger collider
    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
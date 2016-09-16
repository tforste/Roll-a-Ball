using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Called before rendering a frame
    //Where much of our game code will go
    void Update()
    {

    }

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    //Called on the first frame, often first frame of the game
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = string.Empty;
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
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
            winText.text = "You Win!";
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public float speed;

    public Button restart;

    public Text countText;
    public Text winText;

    AudioSource audio;
    public AudioClip trigger_audio;

    private bool lose;

    void Start()
    {
        count = 0; // initialize count for the collected objects
        rb = GetComponent<Rigidbody>(); // get rigid body
        audio = GetComponent<AudioSource>(); // get audio component
        SetCountText(); //Set up the counter text
        winText.text = "";
        lose = false;
    }

    void FixedUpdate() //move the player
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement);
        check_Lose(rb);

    }
    void check_Lose(Rigidbody rb) //check if the player have fallen
    {
        if (rb.position.y < -10)
        {
            winText.text = "You loose";
            rb.position = new Vector3(0.5f, 0.5f, 0.5f);
            lose = true;
        }
    }

    void OnTriggerEnter(Collider other) //when picking up a cube
    {
        if (other.gameObject.CompareTag("Pick_Up"))
        {
            other.gameObject.SetActive(false);
            audio.PlayOneShot(trigger_audio,0.7F);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() // updates de counter text with the number of objects collected
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win";
            restart.gameObject.SetActive(true);
            rb.isKinematic = true;
            rb.detectCollisions = false;
      
        }
    }
    void LateUpdate()
    {
        if (lose == true)
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
            restart.gameObject.SetActive(true);
        }
    }
}

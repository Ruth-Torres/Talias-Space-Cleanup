using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D playerRb;

    public float hInput;
    public float vInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        playerRb.linearVelocity = new Vector2(hInput * speed, vInput * speed);
    }
}

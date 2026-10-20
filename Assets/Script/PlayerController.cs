using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isClicking;
    Vector2 impulse = new Vector2(0, 500f);
    Rigidbody2D playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(!isClicking)
            {
                isClicking = true;
            } 
            playerRb.linearVelocity = new Vector2(0, 0);
            playerRb.AddForce(impulse);
        }
    }
}

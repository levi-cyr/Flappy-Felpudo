using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isClicking;
    Vector2 impulse = new Vector2(0, 300f);
    Rigidbody2D playerRb;
    public float playerSpeed = 3f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Shoot();
    }
    void FixedUpdate()
    {
        PlayerMovement();
    }
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isClicking)
            {
                isClicking = true;
            }
            playerRb.linearVelocity = new Vector2(0, 0);
            playerRb.AddForce(impulse);
        }
    }

    void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        playerRb.linearVelocityX = horizontalMovement * playerSpeed;
    }
}

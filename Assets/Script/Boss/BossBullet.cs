using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D bulletRb;
    public float destroyLimitX = -10f;
    bool isExploding = false;
    Animator bulletAnim;
    public ShootWeapon shootWeaponScript;
    
    void Start()
    {
        bulletAnim = GetComponent<Animator>();
        bulletRb.linearVelocity = transform.right * speed;
    }

    IEnumerator BulletShootTimer() 
    {

    }
}

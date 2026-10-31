using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [Header("Scripts")]
    //public BossShootWeapon bossShootWeaponScript;

    [Header("Bullet Controller")]
    [SerializeField] float speed = 20f;
    [SerializeField] float destroyLimitX = -10f;
    bool isExploding = false;

    [Header("Components")]
    public Rigidbody2D bulletRb;
    Animator bulletAnim;

    void Start()
    {
        bulletAnim = GetComponent<Animator>();
        bulletRb.linearVelocity = transform.right * -speed;
    }

    void Update()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (isExploding)
        {
            return;
        }

        if (gameObject.transform.position.x < destroyLimitX)
        {
            Destroy(gameObject);
        }
    }

    void ExplodeAndDestroy() 
    {
        if (isExploding) 
        {
            return;
        }
        isExploding = true;
        bulletAnim.SetTrigger("explode");
        bulletRb.linearVelocity = Vector2.zero;

        Destroy(gameObject, 0.3f);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (isExploding) 
        {
            return;
        }

        if (hit.CompareTag("Limit")) 
        {
            ExplodeAndDestroy();
        }
    }
}

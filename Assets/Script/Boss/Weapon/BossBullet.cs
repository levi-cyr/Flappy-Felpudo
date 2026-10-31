using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [Header("Scripts")]
    //public BossShootWeapon bossShootWeaponScript;

    [Header("Bullet Controller")]
    [SerializeField] float speed = 20f;
    [SerializeField] float destroyLimitX = -10f;

    [Header("Components")]
    public Rigidbody2D bulletRb;


    void Start()
    {
        bulletRb.linearVelocity = transform.right * -speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float movementSpeed = 1f;

    float direction;

    private Animator animator;
    private Rigidbody2D rb;
    private HealthSystem playerHealth;
    private Transform playerTransform;
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<HealthSystem>().OnResourceEmpty += Mob_OnResourceEmpty;
        //animator = GetComponent<Animator>();
        //animator.SetInteger("Speed", Mathf.RoundToInt(rb.velocity.x));
    }
    private void Start()
    { 
        playerHealth = Player.Instance.GetComponent<HealthSystem>();
        playerTransform = Player.Instance.GetComponent<Transform>();
    }
    private void Mob_OnResourceEmpty(object sender, System.EventArgs e)
    {
        ItemEntity.Spawn(transform.position, Item.Apple, 1);
        Destroy(gameObject);
    }

    void Update()
    {
        direction = Mathf.Sign(playerTransform.position.x - transform.position.x);
        rb.velocity = Vector2.right * direction * movementSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject)
        {
            playerHealth.Decrease(damage);
        }
    }
}

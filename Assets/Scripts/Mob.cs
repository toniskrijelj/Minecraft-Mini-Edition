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
        rb.velocity = new Vector2(direction * movementSpeed, rb.velocity.y);
		transform.localScale = new Vector3(direction, 1, 1);
		if (Physics2D.Raycast(transform.position + new Vector3(-0.15f, -1.05f), Vector2.right, 0.3f, 1 << 8))
		{
			if(Physics2D.Raycast(transform.position + Vector3.right * direction, Vector2.up, 0.25f, 1 << 8))
			{
				rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(rb.gravityScale * -2f * 3f));
			}
		}
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject)
        {
            playerHealth.Decrease(damage);
        }
    }


}

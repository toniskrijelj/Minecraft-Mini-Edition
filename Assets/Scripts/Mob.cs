using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float movementSpeed = 1f;

    protected float direction;

    protected Rigidbody2D rb;
    protected HealthSystem playerHealth;
    protected Rigidbody2D playerRigidbody2D;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = Player.Instance.GetComponent<HealthSystem>();
		playerRigidbody2D = Player.Instance.GetComponent<Rigidbody2D>();
        GetComponent<HealthSystem>().OnResourceEmpty += Mob_OnResourceEmpty;
    }

    protected virtual void Mob_OnResourceEmpty(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }

	public static float SignClamp(float value, float sign, float min, float max)
	{
		if (sign > 0)
		{
			return Mathf.Min(value, max);
		}
		return Mathf.Max(value, min);
	}

	void Update()
    {
        direction = Mathf.Sign(playerRigidbody2D.position.x - transform.position.x);
        rb.velocity = new Vector2(SignClamp(rb.velocity.x + direction * movementSpeed * Time.deltaTime * 10, direction, direction * movementSpeed, direction * movementSpeed), rb.velocity.y);

		if (Physics2D.Raycast(transform.position + new Vector3(-0.15f, -1.05f), Vector2.right, 0.3f, 1 << 8))
		{
			if (Physics2D.Raycast(transform.position + Vector3.right * 0.25f * direction, Vector2.up, 0.3f, 1 << 8))
			{
				rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(rb.gravityScale * -2f * 1.5f));
			}
		}

		transform.localScale = new Vector3(direction, 1, 1);
    }

	float lastHitTime = 0;

    private void OnCollisionStay2D(Collision2D collision)
    {
		if (collision.gameObject == Player.Instance.gameObject)
		{
			if (lastHitTime + 1 < Time.time)
			{
				lastHitTime = Time.time;
				playerHealth.Decrease(damage);
				playerRigidbody2D.AddForce(new Vector3(direction * 100, 5), ForceMode2D.Impulse);
			}
		}
    }
}

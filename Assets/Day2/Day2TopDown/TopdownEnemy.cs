using UnityEngine;

public class TopdownEnemy : MonoBehaviour,IDamagable
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int speed = 20;
    private int currentHealth;
    private Transform target;
    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CombatTopdown>().TakeDamage(20);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage and current health is " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy died!");
            Destroy(gameObject);
        }
    }
}

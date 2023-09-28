using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public int damage = 100;

    private float time = 2.5f;

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IDamageableが実装されていれば
        if (collision.TryGetComponent<IDamageable>(out IDamageable iDamageable)) iDamageable.TakeDamage(damage);
    }
}

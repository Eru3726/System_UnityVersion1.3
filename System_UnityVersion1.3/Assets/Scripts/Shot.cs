using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField, Header("弾")]
    private GameObject bullet;

    [SerializeField, Header("弾のスピード")]
    private float bulletSpeed = 5f;

    [SerializeField, Header("弾のダメージ量")]
    private int damage = 100;

    public void Shoting()
    {
        var obj = Instantiate(bullet, transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
        obj.GetComponent<Bullet>().damage = damage;
    }
}

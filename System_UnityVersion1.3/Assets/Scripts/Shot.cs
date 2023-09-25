using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField, Header("�e")]
    private GameObject bullet;

    [SerializeField, Header("�e�̃X�s�[�h")]
    private float bulletSpeed = 5f;

    [SerializeField, Header("�e�̃_���[�W��")]
    private int damage = 100;

    public void Shoting()
    {
        var obj = Instantiate(bullet, transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
        obj.GetComponent<Bullet>().damage = damage;
    }
}

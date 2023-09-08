using UnityEngine;

public class EnemyGWC : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float speed;

    [SerializeField]
    private GroundWallChk groundWallChk = new GroundWallChk();

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = new Vector2(speed * groundWallChk.GWChk(), rb2d.velocity.y);
    }
}

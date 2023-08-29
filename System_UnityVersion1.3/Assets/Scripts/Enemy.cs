using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MoveLeftRight moveLR = new MoveLeftRight();

    private Rigidbody2D rb2d;

    [SerializeField]
    private float speed;

    [SerializeField]
    private MoveLeftRight moveLeftRight;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = new Vector2(speed * moveLeftRight.MoveChk(transform), rb2d.velocity.y);
    }
}

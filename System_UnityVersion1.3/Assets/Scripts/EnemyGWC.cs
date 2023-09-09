using UnityEngine;

public class EnemyGWC : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float speed;

    [SerializeField, Header("°”»’è‚ÌƒŒƒCİ’è")]
    private RayLine groundChk = new RayLine();

    [SerializeField,Header("•Ç”»’è‚ÌƒŒƒCİ’è")]
    private RayLine wallChk = new RayLine();

    private Transform myTransform;

    private Rigidbody2D rb2d;

    private float index = 1f;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = new Vector2(speed * index, rb2d.velocity.y);

        if (groundChk.LineChk() || wallChk.LineChk())
        {
            float scale = myTransform.localScale.x;
            scale *= -1;
            myTransform.localScale = new Vector3(scale, myTransform.localScale.y, myTransform.localScale.z);

            index *= -1;
        }
    }
}

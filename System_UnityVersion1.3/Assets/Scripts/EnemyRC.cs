using UnityEngine;

public class EnemyRC : MonoBehaviour
{
    [SerializeField, Header("ÉåÉCÇÃê›íË")]
    private RayCircle rayCircle = new RayCircle();

    private SpriteRenderer sr;
    private Color dColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        dColor = sr.color;
    }

    void Update()
    {
        GameObject obj = rayCircle.CircleChk();

        if(obj != null) sr.color = Color.red;
        else sr.color = dColor;
    }
}

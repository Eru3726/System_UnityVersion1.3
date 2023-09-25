using UnityEngine;

public class DamageTextSystem : MonoBehaviour
{
    public static DamageTextSystem instance;

    [SerializeField, Header("テキストの移動速度")]
    private float textSpeed = 1f;

    [SerializeField, Header("フェードアウトの速度")]
    private float fadeOutSpeed = 2f;

    [SerializeField, Header("テキストオブジェクト")]
    private TextMesh damageTextObj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    public void DamageText(int value,GameObject col)
    {
        var obj = Instantiate(damageTextObj, col.transform.position, Quaternion.identity);

        DamageTextUI dt = obj.GetComponent<DamageTextUI>();
        dt.fadeOutSpeed = fadeOutSpeed;
        dt.textSpeed = textSpeed;
        dt.damage = value;
    }
}

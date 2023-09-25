using UnityEngine;

public class DamageTextSystem : MonoBehaviour
{
    public static DamageTextSystem instance;

    [SerializeField, Header("�e�L�X�g�̈ړ����x")]
    private float textSpeed = 1f;

    [SerializeField, Header("�t�F�[�h�A�E�g�̑��x")]
    private float fadeOutSpeed = 2f;

    [SerializeField, Header("�e�L�X�g�I�u�W�F�N�g")]
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

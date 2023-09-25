using UnityEngine;

public class Enemy : MonoBehaviour , IDamageable
{
    public int Health => _health;

    [SerializeField, Header("�̗�")]
    int _health = 1000;

    /// <summary>
    /// �_���[�W�p�֐�
    /// </summary>
    /// <param name="value"></param>
    public void TakeDamage(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            // Health��0�ɂȂ����ꍇ�̏���
            Destroy(gameObject);
        }

        //�_���[�W�\��
        DamageTextSystem.instance.DamageText(value, this.gameObject);
    }
}

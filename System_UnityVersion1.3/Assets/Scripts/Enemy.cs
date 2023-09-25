using UnityEngine;

public class Enemy : MonoBehaviour , IDamageable
{
    public int Health => _health;

    [SerializeField, Header("体力")]
    int _health = 1000;

    /// <summary>
    /// ダメージ用関数
    /// </summary>
    /// <param name="value"></param>
    public void TakeDamage(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            // Healthが0になった場合の処理
            Destroy(gameObject);
        }

        //ダメージ表示
        DamageTextSystem.instance.DamageText(value, this.gameObject);
    }
}

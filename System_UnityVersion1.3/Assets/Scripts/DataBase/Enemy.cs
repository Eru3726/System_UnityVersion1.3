using System;
using UnityEngine;

//createから生成できるようにする
[Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "DataBase/CreateEnemy")]
public class Enemy : ScriptableObject
{
    public Type enemyType;              //種類
    public String enemyName;            //名前
    public Sprite enemySprite;          //画像
    public int enemyMaxHp;              //体力
    public int enemyOffensivePower;     //攻撃力
    public int enemyDefensePower;       //防御力
    public float enemySpeed;            //速度

    /// <summary>
    /// キャラの列挙
    /// </summary>
    public enum Type
    {
        //キャラを増やしたい場合はここに名前を追加する
        Slime,
        Zombie,
        Bat,
    }

    /// <summary>
    /// 変数を代入
    /// </summary>
    /// <param name="enemy"></param>
    public Enemy(Enemy enemy)
    {
        //変数を増やした場合はここで代入できるようにする
        this.enemyType = enemy.enemyType;
        this.enemyName = enemy.enemyName;
        this.enemySprite = enemy.enemySprite;
        this.enemyMaxHp = enemy.enemyMaxHp;
        this.enemyOffensivePower = enemy.enemyOffensivePower;
        this.enemyDefensePower = enemy.enemyDefensePower;
        this.enemySpeed = enemy.enemySpeed;
    }
}
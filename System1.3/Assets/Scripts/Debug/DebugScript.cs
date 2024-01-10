using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    public Text typeText, maxHpText, offensText, defnseText, speedText, resilienceText;

    private string type;
    private int maxHp, offens, defnse, resilience;
    private float speed;

    private bool s = true, z = false, b = false, sh = false, mh = false, lh = false;

    public Enemy slime,zombie,bad;
    public Item shp, mhp, lhp;

    void Update()
    {
        typeText.text = "Type：" + type;
        resilienceText.text = "Resilience：" + resilience;
        maxHpText.text = "MaxHp：" + maxHp.ToString();
        offensText.text = "Offens：" + offens.ToString();
        defnseText.text = "Defnse：" + defnse.ToString();
        speedText.text = "Speed：" + speed.ToString();

        if (s)
        {
            this.type = slime.enemyName;
            this.maxHp = slime.enemyMaxHp;
            this.offens = slime.enemyOffensivePower;
            this.defnse = slime.enemyDefensePower;
            this.speed = slime.enemySpeed;
            this.resilience = 0;
        }
        if (z)
        {
            this.type = zombie.enemyName;
            this.maxHp = zombie.enemyMaxHp;
            this.offens = zombie.enemyOffensivePower;
            this.defnse = zombie.enemyDefensePower;
            this.speed = zombie.enemySpeed;
            this.resilience = 0;
        }
        if (b)
        {
            this.type = bad.enemyName;
            this.maxHp = bad.enemyMaxHp;
            this.offens = bad.enemyOffensivePower;
            this.defnse = bad.enemyDefensePower;
            this.speed = bad.enemySpeed;
            this.resilience = 0;
        }
        if (sh)
        {
            this.type = shp.itemName;
            this.maxHp = 0;
            this.offens = 0;
            this.defnse = 0;
            this.speed = 0;
            this.resilience = shp.itemResilience;
        }
        if (mh)
        {
            this.type = mhp.itemName;
            this.maxHp = 0;
            this.offens = 0;
            this.defnse = 0;
            this.speed = 0;
            this.resilience = mhp.itemResilience;
        }
        if (lh)
        {
            this.type = lhp.itemName;
            this.maxHp = 0;
            this.offens = 0;
            this.defnse = 0;
            this.speed = 0;
            this.resilience = lhp.itemResilience;
        }
    }
    public void AllClear()
    {
        s = false;
        z = false;
        b = false;
        sh = false;
        mh = false;
        lh = false;
    }

    public void SlimeData()
    {
        AllClear();
        s = true;
    }

    public void ZombieData()
    {
        AllClear();
        z = true;
    }
    public void BadData()
    {
        AllClear();
        b = true;
    }
    public void SHPData()
    {
        AllClear();
        sh = true;
    }
    public void MHPData()
    {
        AllClear();
        mh = true;
    }
    public void LHPData()
    {
        AllClear();
        lh = true;
    }
}

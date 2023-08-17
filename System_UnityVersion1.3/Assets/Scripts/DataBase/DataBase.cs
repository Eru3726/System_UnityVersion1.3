using System.Collections.Generic;
using UnityEngine;

//create‚©‚ç¶¬‚Å‚«‚é‚æ‚¤‚É‚·‚é
[CreateAssetMenu(fileName = "DataBase", menuName = "DataBase/CreateDataBase")]
public class DataBase : ScriptableObject
{
    //ƒŠƒXƒg‚Ìì¬
    public List<Enemy> enemys = new List<Enemy>();
    public List<Item> items = new List<Item>();
}

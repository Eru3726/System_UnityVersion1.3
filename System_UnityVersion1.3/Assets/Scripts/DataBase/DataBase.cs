using System.Collections.Generic;
using UnityEngine;

//createから生成できるようにする
[CreateAssetMenu(fileName = "DataBase", menuName = "DataBase/CreateDataBase")]
public class DataBase : ScriptableObject
{
    //リストの作成
    public List<Enemy> enemys = new List<Enemy>();
    public List<Item> items = new List<Item>();
}

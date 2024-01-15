using UnityEngine;

//menuNameのSample1Dataのところは別の名前に変えてください
[CreateAssetMenu(menuName = "ScriptableObjects/Sample2Data")]
public class Sample2Data : ScriptableObject
{
    //実際にゲーム内で使う変数はこれ
    //変数名と型は自由
    public int int2Param;
    public float float2Param;
    public string string2Param;
    public bool bool2Param;
}


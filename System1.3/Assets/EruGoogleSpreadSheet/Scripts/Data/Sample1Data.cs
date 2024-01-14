using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Sample1Data")]
public class Sample1Data : ScriptableObject
{
    //実際にゲーム内で使う変数はこれ
    //変数名と型は自由
    public int int1Param;
    public float float1Param;
    public string string1Param;
    public bool bool1Param;
}


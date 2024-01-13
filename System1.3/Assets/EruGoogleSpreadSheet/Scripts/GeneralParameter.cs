using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GeneralParameter")]
public class GeneralParameter : ScriptableObject
{
    //実際にゲーム内で使う変数はこれ
    //変数名と型は自由
    public int intParam;
    public float floatParam;
    public string stringParam;
    public bool boolParam;
}


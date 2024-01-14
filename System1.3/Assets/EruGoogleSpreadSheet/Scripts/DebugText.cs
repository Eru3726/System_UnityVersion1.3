using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    [SerializeField]
    private Sample1Data sample1Data;  //GSSから受け取ったデータが入ったScriptableObject

    [SerializeField]
    private Sample2Data sample2Data;  

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Sample1Data\n" +
                    sample1Data.int1Param.ToString() + "\n" +
                    sample1Data.float1Param.ToString() + "\n" +
                    sample1Data.string1Param.ToString() + "\n" +
                    sample1Data.bool1Param.ToString() + "\n" +
                    "Sample2Data\n" +
                    sample2Data.int2Param.ToString() + "\n" +
                    sample2Data.float2Param.ToString() + "\n" +
                    sample2Data.string2Param.ToString() + "\n" +
                    sample2Data.bool2Param.ToString();
    }
}

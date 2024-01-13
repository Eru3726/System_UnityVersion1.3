using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    [SerializeField]
    private GeneralParameter generalParameter;  //GSSから受け取ったデータが入ったScriptableObject

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = generalParameter.intParam.ToString() + "\n" +
                    generalParameter.floatParam.ToString() + "\n" +
                    generalParameter.stringParam.ToString() + "\n" +
                    generalParameter.boolParam.ToString();
    }
}

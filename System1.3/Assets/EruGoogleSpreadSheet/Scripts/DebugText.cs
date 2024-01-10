using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    [SerializeField]
    private GeneralParameter generalParameter;

    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = generalParameter.param_0.ToString() + "\n" +
                    generalParameter.param_1.ToString() + "\n" +
                    generalParameter.param_2.ToString() + "\n" +
                    generalParameter.param_3.ToString() + "\n" +
                    generalParameter.param_4.ToString();
    }
}

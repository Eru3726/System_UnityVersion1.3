using UnityEngine;

[System.Serializable]
public class RayLine
{
    [SerializeField, Header("オブジェクトのトランスフォーム")]
    private Transform tr;

    [SerializeField, Header("チェックレイヤー")]
    private LayerMask chkLayer;

    [SerializeField, Header("レイの始点"), Tooltip("オブジェクトのトランスフォームを基準に設定")]
    private Vector3 startposition = new Vector3();

    [SerializeField, Header("レイの終点"), Tooltip("オブジェクトのトランスフォームを基準に設定")]
    private Vector3 endposition = new Vector3();

    [SerializeField, Header("レイの可視化")]
    private bool rayFlg = false;

    public bool LineChk()
    {
        if (tr == null) return false;
        // transform.localScaleの正負によってEnemyをx方向に反転する
        Vector3 scale = tr.localScale;

        // 始点が常にEnemyの進行方向に出るようにstartpositionを決める
        Vector3 str = tr.position + new Vector3(startposition.x * scale.x, startposition.y * scale.y, startposition.z * scale.z);

        // startpostionから足元までを終点とする
        Vector3 end = str + new Vector3(endposition.x * scale.x, endposition.y * scale.y, endposition.z * scale.z);

        // Debug用に始点と終点を表示する
        if (rayFlg) Debug.DrawLine(str, end, Color.red);

        // Physics2D.Linecastを使い、ベクトルとStageLayerが接触していたらTrueを返す
        return Physics2D.Linecast(str, end, chkLayer);
    }
}

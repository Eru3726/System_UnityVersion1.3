using UnityEngine;

[System.Serializable]
public class RayLine
{
    [SerializeField, Header("オブジェクトのトランスフォーム")]
    private Transform tr;

    [SerializeField, Header("チェックレイヤー")]
    private LayerMask chkLayer;

    private enum DIR_TYPE
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
    }
    [SerializeField, Header("レイの方向")]
    private DIR_TYPE dirType = DIR_TYPE.DOWN;

    [SerializeField, Header("レイの距離")]
    private float rayDis = 0.5f;

    [SerializeField, Header("レイの始点"),Tooltip("オブジェクトのトランスフォームを基準に設定")]
    private Vector3 vector3;

    [SerializeField, Header("レイの可視化")]
    private bool rayFlg = false;

    public bool LineChk()
    {
        // transform.localScaleの正負によってEnemyをx方向に反転する
        Vector3 scale = tr.localScale;

        Vector3 dir = new Vector3();
        if (dirType == DIR_TYPE.UP) dir += tr.up;
        else if (dirType == DIR_TYPE.DOWN) dir -= tr.up;
        else if (dirType == DIR_TYPE.RIGHT) dir += tr.right;
        else dir -= tr.right;

        // 始点が常にEnemyの進行方向に出るようにstartpositionを決める
        Vector3 startposition = tr.position + vector3 + dir * scale.x;

        // startpostionから足元までを終点とする
        Vector3 endposition = startposition + dir * rayDis;

        // Debug用に始点と終点を表示する
        if(rayFlg) Debug.DrawLine(startposition, endposition, Color.red);

        // Physics2D.Linecastを使い、ベクトルとStageLayerが接触していたらTrueを返す
        return Physics2D.Linecast(startposition, endposition, chkLayer);
    }
}

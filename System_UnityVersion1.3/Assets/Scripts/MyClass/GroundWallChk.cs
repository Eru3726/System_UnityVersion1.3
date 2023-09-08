using UnityEngine;

[System.Serializable]
public class GroundWallChk
{
    [SerializeField,Header("チェックレイヤー")]
    private LayerMask chkLayer;
    private float index = 1;

    public enum MOVE_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    [Header("移動状態")]
    public MOVE_TYPE moveType = MOVE_TYPE.RIGHT;

    public enum Chk_TYPE
    {
        NONE,
        GROUND,
        WALL,
        ALL,
    }
    [Header("チェック内容")]
    public Chk_TYPE chkType = Chk_TYPE.NONE;

    [SerializeField, Header("レイの始点")]
    private Transform tr;


    public float GWChk()
    {
        if(chkType == Chk_TYPE.NONE)
        {
            index = ChgDIrection();
        }
        if (chkType == Chk_TYPE.GROUND)
        {
            if (!GroundChk()) index = ChgDIrection();
        }
        else if (chkType == Chk_TYPE.WALL)
        {
            if (WallChk()) index = ChgDIrection();
        }
        else if (chkType == Chk_TYPE.ALL)
        {
            if (!GroundChk() || WallChk()) index = ChgDIrection();
        }

        return index;
    }

    private bool GroundChk()
    {
        // transform.localScaleの正負によってEnemyをx方向に反転する
        Vector3 scale = tr.localScale;
        // 始点が常にEnemyの進行方向に出るようにstartpositionを決める
        Vector3 startposition = tr.position + tr.right * 0.5f * scale.x;
        // startpostionから足元までを終点とする
        Vector3 endposition = startposition - tr.up * 0.55f;

        // Debug用に始点と終点を表示する
        Debug.DrawLine(startposition, endposition, Color.red);

        // Physics2D.Linecastを使い、ベクトルとStageLayerが接触していたらTrueを返す
        return Physics2D.Linecast(startposition, endposition, chkLayer);
    }

    private bool WallChk()
    {
        Vector3 scale = tr.localScale;

        Vector3 startposition = tr.position + tr.right * 0.3f * scale.x;

        Vector3 endposition = startposition + tr.right * 0.3f * scale.x;

        Debug.DrawLine(startposition, endposition, Color.blue);

        return Physics2D.Linecast(startposition, endposition, chkLayer);
    }

    // 方向転換をする
    private float ChgDIrection()
    {
        if (chkType != Chk_TYPE.NONE)
        {
            if (moveType == MOVE_TYPE.RIGHT) moveType = MOVE_TYPE.LEFT;
            else moveType = MOVE_TYPE.RIGHT;
        }
        float _index = 0;
        float scale = tr.localScale.x;
        if (moveType == MOVE_TYPE.STOP)
        {
            _index = 0;
        }
        else if (moveType == MOVE_TYPE.RIGHT)
        {
            scale = Mathf.Abs(scale);
            _index = 1; 
        }
        else if (moveType == MOVE_TYPE.LEFT)
        {
            scale = -Mathf.Abs(scale);
            _index = -1;
        }
        tr.localScale = new Vector3(scale, tr.localScale.y, tr.localScale.z);

        return _index;
    }
}

using UnityEngine;

[System.Serializable]
public class MoveLeftRight
{
    private LayerMask StageLayer = 1 << 18;
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


    public float MoveChk(Transform transform)
    {
        if(chkType == Chk_TYPE.NONE)
        {
            index = ChgDIrection(transform);
        }
        if (chkType == Chk_TYPE.GROUND)
        {
            if (!GroundChk(transform)) index = ChgDIrection(transform);
        }
        else if (chkType == Chk_TYPE.WALL)
        {
            if (WallChk(transform)) index = ChgDIrection(transform);
        }
        else if (chkType == Chk_TYPE.ALL)
        {
            if (!GroundChk(transform) || WallChk(transform)) index = ChgDIrection(transform);
        }

        return index;
    }

    private bool GroundChk(Transform transform)
    {
        // transform.localScaleの正負によってEnemyをx方向に反転する
        Vector3 scale = transform.localScale;
        // 始点が常にEnemyの進行方向に出るようにstartpositionを決める
        Vector3 startposition = transform.position + transform.right * 0.5f * scale.x;
        // startpostionから足元までを終点とする
        Vector3 endposition = startposition - transform.up * 0.55f;

        // Debug用に始点と終点を表示する
        Debug.DrawLine(startposition, endposition, Color.red);

        // Physics2D.Linecastを使い、ベクトルとStageLayerが接触していたらTrueを返す
        return Physics2D.Linecast(startposition, endposition, StageLayer);
    }

    private bool WallChk(Transform transform)
    {
        Vector3 scale = transform.localScale;

        Vector3 startposition = transform.position + transform.right * 0.3f * scale.x;

        Vector3 endposition = startposition + transform.right * 0.3f * scale.x;

        Debug.DrawLine(startposition, endposition, Color.blue);

        return Physics2D.Linecast(startposition, endposition, StageLayer);
    }

    // 方向転換をする
    private float ChgDIrection(Transform transform)
    {
        if (chkType != Chk_TYPE.NONE)
        {
            if (moveType == MOVE_TYPE.RIGHT) moveType = MOVE_TYPE.LEFT;
            else moveType = MOVE_TYPE.RIGHT;
        }
        float _index = 0;
        float scale = transform.localScale.x;
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
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);

        return _index;
    }
}

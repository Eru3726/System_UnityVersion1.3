using UnityEngine;

[System.Serializable]
public class RayLine
{
    [SerializeField, Header("�I�u�W�F�N�g�̃g�����X�t�H�[��")]
    private Transform tr;

    [SerializeField, Header("�`�F�b�N���C���[")]
    private LayerMask chkLayer;

    private enum DIR_TYPE
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
    }
    [SerializeField, Header("���C�̕���")]
    private DIR_TYPE dirType = DIR_TYPE.DOWN;

    [SerializeField, Header("���C�̋���")]
    private float rayDis = 0.5f;

    [SerializeField, Header("���C�̎n�_"),Tooltip("�I�u�W�F�N�g�̃g�����X�t�H�[������ɐݒ�")]
    private Vector3 vector3;

    [SerializeField, Header("���C�̉���")]
    private bool rayFlg = false;

    public bool LineChk()
    {
        // transform.localScale�̐����ɂ����Enemy��x�����ɔ��]����
        Vector3 scale = tr.localScale;

        Vector3 dir = new Vector3();
        if (dirType == DIR_TYPE.UP) dir += tr.up;
        else if (dirType == DIR_TYPE.DOWN) dir -= tr.up;
        else if (dirType == DIR_TYPE.RIGHT) dir += tr.right;
        else dir -= tr.right;

        // �n�_�����Enemy�̐i�s�����ɏo��悤��startposition�����߂�
        Vector3 startposition = tr.position + vector3 + dir * scale.x;

        // startpostion���瑫���܂ł��I�_�Ƃ���
        Vector3 endposition = startposition + dir * rayDis;

        // Debug�p�Ɏn�_�ƏI�_��\������
        if(rayFlg) Debug.DrawLine(startposition, endposition, Color.red);

        // Physics2D.Linecast���g���A�x�N�g����StageLayer���ڐG���Ă�����True��Ԃ�
        return Physics2D.Linecast(startposition, endposition, chkLayer);
    }
}

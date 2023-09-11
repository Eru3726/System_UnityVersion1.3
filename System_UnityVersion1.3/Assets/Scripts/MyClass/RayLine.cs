using UnityEngine;

[System.Serializable]
public class RayLine
{
    [SerializeField, Header("�I�u�W�F�N�g�̃g�����X�t�H�[��")]
    private Transform tr;

    [SerializeField, Header("�`�F�b�N���C���[")]
    private LayerMask chkLayer;

    [SerializeField, Header("���C�̎n�_"), Tooltip("�I�u�W�F�N�g�̃g�����X�t�H�[������ɐݒ�")]
    private Vector3 startposition = new Vector3();

    [SerializeField, Header("���C�̏I�_"), Tooltip("�I�u�W�F�N�g�̃g�����X�t�H�[������ɐݒ�")]
    private Vector3 endposition = new Vector3();

    [SerializeField, Header("���C�̉���")]
    private bool rayFlg = false;

    public bool LineChk()
    {
        if (tr == null) return false;
        // transform.localScale�̐����ɂ����Enemy��x�����ɔ��]����
        Vector3 scale = tr.localScale;

        // �n�_�����Enemy�̐i�s�����ɏo��悤��startposition�����߂�
        Vector3 str = tr.position + new Vector3(startposition.x * scale.x, startposition.y * scale.y, startposition.z * scale.z);

        // startpostion���瑫���܂ł��I�_�Ƃ���
        Vector3 end = str + new Vector3(endposition.x * scale.x, endposition.y * scale.y, endposition.z * scale.z);

        // Debug�p�Ɏn�_�ƏI�_��\������
        if (rayFlg) Debug.DrawLine(str, end, Color.red);

        // Physics2D.Linecast���g���A�x�N�g����StageLayer���ڐG���Ă�����True��Ԃ�
        return Physics2D.Linecast(str, end, chkLayer);
    }
}

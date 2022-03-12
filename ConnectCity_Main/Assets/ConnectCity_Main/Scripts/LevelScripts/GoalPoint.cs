using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Const;

/// <summary>
/// �S�[���G���A
/// </summary>
public class GoalPoint : MonoBehaviour
{
    /// <summary>�ڒn����p�̃��C�@�I�u�W�F�N�g�̎n�_</summary>
    private static readonly Vector3 ISGROUNDED_RAY_ORIGIN_OFFSET = new Vector3(0f, 0.1f);
    /// <summary>�ڒn����p�̃��C�@�I�u�W�F�N�g�̏I�_</summary>
    private static readonly Vector3 ISGROUNDED_RAY_DIRECTION = Vector3.down;
    /// <summary>�ڒn����p�̃��C�@�����蔻��̍ő勗��</summary>
    private static readonly float ISGROUNDED_RAY_MAX_DISTANCE = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.TAG_NAME_PLAYER))
        {
            if (LevelDecision.IsGrounded(transform.position, ISGROUNDED_RAY_ORIGIN_OFFSET, ISGROUNDED_RAY_DIRECTION, ISGROUNDED_RAY_MAX_DISTANCE))
            {
                var player = other.gameObject.GetComponent<PlayerController>();
                if (player.isActiveAndEnabled)
                {
                    player.enabled = false;
                }
                SfxPlay.Instance.PlaySFX(ClipToPlay.me_game_clear);
                UIManager.Instance.OpenClearScreen();
            }
            else
            {
                // �O�̂��߃��O�o��
                Debug.Log("�S�[�����ɑ��ꂪ����܂���");
            }
        }
    }
}

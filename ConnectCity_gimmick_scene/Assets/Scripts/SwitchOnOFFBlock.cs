using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOFFBlock : MonoBehaviour
{
    /// <summary>
    /// �u���b�N�̗L���^�����X�e�[�^�X�i�L���Ȃ�true�A�����Ȃ�false�j
    /// </summary>
    [SerializeField] private bool isEnabled;
    /// <summary>
    /// �L����Ԃ̃t�F�[�h�l
    /// </summary>
    [SerializeField] private float enabledEndValue;
    /// <summary>
    /// ������Ԃ̃t�F�[�h�l
    /// </summary>
    [SerializeField] private float disabledEndValue;
    /// <summary>
    /// �t�F�[�h�A�j���[�V�����̑J�ڎ���
    /// </summary>
    [SerializeField] private float doFadeDuration;
    private bool _defaultIsEnabled; //�L���^�����X�e�[�^�X�̏����l
    private Renderer _renderer; //�I�u�W�F�N�g�̃}�e���A�����̏��
    private BoxCollider _collider;  //�R���C�_�[

    public bool Initialize()
    {
        try
        {
            isEnabled = _defaultIsEnabled;
            return true;
        }
        catch
        {
            System.Exception
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

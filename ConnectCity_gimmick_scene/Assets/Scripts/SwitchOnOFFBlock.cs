using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOFFBlock : MonoBehaviour
{
    [SerializeField] private bool isEnabled;    //�u���b�N�̗L���^�����X�e�[�^�X�i�L���Ȃ�true�A�����Ȃ�false�j
    [SerializeField] private float enabledEndValue; //�L����Ԃ̃t�F�[�h�l
    [SerializeField] private float disabledEndValue;    //������Ԃ̃t�F�[�h�l
    [SerializeField] private float doFadeDuration;  //�t�F�[�h�A�j���[�V�����̑J�ڎ���
    private bool _defaultIsEnabled; //�L���^�����X�e�[�^�X�̏����l
    private Renderer _renderer; //�I�u�W�F�N�g�̃}�e���A�����̏��
    private BoxCollider _collider;  //�R���C�_�[
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

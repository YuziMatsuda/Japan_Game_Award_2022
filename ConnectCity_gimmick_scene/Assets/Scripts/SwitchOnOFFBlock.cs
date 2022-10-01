using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            _defaultIsEnabled = isEnabled;
            _renderer = GetComponent<Renderer>();
            _collider = GetComponent<BoxCollider>();
            return true;
        }
        catch(System.Exception)
        {
            throw;
        }
    }

    public bool Exit()
    {
        try
        {
            isEnabled = _defaultIsEnabled;
            CheckOnOffState();
            return true;
        }
        catch(System.Exception)
        {
            throw;
        }
    }

    public void CheckOnOffState()
    {
        if(isEnabled == true)
        {
            _collider.enabled = true;
            this._renderer.DOFade(endValue: enabledEndValue, duration: doFadeDuration);
        }
        else if(isEnabled == false)
        {
            _collider.enabled = false;
            this._renderer.DOFade(endValue: disabledEndValue, duration: doFadeDuration);
        }
    }

    public bool UpdateOnOffState()
    {
        try
        {
            if(isEnabled == true)
            {
                isEnabled = false;
            }
            else
            {
                isEnabled = true;
            }
            return true;
        }
        catch(System.Exception)
        {
            throw;
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

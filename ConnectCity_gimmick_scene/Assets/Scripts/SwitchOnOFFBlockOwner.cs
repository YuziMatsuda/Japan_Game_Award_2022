using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOFFBlockOwner : MonoBehaviour
{
    /// <summary>
    /// �Q�[���I�u�W�F�N�g�uSwitchOnOFFBlock�v�𕡐��Ǘ�����z��I�u�W�F�N�g
    /// </summary>
    private GameObject[] _switchOnOFFBlocks;

    public bool Initialize()
    {
        try
        {
            _switchOnOFFBlocks = GameObject.FindGameObjectsWithTag("SwitchOnOFFBlockOwner");
            return true;
        }
        catch
        {
            return false;
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

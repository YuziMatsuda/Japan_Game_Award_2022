using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TitleSelect
{
    public class Select_Comment : MonoBehaviour
    {
        public Text text;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Comment(int stage)
        {
            if (stage == 1)
            {
                text.text = "��Փx�y���������������������z\r\n�R�l�N�g�V�e�B�ł̊�{������o����\r\n�X�e�[�W����B";
            }

            if (stage == 2)
            {
                text.text = "��Փx�y���������������������z\r\n�R�l�N�g�V�e�B�ł̃R�l�N�g���ԑ���\r\n�̎d�g�݂��o����X�e�[�W����B";
            }

            if (stage == 3)
            {
                text.text = "��Փx�y���������������������z\r\n��ԑ���Ńu���b�N�̍ė��p���ł��鎖\r\n��m���Ă��炤�X�e�[�W����B";
            }

            if (stage == 4)
            {
                text.text = "��Փx�y���������������������z\r\n���E�����ɋ�ԑ��삵�čU������\r\n�X�e�[�W�ɂȂ��B";
            }

            if (stage == 5)
            {
                text.text = "��Փx�y���������������������z\r\n�����K�X�e�[�W�@\r\n����܂Ŏ��H����������g����\r\n�U������X�e�[�W�ɂȂ��B";
            }

            if (stage == 6)
            {
                text.text = "��Փx�y���������������������z\r\n��ԑ�������C���ɂ���܂Ŏ��H��������ōU������X�e�[�W�ɂȂ��B";
            }

            if (stage == 7)
            {
                text.text = "��Փx�y���������������������z\r\n�v���C���[�𗎂Ƃ��Ȃ��悤��\r\n��ԑ���𗘗p���čU������X�e�[�W����B";
            }

            if (stage == 8)
            {
                text.text = "��Փx�y���������������������z\r\n�R�l�N�g���鏇�Ԃ��l���Ȃ���\r\n�N���A���鎖���ł��Ȃ��X�e�[�W����";
            }

            if (stage == 9)
            {
                text.text = "��Փx�y���������������������z\r\n��ԑ���ƃR�l�N�g���鏇�Ԃ��l���Ȃ��ƃN���A���鎖���ł��Ȃ��X�e�[�W����";
            }

            if (stage == 10)
            {
                text.text = "��Փx�y���������������������z\r\n�����K�X�e�[�W�A\r\n����܂Ŏ��H����������g����\r\n�U������X�e�[�W�ɂȂ��B";
            }

            if (stage == 11)
            {
                text.text = "��Փx�y���������������������z\r\n�V�M�~�b�N �u�G�v���o��\r\n��ԑ�����g���čU�����鎖�����ɂȂ��B";
            }

            if (stage == 12)
            {
                text.text = "��Փx�y���������������������z\r\n�G�������ɎJ�������ł��邩��\r\n�U���̌��ɂȂ��B";
            }

            if (stage == 13)
            {
                text.text = "��Փx�y���������������������z\r\n��ԑ���ƃR�l�N�g���H�v���āA\r\n�S�[������K�v�������B";
            }

            if (stage == 14)
            {
                text.text = "��Փx�y���������������������z\r\n�V�M�~�b�N �u�ڂ낢�u���b�N�E�V��v���o��B\r\n��ԑ���łڂ낢�u���b�N��V����󂻂�";
            }

            if (stage == 15)
            {
                text.text = "��Փx�y���������������������z\r\n�ڂ낢�u���b�N���󂵂A\r\n�S�[�����X�e�[�W�O�ɗ��Ƃ��Ȃ��悤�ɂ���H�v���K�v�ɂȂ��";
            }

            if (stage == 16)
            {
                text.text = "��Փx�y���������������������z\r\n���g�̑�����c���Ȃ��ƍU���ł��Ȃ��X�e�[�W����";
            }

            if (stage == 17)
            {
                text.text = "��Փx�y���������������������z\r\n�V�M�~�b�N �u�d�́v���o��\r\n��ԑ�����g���ďd�͂��U�����鎖�����ɂȂ��B";
            }

            if (stage == 18)
            {
                text.text = "��Փx�y���������������������z\r\n�d�̗͂�������āA��ԑ���ƃR�l�N�g����g���鎖���U���̌��ɂȂ��B";
            }

            if (stage == 19)
            {
                text.text = "��Փx�y���������������������z\r\n�d�͂Ƃڂ낢�u���b�N�ŗ����Ȃ��悤��\r\n�C��t���ăR�l�N�g����K�v�������B";
            }

            if (stage == 20)
            {
                text.text = "��Փx�y���������������������z\r\n�����K�X�e�[�W�B\r\n���܂œo�ꂵ���M�~�b�N���S�ďo���\r\n����܂ł̑�����������čU�����悤�B";
            }

            if (stage == 21)
            {
                text.text = "��Փx�y���������������������z\r\n�V�M�~�b�N �u���[�U�[�v���o��\r\n���[�U�[��������čU�����悤�B";
            }

            if (stage == 22)
            {
                text.text = "��Փx�y���������������������z\r\n�v���C���[���u���[�U�[�v������悤�ɃR�l�N�g���鎖���U���̌�����B";
            }

            if (stage == 23)
            {
                text.text = "��Փx�y���������������������z\r\n���[�U�[�̍U���ƃS�[�����X�e�[�W�O��\r\n���Ƃ��Ȃ��悤�H�v���K�v����B";
            }

            if (stage == 24)
            {
                text.text = "��Փx�y���������������������z\r\n��ԑ��삵���u���b�N���X�e�[�W�O��\r\n�s���Ȃ��悤�ɂ���H�v���K�v����B";
            }

            if (stage == 25)
            {
                text.text = "��Փx�y���������������������z\r\n�d�͂Ƌ�ԑ���ɋC��t���čU������K�v�������B";
            }

            if (stage == 26)
            {
                text.text = "��Փx�y���������������������z\r\n���[�U�[��h���A\r\n��ԑ���ƃR�l�N�g�����p���čU������K�v�������B";
            }

            if (stage == 27)
            {
                text.text = "��Փx�y���������������������z\r\n���[�U�[�A����ɋC��t���ĂA\r\n��ԑ���ƃR�l�N�g�����p���čU������X�e�[�W�ɂȂ��B";
            }

            if (stage == 28)
            {
                text.text = "��Փx�y���������������������z\r\n��փX�e�[�W�@\r\n����܂ł̑������g���čU�����悤�B\r\n����Ƌ�ԑ���ɋC��t���邱�Ƃ��|�C���g����B";
            }

            if (stage == 29)
            {
                text.text = "��Փx�y���������������������z\r\n��փX�e�[�W�A\r\n����܂ł̑������g���čU�����悤�B\r\n����Əd�͂ɋC��t���A\r\n�R�l�N�g���鎖���U���̌�����B";
            }

            if (stage == 30)
            {
                text.text = "��Փx�y���������������������z\r\n��փX�e�[�W�B\r\n����܂ł̑������g���čU�����悤�B\r\n�ŏI�X�e�[�W�̍U����ڎw��";
            }
        }
    }
}
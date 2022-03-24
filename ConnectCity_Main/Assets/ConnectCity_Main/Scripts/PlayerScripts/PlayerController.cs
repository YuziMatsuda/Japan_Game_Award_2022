using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Const;
using UniRx;
using UniRx.Triggers;
using Common.LevelDesign;

/// <summary>
/// プレイヤー操作制御
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    /// <summary>接地判定用のレイ　オブジェクトの始点</summary>
    private static readonly Vector3 ISGROUNDED_RAY_ORIGIN_OFFSET = new Vector3(0f, 0.1f);
    /// <summary>接地判定用のレイ　オブジェクトの終点</summary>
    private static readonly Vector3 ISGROUNDED_RAY_DIRECTION = Vector3.down;
    /// <summary>接地判定用のレイ　当たり判定の最大距離</summary>
    private static readonly float ISGROUNDED_RAY_MAX_DISTANCE = 0.8f;

    /// <summary>キャラクター制御</summary>
    private CharacterController _characterCtrl;

    /// <summary>移動速度</summary>
    [SerializeField] private float moveSpeed = 4f;
    /// <summary>ジャンプ速度</summary>
    [SerializeField] private float jumpSpeed = 5f;
    /// <summary>ジャンプ状態</summary>
    private BoolReactiveProperty _isJumped = new BoolReactiveProperty();

    void Start()
    {
        _characterCtrl = GetComponent<CharacterController>();
        // 位置・スケールのキャッシュ
        var transform = base.transform;
        // 移動先の座標（X軸の移動、Y軸のジャンプのみ）
        var moveVelocity = new Vector3();

        // 移動入力に応じて移動座標をセット
        this.UpdateAsObservable()
            .Select(_ => Input.GetAxis(InputConst.INPUT_CONST_HORIZONTAL) * moveSpeed)
            .Subscribe(x =>
            {
                moveVelocity.x = x;
                transform.LookAt(transform.position + new Vector3(moveVelocity.x, 0f, 0f));
            });
        // ジャンプ入力に応じてジャンプフラグをセット
        this.UpdateAsObservable()
            .Where(_ => !_isJumped.Value &&
                LevelDesisionIsObjected.IsGrounded(transform.position, ISGROUNDED_RAY_ORIGIN_OFFSET, ISGROUNDED_RAY_DIRECTION, ISGROUNDED_RAY_MAX_DISTANCE))
            .Select(_ => Input.GetButtonDown(InputConst.INPUT_CONSTJUMP))
            .Where(x => x)
            .Subscribe(x => _isJumped.Value = x);
        // ジャンプフラグ切り替え
        _isJumped.Where(x => x)
            .Subscribe(_ =>
            {
                moveVelocity.y = jumpSpeed;
                // T.B.D ジャンプSEがはいるが、ひとまず決定音を鳴らす
                SfxPlay.Instance.PlaySFX(ClipToPlay.se_decided);
                _isJumped.Value = false;
            });
        // 空中にいる際の移動座標をセット
        this.UpdateAsObservable()
            .Where(_ => !LevelDesisionIsObjected.IsGrounded(transform.position, ISGROUNDED_RAY_ORIGIN_OFFSET, ISGROUNDED_RAY_DIRECTION, ISGROUNDED_RAY_MAX_DISTANCE))
            .Subscribe(_ => moveVelocity.y += Physics.gravity.y * Time.deltaTime);
        // 移動
        this.FixedUpdateAsObservable()
            .Subscribe(_ => _characterCtrl.Move(moveVelocity * Time.deltaTime));
    }

    /// <summary>
    /// ゲームオブジェクトからプレイヤー操作を実行
    /// </summary>
    /// <param name="moveVelocity">移動座標</param>
    /// <returns>成功／失敗</returns>
    public bool MoveChatactorFromGameManager(Vector3 moveVelocity)
    {
        if (_characterCtrl == null)
            return false;
        _characterCtrl.Move(moveVelocity);
        return true;
    }
}

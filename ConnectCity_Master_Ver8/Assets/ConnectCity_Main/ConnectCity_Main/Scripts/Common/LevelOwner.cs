using Main.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Main.Common.Const.TagConst;
using System.Threading.Tasks;
using Main.Level;
using Main.Common.LevelDesign;
using System.Linq;
using Gimmick;
using UniRx;
using UniRx.Triggers;

namespace Main.Common
{
    /// <summary>
    /// レベルデザインのオーナー
    /// </summary>
    public class LevelOwner : MonoBehaviour
    {
        /// <summary>レベルデザイン</summary>
        [SerializeField] private GameObject levelDesign;
        /// <summary>レベルデザイン</summary>
        public GameObject LevelDesign => levelDesign;
        /// <summary>Skyboxの設定</summary>
        [SerializeField] private GameObject skyBoxSet;
        /// <summary>Skyboxの設定</summary>
        public GameObject SkyBoxSet => skyBoxSet;
        /// <summary>プレイヤーのゲームオブジェクト</summary>
        [SerializeField] private GameObject[] player;
        /// <summary>プレイヤーのゲームオブジェクト</summary>
        public GameObject Player => player[GameManager.Instance.SceneOwner.GetComponent<SceneOwner>().SceneIdCrumb.Current];
        /// <summary>プレイヤーの初期状態</summary>
        private ObjectsOffset[] _playerOffsets;
        /// <summary>プレイヤーの初期状態</summary>
        public ObjectsOffset[] PlayerOffsets => _playerOffsets;
        /// <summary>空間操作</summary>
        [SerializeField] private GameObject spaceOwner;
        /// <summary>空間操作</summary>
        public GameObject SpaceOwner => spaceOwner;
        /// <summary>カメラ</summary>
        [SerializeField] private GameObject mainCamera;
        /// <summary>カメラ</summary>
        public GameObject MainCamera { get { return mainCamera; } }
        /// <summary>ゴールポイントのゲームオブジェクト</summary>
        [SerializeField] private GameObject[] goalPoint;
        /// <summary>ゴールポイントのゲームオブジェクト</summary>
        public GameObject GoalPoint => goalPoint[GameManager.Instance.SceneOwner.GetComponent<SceneOwner>().SceneIdCrumb.Current];
        /// <summary>敵ギミックのオーナー</summary>
        [SerializeField] private GameObject robotEnemiesOwner;
        /// <summary>敵ギミックのオーナー</summary>
        public GameObject RobotEnemiesOwner => robotEnemiesOwner;
        /// <summary>ぼろいブロック・天井のオーナー</summary>
        [SerializeField] private GameObject breakBlookOwner;
        /// <summary>ぼろいブロック・天井のオーナー</summary>
        public GameObject BreakBlookOwner => breakBlookOwner;

        /// <summary>レーザー砲ギミックのオーナー</summary>
        [SerializeField] private GameObject turretEnemiesOwner;
        /// <summary>レーザー砲ギミックのオーナー</summary>
        public GameObject TurretEnemiesOwner => turretEnemiesOwner;
        /// <summary>メソッドをコールさせる優先順位</summary>
        private OmnibusCallCode _omnibusCall = OmnibusCallCode.None;
        /// <summary>優先メソッドをコール中の待機時間</summary>
        [SerializeField] private int omnibusCallDelayTime = 10;

        private void Reset()
        {
            if (levelDesign == null)
                levelDesign = GameObject.Find("LevelDesign");
            if (skyBoxSet == null)
                skyBoxSet = GameObject.Find("SkyBoxSet");
            if (player == null || player.Length == 0)
                player = LevelDesisionIsObjected.GetGameObjectsInLevelDesign("LevelDesign", "SceneOwner", TAG_NAME_PLAYER, true);
            if (spaceOwner == null)
                spaceOwner = GameObject.FindGameObjectWithTag(TAG_NAME_SPACEMANAGER);
            if (mainCamera == null)
                mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (goalPoint == null || goalPoint.Length == 0)
                goalPoint = LevelDesisionIsObjected.GetGameObjectsInLevelDesign("LevelDesign", "SceneOwner", TAG_NAME_GOALPOINT, true);
            if (breakBlookOwner == null)
                breakBlookOwner = GameObject.Find("BreakBlookOwner");
            if (robotEnemiesOwner == null)
                robotEnemiesOwner = GameObject.Find("RobotEnemiesOwner");
            if (turretEnemiesOwner == null)
                turretEnemiesOwner = GameObject.Find("TurretEnemiesOwner");
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        public bool Initialize()
        {
            try
            {
                this.UpdateAsObservable()
                    .Subscribe(async _ =>
                    {
                        if (_omnibusCall.Equals(OmnibusCallCode.MoveCharactorFromSpaceOwner))
                        {
                        // ProjectSettings > Physics > Sleep Threshold（1フレームの待機時間）
                        await Task.Delay(omnibusCallDelayTime);
                        }
                        _omnibusCall = OmnibusCallCode.None;
                    });
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 疑似スタート
        /// </summary>
        /// <returns>成功／失敗</returns>
        public bool ManualStart()
        {
            try
            {
                _playerOffsets = LevelDesisionIsObjected.SaveObjectOffset(Player);
                if (_playerOffsets == null)
                    Debug.LogError("オブジェクト初期状態の保存の失敗");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// SpaceOwnerの操作禁止フラグをセット
        /// </summary>
        /// <param name="flag">有効／無効</param>
        public void SetSpaceOwnerInputBan(bool flag)
        {
            spaceOwner.GetComponent<SpaceOwner>().InputBan = flag;
        }

        /// <summary>
        /// PlayerControllerの操作禁止フラグをセット
        /// </summary>
        /// <param name="flag">有効／無効</param>
        public void SetPlayerControllerInputBan(bool flag)
        {
            Player.GetComponent<PlayerController>().InputBan = flag;
        }

        /// <summary>
        /// スカイボックスを設定
        /// SceneOwnerからの呼び出し
        /// </summary>
        /// <param name="idx">パターン番号</param>
        /// <returns></returns>
        public bool SetRenderSkybox(RenderSettingsSkybox idx)
        {
            return skyBoxSet.GetComponent<SkyBoxSet>().SetRenderSkybox(idx);
        }

        /// <summary>
        /// ゴールポイント初期処理
        /// </summary>
        /// <returns>成功／失敗</returns>
        public bool GoalPointInitialize()
        {
            return GoalPoint.GetComponent<GoalPoint>().Initialize();
        }

        /// <summary>
        /// ぼろいブロック・天井の初期処理
        /// ディレイ付きの初期処理
        /// ※空間操作ブロックの衝突判定のタイミングより後に実行させる必要があり、暫定対応
        /// </summary>
        /// <returns>成功／失敗</returns>
        public bool DelayInitializeBreakBlocks()
        {
            return breakBlookOwner.GetComponent<BreakBlookOwner>().DelayInitializeBreakBlocks();
        }

        /// <summary>
        /// ぼろいブロック・天井の監視の停止
        /// </summary>
        public void DisposeAll()
        {
            breakBlookOwner.GetComponent<BreakBlookOwner>().DisposeAll();
        }

        /// <summary>
        /// カウントダウン表示を更新
        /// </summary>
        /// <param name="count">コネクト回数</param>
        /// <param name="maxCount">クリア条件のコネクト必要回数</param>
        /// <returns>成功／失敗</returns>
        public bool UpdateCountDown(int count, int maxCount)
        {
            return GoalPoint.GetComponent<GoalPoint>().UpdateCountDown(count, maxCount);
        }

        /// <summary>
        /// ドアを開く
        /// ゴール演出のイベント
        /// </summary>
        /// <returns>成功／失敗</returns>
        public bool OpenDoor()
        {
            return GoalPoint.GetComponent<GoalPoint>().OpenDoor();
        }

        /// <summary>
        /// プレイヤー操作指令を実行して、実行結果を返却する
        /// </summary>
        /// <param name="moveVelocity">移動座標</param>
        /// <returns>成功／失敗</returns>
        public bool MoveCharactor(Vector3 moveVelocity)
        {
            _omnibusCall = OmnibusCallCode.MoveCharactorFromSpaceOwner;
            return Player.GetComponent<PlayerController>().MoveChatactor(moveVelocity);
        }

        /// <summary>
        /// 敵操作指令を実行して、実行結果を返却する
        /// </summary>
        /// <param name="moveVelocity">移動座標</param>
        /// <returns>成功／失敗</returns>
        public bool MoveRobotEnemy(Vector3 moveVelocity, GameObject hitObject)
        {
            return hitObject.GetComponent<Robot_Enemy>().MoveRobotEnemy(moveVelocity);
        }

        /// <summary>
        /// 重力操作ギミックオブジェクトからプレイヤーオブジェクトへ
        /// プレイヤー操作指令を実行して、実行結果を返却する
        /// </summary>
        /// <param name="moveVelocity">移動座標</param>
        /// <returns>成功／失敗</returns>
        public bool MoveCharactorOrWait(Vector3 moveVelocity)
        {
            // 空間操作による呼び出しがあるなら実行しない
            if (_omnibusCall.Equals(OmnibusCallCode.MoveCharactorFromSpaceOwner))
                return true;

            _omnibusCall = OmnibusCallCode.MoveCharactorFromGravityController;
            return Player.GetComponent<PlayerController>().MoveChatactor(moveVelocity);
        }

        /// <summary>
        /// プレイヤーを死亡させる
        /// </summary>
        /// <returns>成功／失敗</returns>
        public async Task<bool> DeadPlayer()
        {
            return await Player.GetComponent<PlayerController>().DeadPlayer();
        }

        /// <summary>
        /// 敵ギミックを破壊する
        /// </summary>
        /// <returns>成功／失敗</returns>
        public bool DestroyHumanEnemies(GameObject hitObject)
        {
            return hitObject.GetComponent<Robot_Enemy>().DestroyHumanEnemies();
        }
    }
}
/// <summary>
/// メソッドをコールする際に複数実行の場合、優先順位を決める
/// </summary>
public enum OmnibusCallCode
{
    None,
    MoveCharactorFromSpaceOwner,
    MoveCharactorFromGravityController
}
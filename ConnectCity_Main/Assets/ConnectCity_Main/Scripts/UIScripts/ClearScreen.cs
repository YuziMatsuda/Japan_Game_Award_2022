using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Main.UI
{
    /// <summary>
    /// クリア画面制御クラス
    /// </summary>
    public class ClearScreen : MasterScreen
    {
        private static ClearScreen instance;
        public static ClearScreen Instance { get { return instance; } }
        [SerializeField] private ClearUIController firstElement;

        protected override void Awake()
        {
            if (null != instance)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            base.Awake();
        }

        protected override void Initialize()
        {
            if (!firstElement)
                firstElement = transform.GetChild(0).GetChild(1).GetComponent<ClearUIController>();
            if (!firstObject)
                firstObject = GameObject.Find("GameRetryButton");
            base.Initialize();
        }

        protected override void SelectFirstElement()
        {
            firstElement.Selected();
        }

        /// <summary>
        /// 最初の項目を選択する外部インターフェース
        /// UIManagerから呼ばれる想定
        /// </summary>
        public void AutoSelectContent()
        {
            if (!@event)
                @event = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            @event.SetSelectedGameObject(firstObject);
            SelectFirstElement();
        }
    }
}

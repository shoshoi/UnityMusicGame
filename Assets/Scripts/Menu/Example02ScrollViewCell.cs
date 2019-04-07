/** 
 * Copyright (c) 2017 setchi
 * Released under the MIT license
 * https://github.com/setchi/FancyScrollView/blob/master/LICENSE
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FancyScrollView
{
    public class Example02ScrollViewCell
        : FancyScrollViewCell<Example02CellDto, Example02ScrollViewContext>
    {
        [SerializeField]
        Animator animator;
        [SerializeField]
        Text message;
        [SerializeField]
        Image image;
        [SerializeField]
        Button button;
        [SerializeField]
        int id;

        static readonly int scrollTriggerHash = Animator.StringToHash("scroll");
        Example02ScrollViewContext context;

        void Start()
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchoredPosition3D = Vector3.zero;
            UpdatePosition(0);

            button.onClick.AddListener(OnPressedCell);
        }

        /// <summary>
        /// コンテキストを設定します
        /// </summary>
        /// <param name="context"></param>
        public override void SetContext(Example02ScrollViewContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// セルの内容を更新します
        /// </summary>
        /// <param name="itemData"></param>
        public override void UpdateContent(Example02CellDto itemData)
        {
            message.text = itemData.Message;
            if(image.sprite == null || id != itemData.Id)
            {
                image.sprite = GameParameter.Instance().GetMusicData(itemData.Id).GetImage();
            }
            id = itemData.Id;
            if (context != null)
            {
                var isSelected = context.SelectedIndex == DataIndex;
                image.color = new Color32(255, 255, 255, 255);
                if(currentPosition > 0.45f && currentPosition < 0.55f)
                {
                    this.transform.SetSiblingIndex(1);
                    GameParameter gameParameter = GameParameter.Instance();
                    gameParameter.selectMusicDataId = this.id;
                    image.color = new Color32(255, 255, 255, 255);
                }else{
                    this.transform.SetSiblingIndex(0);
                    image.color = new Color32(255, 255, 255, 150);
                }
            }
        }

        /// <summary>
        /// セルの位置を更新します
        /// </summary>
        /// <param name="position"></param>
        public override void UpdatePosition(float position)
        {
            currentPosition = position;
            animator.Play(scrollTriggerHash, -1, position);
            animator.speed = 0;
        }

        // GameObject が非アクティブになると Animator がリセットされてしまうため
        // 現在位置を保持しておいて OnEnable のタイミングで現在位置を再設定します
        float currentPosition = 0;
        void OnEnable()
        {
            UpdatePosition(currentPosition);
        }

        void OnPressedCell()
        {
            GameParameter gameParameter = GameParameter.Instance();
            gameParameter.selectMusicDataId = this.id;

            SceneManager.LoadScene("Game");
            if (context != null)
            {
                context.OnPressedCell(this);
            }
        }
    }
}

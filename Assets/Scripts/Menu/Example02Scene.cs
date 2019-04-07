using System.Collections.Generic;
/** 
 * Copyright (c) 2017 setchi
 * Released under the MIT license
 * https://github.com/setchi/FancyScrollView/blob/master/LICENSE
 */
using System.Linq;
using UnityEngine;

namespace FancyScrollView
{
    public class Example02Scene : MonoBehaviour
    {
        [SerializeField]
        Example02ScrollView scrollView;

        void Start()
        {
            List<Example02CellDto> cellDataList = new List<Example02CellDto>();
            GameParameter gameParameter = GameParameter.Instance();
            List<SimpleMusicData> musicDatas = gameParameter.musicDatas;
            foreach (var item in musicDatas)
            {
                var cellData = new Example02CellDto();
                cellData.Message = item.Inf.title;
                cellData.Id = item.Id;
                cellDataList.Add(cellData);
            }
            scrollView.UpdateData(cellDataList);
        }
    }
}

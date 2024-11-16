using DisplayCurrentCrownStatus;
using Scripts.OutGame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Utage;

namespace DisplayCurrentCrownStatus.Plugins
{
    internal class SpriteManagement
    {
        public static Dictionary<DataConst.CrownType, Sprite> CrownSprites = new Dictionary<DataConst.CrownType, Sprite>();
        public static Dictionary<DataConst.CrownType, GameObject> CrownSpriteGameObjects = new Dictionary<DataConst.CrownType, GameObject>();

        public static void InitializeCrownSprites(SongSelectSprite songSelectSprite)
        {
            if (songSelectSprite == null)
            {
                return;
            }

            AddSpriteToDictionary(songSelectSprite, DataConst.CrownType.Silver, "icon_crown_silver");
            AddSpriteToDictionary(songSelectSprite, DataConst.CrownType.Gold, "icon_crown_gold");
            AddSpriteToDictionary(songSelectSprite, DataConst.CrownType.Rainbow, "icon_crown_rainbow");

            // I'd like to use the crown_line_ sprites, but I don't know how to access them
            //AddSpriteToDictionary(songSelectSprite, DataConst.CrownType.Silver, "crown_line_silver");
            //AddSpriteToDictionary(songSelectSprite, DataConst.CrownType.Gold, "crown_line_gold");
            //AddSpriteToDictionary(songSelectSprite, DataConst.CrownType.Rainbow, "crown_line_rainbow");
        }

        static void AddSpriteToDictionary(SongSelectSprite songSelectSprite, DataConst.CrownType crown, string spriteKey)
        {
            if (!CrownSprites.ContainsKey(crown))
            {
                var sprite = songSelectSprite.GetSprite(spriteKey);
                //var sprite = songSelectSprite.GetSprite("crown_line_rainbow");
                CrownSprites.Add(crown, sprite);
                GameObject obj = new GameObject("SaveSprite");
                var image = obj.AddComponent<Image>();
                image.sprite = sprite;
                DontDestoryOnLoad.DontDestroyOnLoad(obj);
                CrownSpriteGameObjects.Add(crown, obj);
                Plugin.Log.LogInfo("Sprite added for crown: " + crown.ToString());
            }
        }
    }
}

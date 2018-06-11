using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public static class CameraSetter
    {
        public static Camera camera;
        private static List<SceneInfo> SceneInfoList;
        public static void Init()
        {
            camera = GameObject.Find("MainCamera").GetComponent<Camera>();
            SceneInfoList = new List<SceneInfo>();
            SceneInfoList.Add(new SceneInfo(SceneType.ChooseHero, 0, 0, -10));
            SceneInfoList.Add(new SceneInfo(SceneType.BattleMain, 1800, 0, -10));
            SceneInfoList.Add(new SceneInfo(SceneType.Props, 1800, -1800, -10));
            SceneInfoList.Add(new SceneInfo(SceneType.Settings, 1800, -900, -10));
            SceneInfoList.Add(new SceneInfo(SceneType.Skills, 0, -900, -10));
            SceneInfoList.Add(new SceneInfo(SceneType.End, 0, 900, -10));
        }

        public static void SwichScene(SceneType sceneType)
        {
            var sceneInfo = SceneInfoList.FirstOrDefault(x => x.SceneType == sceneType);
            if (sceneInfo != null)
                camera.transform.position = new Vector3(sceneInfo.x, sceneInfo.y, sceneInfo.z);
        }
    }

    public class SceneInfo
    {
        public SceneType SceneType;
        public float x;
        public float y;
        public float z;

        public SceneInfo(SceneType type, float _x, float _y, float _z)
        {
            SceneType = type;
            x = _x;
            y = _y;
            z = _z;
        }
    }
}

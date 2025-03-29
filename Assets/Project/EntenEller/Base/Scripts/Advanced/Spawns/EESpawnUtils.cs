using System;
using Project.EntenEller.Base.Scripts.Advanced.Debugs;
using Project.EntenEller.Base.Scripts.Advanced.Events;
using Project.EntenEller.Base.Scripts.Advanced.GameObjects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.EntenEller.Base.Scripts.Advanced.Spawns
{
    public static class EESpawnUtils
    {
        public static Action<EEGameObject> EarlySpawnEvent, SpawnEvent;

        public static T Spawn<T>(T original) where T : Component
        {
            var gameObject = original.gameObject;
            gameObject.SetActive(false);
            var obj = Object.Instantiate(original);
            gameObject.SetActive(true);
            var eeGameObject = obj.GetEEGameObject();
            eeGameObject.Spawn();
#if UNITY_EDITOR
            EEDebug.Log(eeGameObject);
#endif
            EarlySpawnEvent.Call(eeGameObject);
            SpawnEvent.Call(eeGameObject);
            return obj;
        }
    }
}
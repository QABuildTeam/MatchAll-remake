using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using ACFW.Settings;

namespace MatchAll.Settings
{
    [CreateAssetMenu(fileName = "GameHintSettings", menuName = "Game Settings/Game Hint Settings")]
    public class GameHintSettings : ScriptableSettings
    {
        [Serializable]
        private class MessageDescriptor
        {
            public string messageText;
            public AssetReference imageReference;
            public string buttonText;
        }
        [SerializeField]
        private MessageDescriptor[] descriptors;

        public int HintCount => descriptors.Length;
        public string MessageText(int order)
        {
            if (order >= 0 && order < HintCount)
            {
                return descriptors[order].messageText;
            }
            return null;
        }
        public AssetReference ImageReference(int order)
        {
            if (order >= 0 && order < HintCount)
            {
                return descriptors[order].imageReference;
            }
            return null;
        }
        public string ButtonText(int order)
        {
            if (order >= 0 && order < HintCount)
            {
                return descriptors[order].buttonText;
            }
            return null;
        }
    }
}

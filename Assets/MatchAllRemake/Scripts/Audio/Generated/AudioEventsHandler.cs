// This file is automatically generated by Simple Audio System Editor
// Do not edit it!
// To regenerate, use Unity menu item 'Tools/Audio/Simple Audio System'
// and press the 'Generate script with audio handlers' button
using System;
using UnityEngine;
using ACFW;
using SimpleAudioSystem;
using SimpleAudioSystem.Environment;

namespace SimpleAudioSystem
{
    public class AudioEventsHandler : MonoBehaviour, IAudioEventHandler
    {
        private IServiceLocator environment;
        private IEventManager EventManager => environment.Get<IEventManager>();

        public void Init(IServiceLocator environment)
        {
            this.environment = environment;
            EventManager.Get<MatchAll.Environment.GameEndMessageEvents>().OpenWinMessage += GameEndMessageEvents_OpenWinMessage_10;
            EventManager.Get<MatchAll.Environment.GameEndMessageEvents>().OpenFailMessage += GameEndMessageEvents_OpenFailMessage_11;
            EventManager.Get<MatchAll.Environment.GameEvents>().ScoreUp += GameEvents_ScoreUp_10;
            EventManager.Get<MatchAll.Environment.GameEvents>().ScoreDown += GameEvents_ScoreDown_11;
            EventManager.Get<MatchAll.Environment.MainMenuEvents>().OpenMainMenu += MainMenuEvents_OpenMainMenu_11;
            EventManager.Get<MatchAll.Environment.GameScreenEvents>().OpenGameScreen += GameScreenEvents_OpenGameScreen_10;

        }

        private void GameEndMessageEvents_OpenWinMessage_10()
        {
            EventManager.Get<AudioEvents>().PlaySFX?.Invoke(SFXTrackType.Game.Good);
        }
        private void GameEndMessageEvents_OpenFailMessage_11()
        {
            EventManager.Get<AudioEvents>().PlaySFX?.Invoke(SFXTrackType.Game.Bad);
        }
        private void GameEvents_ScoreUp_10()
        {
            EventManager.Get<AudioEvents>().PlaySFX?.Invoke(SFXTrackType.Game.Good);
        }
        private void GameEvents_ScoreDown_11()
        {
            EventManager.Get<AudioEvents>().PlaySFX?.Invoke(SFXTrackType.Game.Bad);
        }
        private void MainMenuEvents_OpenMainMenu_11()
        {
            EventManager.Get<AudioEvents>().PlayMusic?.Invoke(MusicTrackType.MenuTheme);
        }
        private void GameScreenEvents_OpenGameScreen_10()
        {
            EventManager.Get<AudioEvents>().PlayMusic?.Invoke(MusicTrackType.GameTheme);
        }

    }
}

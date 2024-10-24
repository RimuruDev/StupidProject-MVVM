using R3;
using System;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root
{
    public class GameSettingsStateProxy : IDisposable
    {
        private const int SkipFirstInvoke = 1;
        
        public ReactiveProperty<float> MusicVolume { get; }
        public ReactiveProperty<float> SFXVolume { get; }

        private readonly IDisposable musicSubscription;
        private readonly IDisposable sfxSubscription;

        public GameSettingsStateProxy(GameSettingsState settingsState)
        {
            MusicVolume = new ReactiveProperty<float>(settingsState.MusicVolume);
            SFXVolume = new ReactiveProperty<float>(settingsState.SFXVolume);

            musicSubscription = MusicVolume.Skip(SkipFirstInvoke).Subscribe(musicVolume => settingsState.MusicVolume = musicVolume);
            sfxSubscription = SFXVolume.Skip(SkipFirstInvoke).Subscribe(sfxVolume => settingsState.SFXVolume = sfxVolume);
        }

        public void Dispose()
        {
            DisposeLogger.Log(this);
            
            musicSubscription?.Dispose();
            sfxSubscription?.Dispose();
        }

        public override string ToString() => 
            $"MusicVolume: {MusicVolume.Value} | SFXVolume: {SFXVolume.Value}";
    }
}
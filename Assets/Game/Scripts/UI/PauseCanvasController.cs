using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class PauseCanvasController : MonoBehaviour
    {
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
            Debug.Log(G.SoundManager is null);
            musicSlider.value = G.SoundManager!.musicVolume;
            sfxSlider.value = G.SoundManager.sfxVolume;

            musicSlider.onValueChanged.AddListener(OnMusicChanged);
            sfxSlider.onValueChanged.AddListener(OnSfxChanged);
        }

        private void OnMusicChanged(float value)
        {
            G.SoundManager.SetMusicVolume(value);
        }

        private void OnSfxChanged(float value)
        {
            G.SoundManager.SetSfxVolume(value);
        }
    }
}
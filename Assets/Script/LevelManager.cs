using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class LevelManager : MonoBehaviour
{
    public Transform player;
    public DynamicMoveProvider _dynamicMoveProvider;

    [Header("Transform")]
    public Transform startPosition;
    public Transform ScrollPosition_1;

    [Header("Audio")]
    public AudioSource _audioSource;

    [Header("UI")]
    public GameObject _StartMenu;
    public GameObject _GameUI;
    public Slider _audioSlider;
    public void OnClickStart()
    {
        player.position = ScrollPosition_1.position;
        player.rotation = ScrollPosition_1.rotation;
        _dynamicMoveProvider.enabled = true;

        _StartMenu.SetActive(false);
        _GameUI.SetActive(true);
    }
    public void OnClickBack()
    {
        player.position = startPosition.position;
        player.rotation = startPosition.rotation;
        _dynamicMoveProvider.enabled = false;

        _StartMenu.SetActive(true);
        _GameUI.SetActive(false);
    }
    public void OnClickMute()
    {
        _audioSource.mute = !_audioSource.mute;
    }
    public void OnVolumeChanged()
    {
        _audioSource.volume = _audioSlider.value;
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}

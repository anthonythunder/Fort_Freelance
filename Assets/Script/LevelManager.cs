using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.InputSystem;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public Transform player;
    public DynamicMoveProvider _dynamicMoveProvider;

    public List<Animator> scrollAnimators = new List<Animator>();
    [Header("Transform")]
    public Transform startPosition;
    public Transform ScrollPosition_1;
    public List<Transform> ScrollPositions = new List<Transform>();

    [Header("Audio")]
    public AudioSource _audioSource;
    public AudioClip _bgAudioClip;
    public List<AudioClip> _audioClips = new List<AudioClip>();

    [Header("UI")]
    public GameObject _StartMenu;
    public GameObject _GameUI;
    public GameObject TeleportPanel;
    public Slider _audioSlider;

    private bool EnableScrollSequence;
    public InputActionReference A_Buton;
    public InputActionReference X_Buton;
    enum ScrollCount { scroll1,scroll2,scroll3,scroll4,scroll5,scroll6,scroll7,scroll8,scroll9,sacroll10};
    private ScrollCount myScrollCount;

    private float _Time;
    private float _nextClipPlayTime;
    private void Update()
    {
        _Time += Time.deltaTime;

        if (A_Buton.action.WasPressedThisFrame() && _GameUI.activeSelf)
        {
            TeleportPanel.SetActive(!TeleportPanel.activeSelf);
        }

        //if (X_Buton.action.WasPressedThisFrame())
        //{
        //    _nextClipPlayTime = _Time + _audioClips[0].length + .5f;
        //    EnableScrollSequence = true;
        //    _audioSource.Stop();
        //}

        //EnableScrollSquence();
    }
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
    
    public void TeleportTo(int i)
    {
        player.position = ScrollPositions[i].position;
        player.rotation = ScrollPositions[i].rotation;
        TeleportPanel.SetActive(false);
    }

    private void EnableScrollSquence()
    {

        if (!EnableScrollSequence) return;

        _audioSource.loop = false;

        switch (myScrollCount)
        {
            case ScrollCount.scroll1:
                scrollAnimators[0].SetBool("View", true);
                if(!_audioSource.isPlaying)StartCoroutine(playScrollAudio(_audioClips[0], 0.5f));

                SetPlayerPosition(ScrollPositions[0]);

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[1]);

                    scrollAnimators[0].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[1].length + .5f;
                    myScrollCount = ScrollCount.scroll2;

                }
                break;
            case ScrollCount.scroll2:
                scrollAnimators[1].SetBool("View", true);
                if (!_audioSource.isPlaying) StartCoroutine(playScrollAudio(_audioClips[1], 0.5f));

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[2]);

                    scrollAnimators[1].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[2].length + .5f;
                    myScrollCount = ScrollCount.scroll3;
                }
                break;
            case ScrollCount.scroll3:
                scrollAnimators[2].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[2], 0.5f));

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[3]);

                    scrollAnimators[2].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[3].length + .5f;
                    myScrollCount = ScrollCount.scroll4;
                }
                break;
            case ScrollCount.scroll4:
                scrollAnimators[3].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[3], 0.5f));

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[4]);

                    scrollAnimators[3].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[4].length + .5f;
                    myScrollCount = ScrollCount.scroll5;
                }
                break;
            case ScrollCount.scroll5:
                scrollAnimators[4].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[4], 0.5f));


                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[5]);

                    scrollAnimators[4].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[5].length + .5f;
                    myScrollCount = ScrollCount.scroll6;
                }
                break;
            case ScrollCount.scroll6:
                scrollAnimators[5].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[5], 0.5f));

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[6]);

                    scrollAnimators[5].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[6].length + .5f;
                    myScrollCount = ScrollCount.scroll7;
                }
                break;
            case ScrollCount.scroll7:
                scrollAnimators[6].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[6], 0.5f));

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[7]);

                    scrollAnimators[6].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[7].length + .5f;
                    myScrollCount = ScrollCount.scroll8;
                }
                break;
            case ScrollCount.scroll8:
                scrollAnimators[7].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[7], 0.5f));

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[8]);

                    scrollAnimators[7].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[8].length + .5f;
                    myScrollCount = ScrollCount.scroll9;
                }
                break;
            case ScrollCount.scroll9:
                scrollAnimators[8].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[8], 0.5f));

                if (_Time > _nextClipPlayTime)
                {
                    _audioSource.Stop();
                    SetPlayerPosition(ScrollPositions[9]);

                    scrollAnimators[8].SetBool("View", false);
                    _nextClipPlayTime = _Time + _audioClips[9].length + .5f;
                    myScrollCount = ScrollCount.sacroll10;
                }
                break;
            case ScrollCount.sacroll10:
                scrollAnimators[9].SetBool("View", true);
                StartCoroutine(playScrollAudio(_audioClips[9], 0.5f));


                if (_Time > _nextClipPlayTime)
                {
                    _dynamicMoveProvider.enabled = true;
                    scrollAnimators[9].SetBool("View", false);
                    EnableScrollSequence = false;

                }
                break;
        }
    }
    IEnumerator playScrollAudio(AudioClip clip, float time)
    {
        _audioSource.clip = null;
        yield return new WaitForSeconds(time);
        if (!_audioSource.isPlaying || _audioSource.clip != clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
            Debug.Log(clip.name);
        }

    }

    private void SetPlayerPosition(Transform targetPosition)
    {
        player.position = targetPosition.position;
        player.rotation = targetPosition.rotation;

        _dynamicMoveProvider.enabled = false;
    }
}

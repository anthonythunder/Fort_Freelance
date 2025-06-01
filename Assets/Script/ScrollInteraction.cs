using System.Collections;
using UnityEngine;

public class ScrollInteraction : MonoBehaviour
{
    public GameObject Info_Buttons;
    public GameObject Open_Button;
    public GameObject Close_Button;

    public LayerMask playerMask;

    public AudioSource _audioSource;
    public AudioSource _scrollAudioSource;
    public AudioClip _bgAudioClip;
    public AudioClip _scrollAudioClip;

    public Animator _anim;
    private void Update()
    {
        bool CheckPlayer = Physics.CheckSphere(transform.position, 6, playerMask);
        Info_Buttons.SetActive(CheckPlayer);
    }
    public void OnclickInfoButton(bool value)
    {
        Open_Button.SetActive(!value);
        Close_Button.SetActive(value);

        _anim.SetBool("View", value);

        if (value)
        {
            StartCoroutine(playAudio(_scrollAudioSource, _scrollAudioClip, .5f));
        }
        else
        {
            _scrollAudioSource.Stop();
            _audioSource.volume = 1;
        }
    }
    IEnumerator playAudio(AudioSource source, AudioClip clip,float time)
    {
        yield return new WaitForSeconds(time);
        if (source != null && clip != null)
        {
            _audioSource.volume = 0.2f;
            source.PlayOneShot(clip);
        }
    }
}

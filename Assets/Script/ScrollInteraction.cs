using UnityEngine;

public class ScrollInteraction : MonoBehaviour
{
    public GameObject Info_Buttons;
    public GameObject Open_Button;
    public GameObject Close_Button;

    public LayerMask playerMask;


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
    }
}

using UnityEngine;

public class ButtonsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource  mySound;
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;

    public void HoverSound()
    {
        mySound.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        mySound.PlayOneShot(clickSound);
    }
}

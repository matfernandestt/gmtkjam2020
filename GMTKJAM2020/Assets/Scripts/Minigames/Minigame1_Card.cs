using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1_Card : MonoBehaviour
{
    [SerializeField] private MinigameTinderCard cardInfo;
    [SerializeField] private Image cardImage;
    [SerializeField] private Animator anim;

    public MinigameTinderCard GetCardData => cardInfo;
    
    private static readonly int RefuseTag = Animator.StringToHash("Refuse");
    private static readonly int AcceptTag = Animator.StringToHash("Accept");
    private static readonly int SuperLikeTag = Animator.StringToHash("SuperLike");

    private void OnEnable()
    {
        cardImage.sprite = cardInfo.img;
    }

    public void OnClickAccept()
    {
        anim.SetTrigger(AcceptTag);
    }

    public void OnClickRefuse()
    {
        anim.SetTrigger(RefuseTag);
    }
    
    public void OnClickSuperlike()
    {
        anim.SetTrigger(SuperLikeTag);
    }

    public void Accept()
    {
        Destroy(gameObject);
    }

    public void Refuse()
    {
        Destroy(gameObject);
    }
}

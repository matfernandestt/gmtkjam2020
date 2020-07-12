using System.Collections;
using UnityEngine;

public class MinigameTinderWorldCard : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private Renderer rend2;
    [SerializeField] private Rigidbody rb;

    public void SetTexture(Texture tex)
    {
        rend.material.mainTexture = tex;
        rend2.material.mainTexture = tex;

        IEnumerator Wait()
        {
            yield return null;
            rb.AddForce((transform.forward + -transform.right) * 4f, ForceMode.Impulse);
        }
        StartCoroutine(Wait());
    }
}

using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private LayerMask detectionMask;

    private Vector3 detectionPoint;
    private bool hasInSight;

    private GenericButton hoveredButton; 

    private void Awake()
    {
        GameInput.interactionDetection += UpdateDetection;
        GameInput.usedAction += OnButtonClick;
    }

    private void OnDestroy()
    {
        GameInput.interactionDetection -= UpdateDetection;
        GameInput.usedAction -= OnButtonClick;
    }

    private void OnButtonClick()
    {
        if (hoveredButton != null)
        {
            hoveredButton.ButtonClick();
        }
    }

    private void UpdateDetection()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * 20, out hit, 20f, detectionMask))
        {
            hasInSight = true;
            detectionPoint = hit.point;

            hoveredButton = hit.transform.GetComponent<GenericButton>();
        }
        else
        {
            hasInSight = false;
            hoveredButton = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (hasInSight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectionPoint, .2f);
        }
    }
}

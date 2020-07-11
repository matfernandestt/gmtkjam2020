using System;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    public static Action disableAllOutlines; 
    
    [SerializeField] private LayerMask detectionMask;

    private Vector3 detectionPoint;
    private bool hasInSight;
    private bool hasButtonOutlined;

    private GenericButton hoveredButton; 

    private void Awake()
    {
        GameInput.interactionDetection += UpdateDetection;
        GameInput.usedAction += OnButtonClick;
        
        disableAllOutlines?.Invoke();
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
            if (hoveredButton != null)
            {
                hasButtonOutlined = true;
                hoveredButton.OnHover();
            }
        }
        else
        {
            if (hasButtonOutlined)
            {
                disableAllOutlines?.Invoke();
                hasButtonOutlined = false;
            }
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

using System;
using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInput : MonoBehaviour
{
    // Events //
    public static Action<Vector2> cameraInput;
    public static Action<Vector2> movementInput;
    public static Action interactionDetection;
    public static Action usedAction;
    
    [SerializeField] private bool EnableCameraInput = true;
    [SerializeField] private bool EnableMovementInput = true;
    [SerializeField] private bool EnableInteraction = true;
    [SerializeField] private bool EnableAction = true;
    
    private Player input;

    private void Awake()
    {
        input = ReInput.players.GetPlayer(0);

        SceneManager.activeSceneChanged += OnSceneChange;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void OnSceneChange(Scene b, Scene a)
    {
        Fader.FadeOut();
    }

    private const string inputMovementVertical = "MoveVertical";
    private const string inputMovementHorizontal = "MoveHorizontal";
    private const string inputCameraVertical = "CameraVertical";
    private const string inputCameraHorizontal = "CameraHorizontal";
    private const string inputActionButton = "ActionButton";

    private void Update()
    {
        if (EnableCameraInput)
        {
            var inputs = new Vector2(input.GetAxis(inputCameraHorizontal), input.GetAxis(inputCameraVertical));
            cameraInput?.Invoke(inputs);
        }
        if (EnableMovementInput)
        {
            var inputs = new Vector2(input.GetAxis(inputMovementHorizontal), input.GetAxis(inputMovementVertical));
            movementInput?.Invoke(inputs);
        }
        if (EnableInteraction)
        {
            interactionDetection?.Invoke();
        }
        if (EnableAction)
        {
            if (input.GetButtonDown(inputActionButton))
            {
                usedAction?.Invoke();
            }
        }
    }
}

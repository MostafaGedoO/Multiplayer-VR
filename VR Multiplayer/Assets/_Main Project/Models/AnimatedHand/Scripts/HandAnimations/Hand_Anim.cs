using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cloves_Anim : NetworkBehaviour
{
    [SerializeField] private InputActionReference _tirggerValue;
    [SerializeField] private InputActionReference _grabValue;
    private Animator _handAnimator;

    private bool _readGrabValues;
    private bool _readTriggerValues;

    private void Awake()
    {
        _handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if(!IsOwner) return;
        
        //Reseting 
        _tirggerValue.action.Reset();
        _grabValue.action.Reset();

        _readGrabValues = false;
        _readTriggerValues = false;

        _handAnimator.SetFloat("Grip", 0);
        _handAnimator.SetFloat("Trigger", 0);

        _tirggerValue.action.started += StartTriggerReading;
        _grabValue.action.started += StartGrabReading;
        _tirggerValue.action.canceled += StopTriggerReading;
        _grabValue.action.canceled += StopGrabReading;

    }

    private void OnDisable()
    {
        if(!IsOwner) return;
        
        _tirggerValue.action.started -= StartTriggerReading;
        _grabValue.action.started -= StartGrabReading;
        _tirggerValue.action.canceled -= StopTriggerReading;
        _grabValue.action.canceled -= StopGrabReading;
    }


    private void Update()
    {
        if(!IsOwner) return;
        
        if (_readGrabValues)
        {
            float value = _grabValue.action.ReadValue<float>();
            _handAnimator.SetFloat("Grip", value);
        }
        else
        {
            _handAnimator.SetFloat("Grip", 0);
        }

        if (_readTriggerValues)
        {
            float value = _tirggerValue.action.ReadValue<float>();
            _handAnimator.SetFloat("Trigger", value);
        }
        else
        {
            _handAnimator.SetFloat("Trigger", 0);
        }
    }


    private void StopGrabReading(InputAction.CallbackContext obj)
    {
        _readGrabValues = false;
    }

    private void StopTriggerReading(InputAction.CallbackContext obj)
    {
        _readTriggerValues = false;
    }

    private void StartTriggerReading(InputAction.CallbackContext obj)
    {
        _readTriggerValues = true;
    }

    private void StartGrabReading(InputAction.CallbackContext obj)
    {
        _readGrabValues = true;
    }
}

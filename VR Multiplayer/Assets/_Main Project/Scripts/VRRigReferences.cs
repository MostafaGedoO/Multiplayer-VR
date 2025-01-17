using System;
using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    public static VRRigReferences Instance { get; private set; }
    
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private void Awake()
    {
        Instance = this;
    }
}

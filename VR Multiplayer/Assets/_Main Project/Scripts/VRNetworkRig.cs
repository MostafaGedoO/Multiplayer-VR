using System;
using Unity.Netcode;
using UnityEngine;

public class VRNetworkRig : NetworkBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private Transform head;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    private void Update()
    {
        if(!IsOwner) return;
        
        root.position = VRRigReferences.Instance.root.position;
        root.rotation = VRRigReferences.Instance.root.rotation;
        
        head.position = VRRigReferences.Instance.head.position;
        head.rotation = VRRigReferences.Instance.head.rotation;
        
        leftHand.position = VRRigReferences.Instance.leftHand.position;
        leftHand.rotation = VRRigReferences.Instance.leftHand.rotation;
        
        rightHand.position = VRRigReferences.Instance.rightHand.position;
        rightHand.rotation = VRRigReferences.Instance.rightHand.rotation;
    }
}

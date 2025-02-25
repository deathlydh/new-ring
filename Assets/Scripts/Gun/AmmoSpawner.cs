using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ammoRef;
    [SerializeField]
    private GameObject ammoSpawner;
    [SerializeField]
    private GameObject ammo;
    private XRGrabInteractable ammoGrab;
    
    public void SpawnAmmo(){
        ammo = Instantiate(ammoRef);
        ammoGrab = ammo.GetComponent<XRGrabInteractable>();
    }

    private void Start(){
        SpawnAmmo();
    }

    private void Update()
    {
        if (ammoGrab.isSelected)
            SpawnAmmo();
        if (ammo)
        {
            ammo.transform.position = ammoSpawner.transform.position;
            ammo.transform.rotation = ammoSpawner.transform.rotation;
        }
    }
}

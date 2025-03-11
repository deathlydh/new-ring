using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class autoShoot : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private XRGrabInteractable interactable;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject atcPoint;
    [SerializeField] private GameObject atcPs;
    [SerializeField] private float damage = 25f;
    private bool isShoot = false;

    [SerializeField] private ParticleSystem ps;
    [SerializeField] private ParticleSystem postAtcps;
    [SerializeField] private ParticleSystem atcWall;
    [SerializeField] private GameObject Ammopoint;

    [SerializeField] private Collider AmmoConnectCollider;
    //private Rigidbody rb;
    public AmmoController Ammo;

    void Start()
    {
        animator = GetComponent<Animator>();
//interactable = GetComponentInParent<XRGrabInteractable>();
    }

    void Update()
    {
        if (!interactable.isSelected || Ammo == null)
        {
            animator.SetBool("shoot", false);
        }
        
    }

    private void LateUpdate()
    {
        if (Ammo != null)
        {
            if (Ammo.gameObject.GetComponent<XRGrabInteractable>().isSelected)
            {
                //Ammo.UnConnect();
                //Ammo.gameObject.transform.SetParent(null);
                Ammo.UnConnect();
                Ammo = null;
                //rb = null;
            }
            else
            {
                //rb.position = Ammopoint.transform.position;
                //rb.rotation = Ammopoint.transform.rotation;
                Ammo.gameObject.transform.position = Ammopoint.transform.position;
                Ammo.gameObject.transform.rotation = Ammopoint.transform.rotation;
            }
        }
    }

    public void OnShoot()
    {
        Debug.Log("shoot");
        animator.SetBool("shoot", true);
        if (Ammo != null)
            Ammo.gameObject.GetComponentInChildren<Animator>().SetBool("shoot", true);
    }

    public void OnDeShoot()
    {
        animator.SetBool("shoot", false);
        if (Ammo != null)
            Ammo.gameObject.GetComponentInChildren<Animator>().SetBool("shoot", false);
    }

    private void endShoot()
    {
        postAtcps.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Magaxine");
        if (!other.CompareTag("Magazine"))
            return;
        Ammo = other.gameObject.GetComponent<AmmoController>();
        Ammo.Connect(this.gameObject);
    }

    private void Shoot()
    {
        if (!Ammo.IsCanShoot()) 
        {
            animator.SetBool("shoot", false);
            if (Ammo != null)
                Ammo.gameObject.GetComponentInChildren<Animator>().SetBool("shoot", false);
            return; 
        }

        audioSource.Play();
        ps.Play();
        postAtcps.Stop();
        RaycastHit hit;
        if (Physics.Raycast(atcPoint.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                Instantiate(atcPs, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(atcWall, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}

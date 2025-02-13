using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class autoShoot : MonoBehaviour
{
    private Animator animator;
    private XRGrabInteractable interactable;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject atcPoint;
    [SerializeField] private GameObject atcPs;
    [SerializeField] private float damage = 25f;
    private bool isShoot = false;

    [SerializeField] private ParticleSystem ps;
    [SerializeField] private ParticleSystem postAtcps;
    [SerializeField] private ParticleSystem atcWall;

    void Start()
    {
        animator = GetComponent<Animator>();
        interactable = GetComponentInParent<XRGrabInteractable>();
    }

    void Update()
    {
        if (!interactable.isSelected)
        {
            animator.SetBool("shoot", false);
        }
    }

    public void OnShoot()
    {
        Debug.Log("shoot");
        animator.SetBool("shoot", true);
    }

    public void OnDeShoot()
    {
        animator.SetBool("shoot", false);
        postAtcps.Play();
    }

    private void endShoot()
    {
        
    }
    private void Shoot()
    {
        audioSource.Play();
        ps.Play();
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

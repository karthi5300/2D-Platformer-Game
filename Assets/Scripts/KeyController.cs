using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private bool isPickedup = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            isPickedup = true;
            KeyAnimation();
            Destroy(gameObject, 0.5f);
        }
    }

    public void KeyAnimation()
    {
        if (isPickedup)
        {
            animator.SetBool("isPickedUp", true);
            isPickedup = false;
        }

    }

}

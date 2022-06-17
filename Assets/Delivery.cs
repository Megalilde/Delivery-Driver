using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;
    [SerializeField] float timeBeforeDestroy = 0.5F;


    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Hello");
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Package" && !hasPackage){
            Debug.Log("Get the Package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, timeBeforeDestroy);
        }
        if(other.tag == "Costumer" && hasPackage){
            Debug.Log("Package Delivered");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}

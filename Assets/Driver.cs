using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float driverSpeed = -200F;
    [SerializeField] float moveSpeed = 25F;
    [SerializeField] float slowSpeed = 15F;
    [SerializeField] float boostSpeed = 30F;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * driverSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
        print(moveSpeed);
    }
}

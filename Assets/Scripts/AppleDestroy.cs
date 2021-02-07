using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject oneHalf;
    [SerializeField]
    private GameObject otherHalf;
    [SerializeField]
    private float power = 150.0f;
   
   
    void OnTriggerEnter2D(Collider2D c)
    {

        if (GameController.Instance.LogDisplay.destroyBool == false)
        {
            if (c.gameObject.tag == "Knife")
            {
                GameController.Instance.GameUI.CatchApple();
                Destroy(this);
                GameObject ob1 = (GameObject)Instantiate(oneHalf);
                GameObject ob2 = (GameObject)Instantiate(otherHalf);
                ob1.GetComponent<Rigidbody2D>().AddForce(-transform.right * power);
                ob2.GetComponent<Rigidbody2D>().AddForce(transform.right * power);
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}

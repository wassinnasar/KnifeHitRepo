using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public bool boolean;
    public bool isLast;
    [SerializeField]
    private float _power = 1000;
    public bool currentVib = true;
    // Update is called once per frame
    void Start()
    {
        Vibration.Init();
       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (boolean == false)
            {
                if (GameController.Instance.GameUI.tapBool == true)
                {
                    isLast = GameController.Instance.LogDisplay.isLastKnife;
                    this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(
                    transform.up * _power);
                    GameController.Instance.GameUI.DecrementDisplayedKnifeCount();
                    GameController.Instance.AudioManager.KnifeAndTarget();
                }
                boolean = true;
            }
        }
        if (GameController.Instance.LogDisplay.destroyBool == true)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            transform.parent = null;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Wood")
        {
            GetComponent<ParticleSystem>().Play();
                this.transform.parent = col.transform;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            if(GameController.Instance.LogDisplay.destroyBool == false)
            GameController.Instance.GameUI.ActiveRestartButton();
            if (this.gameObject.tag == "Knife")
                GameController.Instance.AudioManager.KnifeAndKnife();
        }
        if (currentVib)
         {
                Vibration.Vibrate();
            currentVib = false;
         }
    }
    void OnCollisionExit2D(Collision2D co)
    {
        gameObject.tag = "Untagged";
    }
}

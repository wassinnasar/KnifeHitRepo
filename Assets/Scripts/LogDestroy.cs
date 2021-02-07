using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject onePieceOfLog;
    [SerializeField]
    private GameObject otherPieceOfLog;
    [SerializeField]
    private GameObject thirdPieceOfLog;
    [SerializeField]
    private GameObject fourthPieceOfLog;
    [SerializeField]
    private float power = 150.0f;
    
    void Start()
    {
        onePieceOfLog.GetComponent<SpriteRenderer>().sprite = GameController.Instance.LogDisplay.log.onePieceOfLog;
        otherPieceOfLog.GetComponent<SpriteRenderer>().sprite = GameController.Instance.LogDisplay.log.otherPieceOfLog;
        thirdPieceOfLog.GetComponent<SpriteRenderer>().sprite = GameController.Instance.LogDisplay.log.thirdPieceOfLog;
        fourthPieceOfLog.GetComponent<SpriteRenderer>().sprite = GameController.Instance.LogDisplay.log.fourthPieceOfLog;
    }
    // Update is called once per frame
    public void DestroyLog()
    {
        GameObject ob1 = (GameObject)Instantiate(onePieceOfLog);
        GameObject ob2 = (GameObject)Instantiate(otherPieceOfLog);
        GameObject ob3 = (GameObject)Instantiate(thirdPieceOfLog);
        GameObject ob4 = (GameObject)Instantiate(fourthPieceOfLog);
        ob1.GetComponent<Rigidbody2D>().AddForce(-transform.right * power);
        ob2.GetComponent<Rigidbody2D>().AddForce(transform.right * power);
        ob3.GetComponent<Rigidbody2D>().AddForce(-transform.up * power);
        ob4.GetComponent<Rigidbody2D>().AddForce(transform.up * power);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 knifePosition;
    [SerializeField]
    private Vector3 woodPos;
    [SerializeField]
    private float posX;
    [SerializeField]
    private float posY;
    [SerializeField]
    private float posZ;
    [SerializeField]
    private GameObject wood;
    [SerializeField]
    private float posYtoTrans = -1.5f;
    // Start is called before the first frame update
    void Start()
    {
        wood = GameObject.Find("Log") as GameObject;
        this.transform.parent = wood.transform;
        transform.Translate(0, posYtoTrans, 0);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().simulated = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (wood.GetComponent<LogDisplay>().destroyBool)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            transform.parent = null;
        }
    }
    
}

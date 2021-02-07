using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private GameObject apple;
    [SerializeField]
    private float posY;
    [SerializeField]
    private float posX;
    [SerializeField]
    private Transform go;
    [SerializeField]
    private Vector3 knifePos;
    [SerializeField]
    private Vector3 knifeRot;
    [SerializeField]
    private float degrees = 22;
    [SerializeField]
    private float result;
    [SerializeField]
    private int times;
    [SerializeField]
    private int testNum;
    [SerializeField]
    private int testGivenNum;
    [SerializeField]
    private int devideByNum;
    [SerializeField]
    private int[] knifeCases;
    [SerializeField]
    private bool ApplePercentageBool;
    [SerializeField]
    private int firstNum;
    [SerializeField]
    private int secondNum;
    [SerializeField]
    private int minKnivesQuantity = 1;
    [SerializeField]
    private int maxKnivesQuantity = 4;
    [SerializeField]
    private int applePlaceFrom = 10;
    [SerializeField]
    private int applePlaceTo = 15;
    // Start is called before the first frame update
    void Start()
    {
        testNum = testGivenNum / knifeCases.Length;
        firstNum = 1;
        secondNum = firstNum + testNum;
        for(int j = 0; j < knifeCases.Length; j++)
        {
            knifeCases[j] = Random.Range(firstNum, secondNum);
            firstNum += testNum;
            secondNum += testNum;
        }
        GameController.Instance.LogDisplay.log.CountApplePercentage();
        ApplePercentageBool = GameController.Instance.LogDisplay.log.appleBool;
        posX = transform.position.x;
        posY = transform.position.y;
        knifePos = new Vector3(posX, posY, 0);
         int knivesCount = Random.Range(minKnivesQuantity, maxKnivesQuantity);
       for(int i = 0; i < knivesCount; i++)
        {
            print(i);
            result = degrees * knifeCases[i];
            GameObject g = Instantiate(knife, knifePos, go.transform.rotation *= Quaternion.Euler(0f, 0f, result)) as GameObject;
        g.gameObject.tag = "Untagged";
        g.AddComponent<AdditionalBehaviour>();
        }
        if (ApplePercentageBool == true)
        {
            times = Random.Range(applePlaceFrom, applePlaceTo);
            result = degrees * times;
            GameObject gAp = Instantiate(apple, knifePos, go.transform.rotation *= Quaternion.Euler(0f, 0f, result)) as GameObject;
            gAp.AddComponent<AdditionalBehaviour>();
        }
    }
}

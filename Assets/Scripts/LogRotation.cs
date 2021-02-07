using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogRotation : MonoBehaviour
{
    [SerializeField]
    private float minPouseTime;
    [SerializeField]
    private float maxPouseTime;
    [SerializeField]
    private float minRotationTime;
    [SerializeField]
    private float maxRotationTime;
    [SerializeField]
    private float minRotationSpeed;
    [SerializeField]
    private float maxRotationSpeed;
    [SerializeField]
    private float minPouseSpeed;
    private float maxPouseSpeed;
    private float PouseTime;
    private float RotationTime;
    private float RotationSpeed;
    private float PouseSpeed;
    private float Speed;
    [SerializeField]
    private bool isDirChangeable;
    [SerializeField]
    private int intForIsDirChangeable = 1;
    [SerializeField]
    private float StartTime = 0.4f;
    void Start()
    {
     minPouseTime = GameController.Instance.LogDisplay.log.minLogPouseTime;
     maxPouseTime = GameController.Instance.LogDisplay.log.maxLogPouseTime;
     minRotationTime = GameController.Instance.LogDisplay.log.minLogRotationTime;
     maxRotationTime = GameController.Instance.LogDisplay.log.maxLogRotationTime;
     minRotationSpeed = GameController.Instance.LogDisplay.log.minLogRotationSpeed;
     maxRotationSpeed = GameController.Instance.LogDisplay.log.maxLogRotationSpeed;
     minPouseSpeed = GameController.Instance.LogDisplay.log.minLogPouseSpeed;
        intForIsDirChangeable = GameController.Instance.LogDisplay.log.intForDirChange;
        isDirChangeable = GameController.Instance.LogDisplay.log.dirChangeBool;
        RotationTime = Random.Range(minRotationTime, maxRotationTime);
        RotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        StartCoroutine(StartCoroutine());
        StartCoroutine(Rotation());
    }
    void Update()
    {
        transform.Rotate(0, 0, Speed);
    }
    private IEnumerator Pouse()
    {
        yield return new WaitForSeconds(PouseTime);
        RotationTime = Random.Range(minRotationTime,maxRotationTime);
        RotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        if (isDirChangeable)
        {
            int fall = Random.Range(0, intForIsDirChangeable);
            if (fall == 0)
            {
                Speed = -RotationSpeed;
            }
            else
            {
                Speed = RotationSpeed;
            }
        }
        StartCoroutine(Rotation());
    }
    private IEnumerator Rotation()
    {
        yield return new WaitForSeconds(RotationTime);
        PouseTime = Random.Range(minPouseTime,maxPouseTime);
        PouseSpeed = Random.Range(minPouseSpeed, maxPouseSpeed);
        Speed = PouseSpeed;
        StartCoroutine(Pouse());
    }
    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(StartTime);
        Speed = RotationSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDisplay : MonoBehaviour
{
    public Log log;
    [SerializeField]
    private Animator camShake;
    [SerializeField]
    private Spawner sp = new Spawner();
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private CircleCollider2D circleCollider2D;
    public int goal = 10;
    [SerializeField]
    private int carrentInt = 0;
    public bool destroyBool;
    public int allKnives;
    public bool isLastKnife;
    [SerializeField]
    private GameObject ActiveContinueButton;
    private int recordKni = 0;
    [SerializeField]
    private float speed = 300f;
    // Start is called before the first frame update
    void Awake()
    {
        Vibration.Init();
        recordKni = PlayerPrefs.GetInt("RK");
        GetComponent<SpriteRenderer>().sprite = log.masterPiece;
        goal = log.knivesNeeded;
        allKnives = PlayerPrefs.GetInt("AK");
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.circleCollider2D = GetComponent<CircleCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Knife")
        {
            carrentInt++;
            allKnives++;
            if (carrentInt < goal)
            {
                sp.Spawn();
                sp.enabled = false;
            }
            if (allKnives > recordKni)
            {
                recordKni = allKnives;
            }
            camShake.SetTrigger("shake");
            if (carrentInt == goal)
            {
                if (GameController.Instance.GameUI.tapBool == true)
                {
                    GameController.Instance.AudioManager.KnifeAndWreck();
                    destroyBool = true;
                    Destroy();
                    c.gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
                    StartCoroutine(Corout(c.gameObject));
                }
            }
            PlayerPrefs.SetInt("AK", allKnives);
            PlayerPrefs.SetInt("RK", recordKni);
        }
    }
    public void Destroy()
    {
        GameController.Instance.LogDestroy.DestroyLog();
        Vibration.Vibrate();
        print("bam");
        this.spriteRenderer.enabled = false;
        circleCollider2D.isTrigger = true;
    }
    private IEnumerator Corout(GameObject c)
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(c);
        yield return new WaitForSeconds(1.5f);
        ActiveContinueButton.SetActive(true);
        Vibration.Vibrate();
    }
}

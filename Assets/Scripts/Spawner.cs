using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private bool instantianeKnife;
    [SerializeField]
    private float posY;
    [SerializeField]
    private float posX;
    [SerializeField]
    private GameObject go;
    [SerializeField]
    private Vector3 knifePos;
    [SerializeField]
    private float sec = 1.0f;
    [SerializeField]
    private bool winBool;
    [SerializeField]
    private Sprite knifeArt;
    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        knifePos = new Vector3(posX, posY, 0);
        Spawn();
    }
    void Update()
    {
        winBool = GameController.Instance.LogDisplay.destroyBool;
    }
    public void Spawn()
    {
        StartCoroutine(ToSpawn());
    }
    private IEnumerator ToSpawn()
    {
        yield return new WaitForSeconds(sec);
        GameObject g = Instantiate(knife, knifePos, Quaternion.identity) as GameObject;
        g.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        g.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        g.gameObject.GetComponent<SpriteRenderer>().sprite = knifeArt;
        g.AddComponent<Knife>();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SlimeSpawnBall : MonoBehaviour
{
    public GameObject slime;
    public bool isWait = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") return;
        //StartCoroutine(waitForTask());
        GameObject bul = (GameObject)Instantiate(slime, transform.position, Quaternion.identity);
        bul.transform.localScale = new Vector3(40, 40, 40);
        Destroy(gameObject);
        
    }
    //private IEnumerator waitForTask()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Destroy(this.gameObject);


    //}
}

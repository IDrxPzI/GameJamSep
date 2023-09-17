using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SlimeSpawnBall : MonoBehaviour
{
    public GameObject slime;
    public bool isWait = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") return;
        //StartCoroutine(waitForTask());
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player_Getroffen");
            other.gameObject.GetComponent<PlayerMovement>().GetDmg(10);
        }
        else
        {
            GameObject bul = (GameObject)Instantiate(slime, transform.position, Quaternion.identity);
            bul.transform.localScale = new Vector3(40, 40, 40);
            bul.transform.parent = GameObject.FindGameObjectWithTag("LevelManager").transform;
        }
        Destroy(gameObject);
        
    }
    //private IEnumerator waitForTask()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Destroy(this.gameObject);


    //}
}

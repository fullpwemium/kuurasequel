using UnityEngine;
using System.Collections;

public class SceneGenerate : MonoBehaviour
{
    public ObjectPool[] Objectpools;
    GameObject newPlatform;
    int a = -1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            a += 1;
            GameObject stage = other.gameObject;
            Transform spawnLocation = stage.transform.parent.Find("SpawnLocation");
            //GameObject obj = Instantiate (stageCollection [Random.Range (0, objectpools.Length)], spawnLocation.position, Quaternion.identity) as GameObject;

            newPlatform = Objectpools[a].GetPooledObject(); //Jostain syystä heittää harvoin erroria että "Array index is out
                                                            //of range" ensimmäisessä kentässä. Silti PooledObject näyttäisi
                                                            //ilmestyvän ihan normaalisti, joten en tajua miksi valittaa. -Aleksi
            newPlatform.transform.position = spawnLocation.transform.position;
            newPlatform.transform.rotation = spawnLocation.transform.rotation;
            newPlatform.SetActive(true);
            /*Transform coinmanager = newPlatform.transform.FindChild ("SceneManager");
			foreach (Transform coin in coinmanager) {	
				coin.gameObject.SetActive (true);
			}*/
        }
        if (other.gameObject.tag == "SpawnLocation")
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }




}

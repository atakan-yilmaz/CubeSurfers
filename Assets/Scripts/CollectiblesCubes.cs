using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesCubes : MonoBehaviour
{
    bool isCollectible;
    int index;
    public Collector collector;

    void Start()
    {
        isCollectible = false;
    }


    //toplanan kuplerin duzenli bir sekilde ayni hizada olmasini saglayan kod 
    void Update()
    {
        if (isCollectible == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }

    //engele carpan kuplerin azalmasi icin gereken kod 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "barrier")
        {
            collector.DecreaseHeight();
            this.transform.parent = null;

            //carpisan objelerin componentini kapatmak icin yazilan kod
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //bool private oldugundan ona ulasmamiz icin yazdigim fonksiyon
    public bool GetIsCollectible()
    {
        return isCollectible;
    }

    public void doCollectible()
    {
        isCollectible = true;
    }

    public void IndexTools(int index)
    {
        this.index = index; 
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collector : MonoBehaviour
{
    GameObject mainCube;
    int height;

    void Start()
    {
        mainCube = GameObject.Find("MainCube");
    }

    void Update()
    {
        //her yerden yukseldigimizde cubeun de yerden yukselmesini istedigim icin yazdigim kod
        mainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);


        //cubeler collect edildikce yukselecek fakat birinci cubeun sabit kalmasini istedigim icin yazdigim kod.
        this.transform.localPosition = new Vector3(0, -height, 0);
    }

    //yuksekligin azalmasi icin yazilan kod
    public void DecreaseHeight()
    {
        height--;
    }


    //main cube carptiginda yerden yuksekligini saglayacak olan kod 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="collect" && other.gameObject.GetComponent<CollectiblesCubes>().GetIsCollectible() == false)
        {
            height += 1;
            other.gameObject.GetComponent<CollectiblesCubes>().doCollectible();
            other.gameObject.GetComponent<CollectiblesCubes>().IndexTools(height);
            other.gameObject.transform.parent = mainCube.transform;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBox : MonoBehaviour
{
    public GameObject box1;
    public GameObject box2;
    public GameObject Coin;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        box1.SetActive(true);
        box2.SetActive(false);
        if (Coin != null)
        {
            Coin.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Mario"))
        {

            box1.SetActive(false);
            box2.SetActive(true);

            if (box1.gameObject.name.Contains("Question"))
            {
                if (Coin != null)
                {
                    Coin.SetActive(true);
                }
                anim.SetTrigger("Crush");
            }

            if (box1.gameObject.name.Contains("Brick"))
            {
                anim.SetTrigger("Break");
                Destroy(gameObject, 1f);
                MeshCollider[] meshco = gameObject.GetComponents<MeshCollider>();
                meshco[1].enabled = false;


            }
        }
    }
}




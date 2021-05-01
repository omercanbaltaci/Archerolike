using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 5f)
        {
            anim.SetBool("thrust", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag(other.tag))
            Debug.Log("oyuuncu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Slider>().value <= 0)
            Destroy(gameObject);

        gameObject.GetComponent<Slider>().GetComponentInChildren<Text>().text = (gameObject.GetComponent<Slider>().value * 100).ToString();
    }
}

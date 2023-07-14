using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private GameObject Star3;

    public void StarUpdate(int starCount)
    {
        switch (starCount)
        {
            case 1:
                Star1.SetActive(true);
                break;
            case 2:
                Star2.SetActive(true);
                break;
            case 3:
                Star3.SetActive(true);
                break;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

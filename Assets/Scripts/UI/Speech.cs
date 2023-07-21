using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    [SerializeField] GameObject imageKey;
    [SerializeField] GameObject imageStar;
    [SerializeField] GameObject imageArrow;
    public void ShowTutorial(GameObject _image, Direction _direction)
    {   
        gameObject.SetActive(true);
        StartCoroutine(Show(_image, _direction));
    }

    IEnumerator Show(GameObject _image, Direction _direction)
    {
        if (_image.CompareTag("Star"))
        {
            imageStar.SetActive(true);
        }
        else if (_image.CompareTag("Key"))
        {
            imageKey.SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);
        if(_image.CompareTag("Star"))
        {
            imageStar.SetActive(false);
        }
        else if (_image.CompareTag("Key"))
        {
            imageKey.SetActive(false);
        }
        imageArrow.SetActive(true);
        switch (_direction)
        {
            case Direction.Up:
                imageArrow.transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
            case Direction.Down:
                imageArrow.transform.localRotation = Quaternion.Euler(0, 0, 270);
                break;
            case Direction.Left:
                imageArrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break; 
            case Direction.Right:
                imageArrow.transform.localRotation= Quaternion.Euler(0, 0, 180);
                break;
        }
        
        
        yield return new WaitForSeconds(0.5f);
        imageArrow.SetActive(false);
        imageArrow.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.SetActive(false);
    }

}

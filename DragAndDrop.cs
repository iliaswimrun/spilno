using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    private bool _spaced = false;
 
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        if (_spaced)
        {
            mousePosition = Input.mousePosition - GetMousePos();
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _spaced = true;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            _spaced = false;
        }
    }


    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}

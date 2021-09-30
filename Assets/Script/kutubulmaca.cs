using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR;

public class kutubulmaca : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    string JointChecker()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit))
        {
            return hit.collider.gameObject.name;
        }

        return null;
    }

    private void OnMouseUp()
    {
        Moving(JointChecker());
    }

    void Moving(string name)
    {
        switch (name)
        {
            case ("anahtar1"):
                GameObject.FindGameObjectWithTag("Anahtar1").transform.DOMove(new Vector3(1, 1, 1), 0.5f);
                break;
            case ("anahtar2"):
                GameObject.FindGameObjectWithTag("Anahtar2").transform.DOMove(new Vector3(1, 1, 1), 0.5f);
                break;
            case ("anahtar3"):
                GameObject.FindGameObjectWithTag("Anahtar3").transform.DOMove(new Vector3(1, 1, 1), 0.5f);
                break;
            case ("anahtar4"):
                GameObject.FindGameObjectWithTag("Anahtar4").transform.DOMove(new Vector3(3.12f, 5.93f, -7f), 2f);
                break;
            case ("anahtar5"):
                GameObject.FindGameObjectWithTag("Anahtar5").transform.DOMove(new Vector3(3.12f, 4.76f, -7f), 2f);
                break;
            case ("anahtar6"):
                GameObject.FindGameObjectWithTag("Anahtar6").transform.DOMove(new Vector3(-10.07f, 5.93f, -7), 2f);
                break;
            case ("anahtar7"):
                GameObject.FindGameObjectWithTag("Anahtar7").transform.DOMove(new Vector3(3.12f, 7.54f, -7f), 2f);
                break;
            case ("anahtar8"):
                GameObject.FindGameObjectWithTag("Anahtar8").transform.DOMove(new Vector3(3.79f, 7.02f, -7f), 2f);
                break;


        }
    }
}

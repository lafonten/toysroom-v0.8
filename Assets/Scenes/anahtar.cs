using DG.Tweening;
using UnityEngine;

public class anahtar : MonoBehaviour
{
    public GameObject ActualGameObject;
    public Transform targetPosition;
    public Vector3 initialposition;

    private int ClickNumber = 0;

    void Start()
    {
        initialposition = transform.position;
    }

    void Update()
    {
        
    }

    //private void OnMouseDown()
    //{
    //    if (ClickNumber == 0)
    //    {
    //        transform.DOMove(targetPosition.position, 2f);
    //        ClickNumber++;
    //    }else if (ClickNumber == 1)
    //    {
    //        transform.DOMove(initialposition, 2f);
    //        ClickNumber--;
    //    }

    //}

    public void Click()
    {
        if (ClickNumber == 0)
        {
            ActualGameObject.transform.DOMove(targetPosition.position, 2f);
            ClickNumber++;
        }
        else if (ClickNumber == 1)
        {
            transform.DOMove(initialposition, 2f);
            ClickNumber--;
        }
    }
}

using DG.Tweening;
using UnityEngine;

public class rabbitControler : MonoBehaviour
{

    public float rotationSpeed;
    public bool dragging;
    public static rabbitControler rabbitInstance;
    public bool winsituation = false;
    public bool GetMobileInput = false;

    void Start()
    {
        rabbitInstance = this;
        
        
    }
    
    void Update()
    {
        Debug.Log("Rabbit Win = " + WinRabbit());
    }

    private void OnMouseDrag()
    {

        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
        ProximityChecker();
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            RotateYaxis();
            RotateZaxis();
        }
    }

    void ProximityChecker()
    {
        float Xoffset = Mathf.Abs(Mathf.Abs(transform.rotation.eulerAngles.x) - 315);
        float Yoffset = Mathf.Abs(Mathf.Abs(transform.rotation.eulerAngles.y) - 270);

        if (Xoffset < 10)
        {
            transform.DORotate(new Vector3(315, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z),
                1f);
            winsituation = true;
        }

        if (Yoffset < 10)
        {
            transform.DORotate(new Vector3(transform.rotation.eulerAngles.x, 270, transform.rotation.eulerAngles.z),
                1f);
            winsituation = true;
        }
    }

    void RotateZaxis()
    {
        float rotationX = 0;

        if (GetMobileInput)
        {
            if (Input.touchCount > 0)
            {
                Touch lastTouch = Input.touches[0];
                rotationX = lastTouch.deltaPosition.x * rotationSpeed;

            }
        }
        else
        {
            rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
        }



        this.transform.RotateAround(Vector3.forward, -rotationX);
    }

    void RotateYaxis()
    {
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
        this.transform.RotateAround(Vector3.right, rotationY);
    }

    public bool WinRabbit()
    {
        if (winsituation)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

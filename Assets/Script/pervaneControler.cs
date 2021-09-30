using UnityEngine;

public class pervaneControler : MonoBehaviour
{
    public float rotationSpeed;
    public int angleC;
    public float rotateSpeed;
    public bool dragging;
    public Rigidbody rb;
    public GameObject helikopterBody;
    public float rotationX;
    public static pervaneControler PervaneInstance;
    public Transform joint;


    void Start()
    {
        PervaneInstance = this;
        helikopterBody = GameObject.FindWithTag("Helikopter");
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        
        RegularlyRotate();
        FlyForce();
        Debug.Log("Helicopter Win = " + WinHelicopter());
    }

    private void OnMouseDrag()
    {
        rotate();
        dragging = true;
        angleC++;
        rotateSpeed = angleC / 30;
        Debug.Log("dargggg");
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    void rotate()
    {
        rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
        
        this.transform.RotateAround(Vector3.up, -rotationX);
        
        rotateSpeed = -rotationX;
    }

    void RegularlyRotate()
    {
        transform.Rotate(0,0,rotateSpeed);
    }

    void FlyForce()
    {
        rb.AddForce(Vector3.up * rotateSpeed  );
        helikopterBody.GetComponent<Rigidbody>().AddForce(Vector3.up * rotateSpeed );
    }

    public bool WinHelicopter()
    {
        if (helikopterBody.transform.position.y >= 30)
        {
            Destroy(helikopterBody);
            return true;
        }

        return false;
    }
}

using DG.Tweening;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar instance;
    public float RotationSpeed;
    public bool dragging = false;
    public bool StillRotating = false;
    public bool startRotation = false;
    public int randomNumber;

    public GameObject glasses;

    void Start()
    {
        instance = this;
        randomNumber = UnityEngine.Random.Range(1, 16);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        GiveInformationAboutRotationAngel();

    }

    private void OnMouseDrag()
    {
        dragging = true;
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            Rotate2();
        }

    }

    private void OnMouseUp()
    {
        SnapRotation();
        startRotation = false;
    }

    private void OnMouseDown()
    {
        startRotation = true;
    }

    void Rotate2()
    {
        float rotationX = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
        this.transform.RotateAround(Vector3.right, -rotationX);
    }

    void Rotate1()
    {
        float horizontal = Input.GetAxis("Mouse X");
        this.transform.Rotate(transform.forward, (horizontal * RotationSpeed * Time.deltaTime), Space.World);
    }

    void SnapRotation()
    {
        if (GiveInformationAboutRotationAngel() == "side 1")
        {
            transform.DORotate(new Vector3(0, 0, 0), 1f);
            StillRotating = false;

        }
        else if (GiveInformationAboutRotationAngel() == "side 2" || GiveInformationAboutRotationAngel() == "side 4")
        {
            StillRotating = true;
        }

        else if (GiveInformationAboutRotationAngel() == "side 3")
        {
            transform.DORotate(new Vector3(0, 0, 180), 1f);
            StillRotating = false;
        }

        else if (GiveInformationAboutRotationAngel() == "side 5")
        {
            transform.DORotate(new Vector3(0, 0, 360), 1f);
            StillRotating = false;
        }
    }

    string GiveInformationAboutRotationAngel()
    {

        if (this.transform.rotation.eulerAngles.z > 0 && this.transform.rotation.eulerAngles.z <= 60)
        {
            return "side 1";
        }
        else if (this.transform.rotation.eulerAngles.z > 60 && this.transform.rotation.eulerAngles.z < 120)
        {
            return "side 2";
        }
        else if (this.transform.rotation.eulerAngles.z >= 120 && this.transform.rotation.eulerAngles.z <= 240)
        {
            return "side 3";
        }
        else if (this.transform.rotation.eulerAngles.z > 240 && this.transform.rotation.eulerAngles.z < 300)
        {
            return "side 4";
        }
        else if (this.transform.rotation.eulerAngles.z >= 300 && this.transform.rotation.eulerAngles.z <= 360)
        {
            return "side 5";
        }
        else
        {
            return null;
        }
    }

}

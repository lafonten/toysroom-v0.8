using UnityEngine;

public class helikopterControler : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        force();
    }

    void force()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * pervaneControler.PervaneInstance.rotationX);
    }
}

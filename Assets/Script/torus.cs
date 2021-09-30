using DG.Tweening;
using UnityEngine;

public class torus : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Rotation_circle();
    }

    void Rotation_circle()
    {
        if (!SceneManager.sceneManagerInstance.CameraPosition())
        {
            transform.Rotate(0,0,1);
        }
    }
}

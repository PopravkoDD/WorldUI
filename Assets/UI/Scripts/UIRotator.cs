using UnityEngine;

public class InWorldUIController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void LateUpdate()
    {
        Vector3 rotation = _camera.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalMaskScript : MonoBehaviour
{
    Camera _camera;
    RaycastHit _hit;
    Ray _ray;
    Vector3 _smoothPoint;
    

    public float _radius, _softness, _smoothSpeed, _scaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _radius += _scaleFactor * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _radius -= _scaleFactor * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _softness += _scaleFactor * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _softness -= _scaleFactor * Time.deltaTime;
        }
        Mathf.Clamp(_radius, 0, 100);
        Mathf.Clamp(_softness, 0, 100);


        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 _playerPos = player.transform.position;
        _ray = _camera.ScreenPointToRay(_playerPos);

        if(Physics.Raycast(_ray, out _hit))
        {
            _smoothPoint = Vector3.MoveTowards(_smoothPoint, _hit.point, _smoothSpeed * Time.deltaTime);
            Vector4 pos = new Vector4(_smoothPoint.x, _smoothPoint.y, _smoothPoint.z, 0);
            Shader.SetGlobalVector("GLOBALmask_Position", _playerPos);
        }
        Shader.SetGlobalFloat("GLOBALmask_Radius", _radius);
        Shader.SetGlobalFloat("GLOBALmask_Softness", _softness);
    }
}

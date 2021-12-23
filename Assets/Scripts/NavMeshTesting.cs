using System.Collections.Generic;
using DroneBase.Interfaces;
using DroneBase.Views;
using UnityEngine;

namespace DroneBase
{
    public class NavMeshTesting : MonoBehaviour
    {
        
        [SerializeField] private DroneView _droneView;
        [SerializeField] private GameObject _point;
        [SerializeField] private Material _material;
        private Queue<GameObject> _points = new Queue<GameObject>();
        private Vector3 _position;
        private readonly Color _c1 = Color.red;
        private readonly Color _c = Color.red;
        private readonly int lengthOfLineRenderer = 2;
        private LineRenderer _lineRenderer;

        private void Start()
        {
            _lineRenderer = gameObject.AddComponent<LineRenderer>();
            _lineRenderer.SetWidth(0.5F, 0.5F);
            _lineRenderer.material = _material;// new Material(Shader.Find("Particles/Additive"));
            _lineRenderer.SetColors(_c, _c1);
            _lineRenderer.SetVertexCount(lengthOfLineRenderer);
            _lineRenderer.SetPosition(0, _droneView.transform.position);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    DrawPoint(hit.point);
                }
            }

            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                _position = hitInfo.point;
            }

            _lineRenderer.SetPosition(1, _position);
        }

        private void DrawPoint(Vector3 position)
        {
            GameObject tempPoint = Instantiate(_point, position, Quaternion.identity) as GameObject;
            _points.Enqueue(tempPoint);
            _lineRenderer.SetPosition(0, tempPoint.transform.position);
        }

        private void GotoNextPoint() // Вызов данной функции будет в домашнем задании
        {
           // _agent.SetTarget(_points.Dequeue().transform);
        }
    }
}
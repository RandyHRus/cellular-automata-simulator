using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController: MonoBehaviour
{
    [SerializeField] private int scrollSpeed = 20;
    
    private Vector3 m_DragOrigin;

    private Camera m_Camera;
    private Transform m_CameraTransform;
    
    private void Awake()
    {
        m_Camera = Camera.main;
        m_CameraTransform = m_Camera.transform;
    }

    public void Update()
    {
        Drag();
        Zoom();
    }

    private void Drag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            m_DragOrigin = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            return;
        }

        if (!Input.GetMouseButton(1)) return;

        m_CameraTransform.position = m_CameraTransform.position - (m_Camera.ScreenToWorldPoint(Input.mousePosition) - m_DragOrigin);
    }

    private void Zoom()
    {
        m_Camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
    }
}
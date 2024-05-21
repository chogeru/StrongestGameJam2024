using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;
    [SerializeField]
    private int num = 0;
    private Renderer m_Renderer;
    private float alfa=0;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(m_Renderer.material.color.a <= 0))
        {
            m_Renderer.material.color = new Color(
                m_Renderer.material.color.r,
                m_Renderer.material.color.g,
                m_Renderer.material.color.b, alfa);
        }
        if (num == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                ColorChange();
            }
        }
        if (num == 2)
        {
            if (Input.GetKey(KeyCode.F))
            {
                ColorChange();
            }
        }
        if (num == 3)
        {
            if (Input.GetKey(KeyCode.J))
            {
                ColorChange();
            }
        }
        if (num == 4)
        {
            if (Input.GetKey(KeyCode.K))
            {
                ColorChange();
            }
        }
        alfa -= m_Speed * Time.deltaTime;
    }
    private void ColorChange()
    {
        alfa = 0.3f;
        m_Renderer.material.color = new Color(
            m_Renderer.material.color.r,
            m_Renderer.material.color.g,
            m_Renderer.material.color.b, alfa);
    }
}

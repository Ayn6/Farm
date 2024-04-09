using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBed : MonoBehaviour
{
    public GameObject prefab; // ������ �������, ������� ����� �������

    private void Update()
    {


        if (Input.GetMouseButtonDown(0)) // ��������� ������� ����� ������ ����
        {
            // �������� ������� ������� ���� � ������� �����������
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f; // ������������� z-����������, ����� ������ ��� �� ����� ��������� � �������

            // ������� ������ �� ������� ������� ���� � ������� Instantiate
            Instantiate(prefab, clickPosition, Quaternion.identity);
        }


    }

}

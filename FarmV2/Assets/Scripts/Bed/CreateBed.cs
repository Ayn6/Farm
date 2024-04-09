using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBed : MonoBehaviour
{
    public GameObject prefab; // Префаб объекта, который нужно создать

    private void Update()
    {


        if (Input.GetMouseButtonDown(0)) // Проверяем нажатие левой кнопки мыши
        {
            // Получаем позицию нажатия мыши в мировых координатах
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0f; // Устанавливаем z-координату, чтобы объект был на одной плоскости с камерой

            // Создаем объект на позиции нажатия мыши с помощью Instantiate
            Instantiate(prefab, clickPosition, Quaternion.identity);
        }


    }

}


using UnityEngine;
using UnityEngine.UI;

public class VRtest : MonoBehaviour
{
    public GameObject targetObject; // Объект для переключения 
    public Button toggleButton; // Кнопка для управления 
    private bool isJumping = false; // Флаг для отслеживания прыжка
    public float jumpHeight = 2f; // Высота прыжка
    public float jumpDuration = 1f; // Длительность прыжка
    private float jumpStartTime; // Время начала прыжка
    private Vector3 startPosition; // Начальная позиция куба

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleJump);
        startPosition = targetObject.transform.position; // Сохраняем начальную позицию
    }

    void ToggleJump()
    {
        isJumping = !isJumping; // Меняем флаг прыжка
        if (isJumping)
        {
            jumpStartTime = Time.time; // Запоминаем время начала прыжка
        }
        else
        {
            targetObject.transform.position = startPosition; // Возвращаем куб на начальную позицию
        }
    }

    void Update()
    {
        if (isJumping)
        {
            // Вычисляем высоту прыжка в зависимости от времени
            float jumpProgress = (Time.time - jumpStartTime) / jumpDuration;
            float jumpHeightFactor = Mathf.Sin(Mathf.PI * jumpProgress);
            targetObject.transform.position = startPosition + Vector3.up * jumpHeight * jumpHeightFactor;

            // Если достигнуто время одного прыжка, запускаем новый
            if (jumpProgress >= 1f)
            {
                jumpStartTime = Time.time; // Запоминаем время начала нового прыжка
            }
        }
    }
}
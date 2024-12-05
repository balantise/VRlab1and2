
using UnityEngine;
using UnityEngine.UI;

public class VRtest : MonoBehaviour
{
    public GameObject targetObject; // ������ ��� ������������ 
    public Button toggleButton; // ������ ��� ���������� 
    private bool isJumping = false; // ���� ��� ������������ ������
    public float jumpHeight = 2f; // ������ ������
    public float jumpDuration = 1f; // ������������ ������
    private float jumpStartTime; // ����� ������ ������
    private Vector3 startPosition; // ��������� ������� ����

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleJump);
        startPosition = targetObject.transform.position; // ��������� ��������� �������
    }

    void ToggleJump()
    {
        isJumping = !isJumping; // ������ ���� ������
        if (isJumping)
        {
            jumpStartTime = Time.time; // ���������� ����� ������ ������
        }
        else
        {
            targetObject.transform.position = startPosition; // ���������� ��� �� ��������� �������
        }
    }

    void Update()
    {
        if (isJumping)
        {
            // ��������� ������ ������ � ����������� �� �������
            float jumpProgress = (Time.time - jumpStartTime) / jumpDuration;
            float jumpHeightFactor = Mathf.Sin(Mathf.PI * jumpProgress);
            targetObject.transform.position = startPosition + Vector3.up * jumpHeight * jumpHeightFactor;

            // ���� ���������� ����� ������ ������, ��������� �����
            if (jumpProgress >= 1f)
            {
                jumpStartTime = Time.time; // ���������� ����� ������ ������ ������
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReacherGoal_Test : MonoBehaviour
{
    [Header("Goal Settings")]
    public GameObject goal;       // توپ هدف
    public float m_GoalHeight = 1.2f;  // ارتفاع ثابت هدف

    float m_GoalRadius;
    float m_GoalDegree;
    float m_GoalSpeed;
    float m_GoalDeviation;
    float m_GoalDeviationFreq;

    void Start()
    {
        SetResetParameters();
    }

    /// <summary>
    /// مقادیر اولیه رندوم برای حرکت هدف
    /// </summary>
    public void SetResetParameters()
    {
        m_GoalRadius = Random.Range(1f, 1.3f);       // شعاع دایره
        m_GoalDegree = Random.Range(0f, 360f);       // زاویه شروع
        m_GoalSpeed = Random.Range(-90f, 90f);       // سرعت زاویه‌ای (درجه بر ثانیه)
        m_GoalDeviation = Random.Range(-0.5f, 0.5f); // دامنه نوسان ارتفاع
        m_GoalDeviationFreq = Random.Range(0.5f, 2f);// فرکانس نوسان
    }

    void Update()
    {
        // زاویه رو با سرعت تغییر بده
        m_GoalDegree += m_GoalSpeed * Time.deltaTime;

        // به‌روز رسانی موقعیت توپ
        UpdateGoalPosition();
    }

    /// <summary>
    /// محاسبه و اعمال موقعیت هدف
    /// </summary>
    void UpdateGoalPosition()
    {
        float m_GoalDegree_rad = m_GoalDegree * Mathf.PI / 180f;

        float goalX = m_GoalRadius * Mathf.Cos(m_GoalDegree_rad);
        float goalZ = m_GoalRadius * Mathf.Sin(m_GoalDegree_rad);

        // ارتفاع + نوسان سینوسی
        float goalY = m_GoalHeight + m_GoalDeviation * Mathf.Cos(m_GoalDeviationFreq * Time.time);

        goal.transform.position = new Vector3(goalX, goalY, goalZ);
    }
}

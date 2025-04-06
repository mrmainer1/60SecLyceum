using Project.EntenEller.Base.Scripts.Advanced.Behaviours.Loop;
using Project.EntenEller.Base.Scripts.Patterns.Singleton;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Timer
{
    public class TimerLineVisualizer : EEBehaviourUpdate
    {
        [SerializeField] private float rotationTime = 10f;
        [SerializeField] private Color trailColor = Color.red;
        [SerializeField] private float trailWidth = 5f;
        [SerializeField] private float trailTime = 0.5f;

        private RectTransform rectTransform;
        private TrailRenderer trail;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            trail = GetComponent<TrailRenderer>();

            SetupTrail();
        }

        void SetupTrail()
        {
            trail.time = trailTime;
            trail.startColor = trailColor;
            trail.endColor = new Color(trailColor.r, trailColor.g, trailColor.b, 0);
            trail.startWidth = trailWidth;
            trail.endWidth = 0;
            trail.material = new Material(Shader.Find("Sprites/Default"));
            trail.sortingOrder = GetComponent<Graphic>().canvas.sortingOrder + 1;
        }

        void Update()
        {
            float rotationStep = 360f / rotationTime * Time.deltaTime;
            rectTransform.Rotate(0, 0, -rotationStep);
        }
    }
}

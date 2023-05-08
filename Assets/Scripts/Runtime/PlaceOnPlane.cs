using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;
using System.Collections;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : PressInputBase
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; private set; }

        bool m_Pressed;
        bool m_PressedBegan;

        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        void Update()
        {

            if (Pointer.current == null || m_PressedBegan == false)
                return;

            var touchPosition = Pointer.current.position.ReadValue();

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinBounds))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;

                Instantiate(m_PlacedPrefab, hitPose.position, Quaternion.LookRotation(hitPose.up));
                // if (spawnedObject == null)
                // {
                //     spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                // }
                // else
                // {
                //     spawnedObject.transform.position = hitPose.position;
                // }
                m_PressedBegan = false;
            }
        }

        protected override void OnPressBegan(Vector3 position) => m_PressedBegan = true;
        protected override void OnPress(Vector3 position) => m_Pressed = true;

        protected override void OnPressCancel() => m_Pressed = false;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;

    }
}

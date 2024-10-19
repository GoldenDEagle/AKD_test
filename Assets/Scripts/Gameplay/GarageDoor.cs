using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GarageDoor : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;

        private void Start()
        {
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            transform.position += _moveSpeed * Time.deltaTime * Vector3.up;
        }
    }
}
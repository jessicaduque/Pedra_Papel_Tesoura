using System.Collections;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _lengthX;
    private float _currentXPos;
    private float _auxTimeParallax = 0f;
    private Transform cam => Camera.main.transform;

    [SerializeField] private float _parallaxTime;
    [SerializeField] private bool _parallaxIsActive;

    void Awake()
    {
        // Initial definitions
        _lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        _currentXPos = transform.position.x;
        _parallaxIsActive = false;

        // Turn on parallax
        ChangeParallaxState(true);
    }

    private void ParallaxMovement(float tp)
    {
        _currentXPos -= tp * Time.deltaTime;
        float rePos = cam.transform.position.x * (1 - tp);
        float distancia = cam.transform.position.x * tp;

        transform.position = new Vector3(_currentXPos + distancia, transform.position.y, transform.position.z);

        if (rePos > _currentXPos + _lengthX)
        {
            _currentXPos += _lengthX;
        }
        else if (rePos < _currentXPos - _lengthX)
        {
            _currentXPos -= _lengthX;
        }
    }

    public void ChangeParallaxState(bool state)
    {
        _parallaxIsActive = state;
        StopAllCoroutines();
        if (_parallaxIsActive)
        {
            StartCoroutine(ActivateParallax());
        }
        else
        {
            StartCoroutine(UnactivateParallax());
        }
    }

    IEnumerator ActivateParallax()
    {
        _auxTimeParallax = 0;
        while (_auxTimeParallax < _parallaxTime)
        {
            ParallaxMovement(_auxTimeParallax);
            _auxTimeParallax += Time.deltaTime;
            yield return null;
        }
        _auxTimeParallax = _parallaxTime;
        while (true)
        {
            ParallaxMovement(_parallaxTime);
            yield return null;
        }
    }

    IEnumerator UnactivateParallax()
    {
        while (_auxTimeParallax > 0)
        {
            ParallaxMovement(_auxTimeParallax);
            _auxTimeParallax -= Time.deltaTime;
            yield return null;
        }
    }
}

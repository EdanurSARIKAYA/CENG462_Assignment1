using UnityEngine;

public class launcher : MonoBehaviour
{
    [SerializeField] Transform projectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float launchForce = 1.5f;
    [SerializeField] float trajectoryTimeStep = 0.05f;
    [SerializeField] int trajectoryStepCount = 15;

    Vector2 velocity, startMousePos, currentMousePos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (startMousePos - currentMousePos) * launchForce;
            DrawTrajectory();
        }

        if (Input.GetMouseButtonUp(0))
        {
            FireProjectile();
            ClearTrajectory();
        }
    }

    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];

        for (int i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;
            positions[i] = pos;
        }

        lineRenderer.sortingLayerName = "Default"; 
        lineRenderer.sortingOrder = 3; // Order in layer değerini 3 olarak ayarla
        lineRenderer.startColor = Color.black; // Başlangıç rengini siyah yap
        lineRenderer.endColor = Color.black; // Bitiş rengini siyah yap

        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(positions);
    }

    void RotateLauncher()
    {
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FireProjectile()
    {
        Transform projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = velocity;

        // Nesneye bir tag atayarak, duvara çarpma veya zemine temas algılama
        projectile.tag = "Projectile";

        // Nesneye ait OnCollisionEnter2D fonksiyonunu tetiklemek için bu script'e eklenmesi
        projectile.gameObject.AddComponent<ProjectileCollision>();
    }


    void ClearTrajectory()
    {
        lineRenderer.positionCount = 0;
    }
}

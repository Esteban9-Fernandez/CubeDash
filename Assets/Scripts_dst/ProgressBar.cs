using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;
    public Transform player;
    public Transform endPoint;
    public Vector2 cameraOffset;
    public float interpolationTime = 0.1f;
    public float topGroundHeight = 20f;

    public Transform GroundCamera;
    public Transform TopGround;
    public Transform Background;
    public Movement playerScript;

    private float startX;
    private float levelLength;
    private Vector3 newVector;
    private bool firstFrame = true;

    void Start()
    {
        startX = player.position.x;
        levelLength = endPoint.position.x - startX;
    }

    void Update()
    {
        float playerProgress = (player.position.x - startX) / levelLength;
        progressBar.value = Mathf.Clamp01(playerProgress);
    }

    void FixedUpdate()
    {
        newVector = new Vector3(player.position.x + cameraOffset.x, newVector.y, -10);

        if (playerScript.cameraValues[(int)playerScript.CurrentGamemode] > 10)
            FreeCam(firstFrame);
        else
            StaticCam(playerScript.cameraValues[(int)playerScript.CurrentGamemode], playerScript.yPosLastPortal, firstFrame);

        Background.localPosition = new Vector3((-player.position.x * 0.5f) + Mathf.Floor(player.transform.position.x / 96) * 48, 2.2f, 10);
        transform.position = newVector;
        firstFrame = false;
    }

    void FreeCam(bool doInstantly)
    {
        GroundCamera.position = InterpolateVec3(new Vector3(0, GroundCamera.position.y), Vector3.up * cameraOffset, 20)
            + Vector3.right * (Mathf.Floor(player.transform.position.x / 5) * 5);

        if (TopGround)
        {
            TopGround.localPosition = Vector3.Lerp(TopGround.localPosition, Vector3.up * topGroundHeight, Time.deltaTime * 5);
        }

        if (!doInstantly)
            newVector += Vector3.up * (Mathf.Lerp(player.transform.position.y + 1.7f - newVector.y, -0.6f - newVector.y,
                (player.position.y <= 4.2f) ? 1 : 0)) * Time.deltaTime / interpolationTime;
        else
            newVector += Vector3.up * (player.transform.position.y + 1.7f);
    }

    Vector3 InterpolateVec3(Vector3 current, Vector3 target, float speed)
    {
        return Vector3.Lerp(current, target, Time.deltaTime * speed);
    }

    void StaticCam(int CamSize, float yPosLastPortal, bool doInstantly)
    {
        GroundCamera.position = InterpolateVec3(new Vector3(0, GroundCamera.position.y), Vector3.up * cameraOffset, 20)
            + Vector3.right * (Mathf.Floor(player.transform.position.x / 5) * 5);

        if (TopGround)
        {
            TopGround.localPosition = Vector3.Lerp(TopGround.localPosition, Vector3.up * topGroundHeight, Time.deltaTime * 5);
        }

        if (!doInstantly)
            newVector += Vector3.up * (Mathf.Lerp(player.transform.position.y + 1.7f - newVector.y, -0.6f - newVector.y,
                (player.position.y <= 4.2f) ? 1 : 0)) * Time.deltaTime / interpolationTime;
        else
            newVector += Vector3.up * (player.transform.position.y + 1.7f);
    }
}
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector2 cameraOffset;
    public float interpolationTime = 0.1f;
    public float topGroundHeight = 20f;

    public Transform player;
    public Transform GroundCamera;
    public Transform TopGround;
    public Transform Background;
    public Movement playerScript;

    Vector3 newVector;
    bool firstFrame = true;

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

        if (playerScript.CurrentGamemode != Gamemodes.Cube)
        {
            newVector.y = Mathf.Lerp(newVector.y, player.transform.position.y + 1.7f, Time.deltaTime / interpolationTime);
        }
        else
        {
            if (!doInstantly)
                newVector += Vector3.up * (Mathf.Lerp(player.transform.position.y + 1.7f - newVector.y, -0.6f - newVector.y,
                    (player.position.y <= 4.2f) ? 1 : 0)) * Time.deltaTime / interpolationTime;
            else
                newVector += Vector3.up * (player.transform.position.y + 1.7f);
        }
    }

    void StaticCam(int CamSize, float yPosLastPortal, bool doInstantly)
    {
        GroundCamera.position = InterpolateVec3(new Vector3(0, GroundCamera.position.y), Vector3.up * cameraOffset, 20)
            + Vector3.right * (Mathf.Floor(player.transform.position.x / 5) * 5);

        if (TopGround)
        {
            TopGround.localPosition = Vector3.Lerp(TopGround.localPosition, Vector3.up * topGroundHeight, Time.deltaTime * 5);
        }

        if (playerScript.CurrentGamemode != Gamemodes.Cube)
        {
            newVector.y = Mathf.Lerp(newVector.y, player.transform.position.y + 1.7f, Time.deltaTime / interpolationTime);
        }
        else
        {
            if (!doInstantly)
                newVector += Vector3.up * (Mathf.Lerp(player.transform.position.y + 1.7f - newVector.y, -0.6f - newVector.y,
                    (player.position.y <= 4.2f) ? 1 : 0)) * Time.deltaTime / interpolationTime;
            else
                newVector += Vector3.up * (player.transform.position.y + 1.7f);
        }
    }

    Vector3 InterpolateVec3(Vector3 current, Vector3 target, float speed)
    {
        return Vector3.Lerp(current, target, Time.deltaTime * speed);
    }
}

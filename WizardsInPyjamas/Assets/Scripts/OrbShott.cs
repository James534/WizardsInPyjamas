using UnityEngine;
using System.Collections;

public class OrbShott : MonoBehaviour
{

    private int fireballNum, meteorNum;

    public GameObject myo = null;

    public Rigidbody rb;

    private Thalmic.Myo.Pose userPose = Thalmic.Myo.Pose.Unknown;

    public int restFrames;

    private float axi, ayi;

    public const int FRAMES_BETWEEN_ATTACK = 30;

    public const float A_FIREBALL = (float)0.8;

    public const float A_METEOR = (float)0.8;


    // Use this for initialization
    void Start()
    {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        axi = thalmicMyo.accelerometer.x;
        ayi = thalmicMyo.accelerometer.y;
        rb = GetComponent<Rigidbody>();
        restFrames = 0;
        fireballNum = meteorNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        userPose = thalmicMyo.pose;
        float dax = thalmicMyo.accelerometer.x - axi;
        float day = thalmicMyo.accelerometer.y - ayi;
        if (dax > A_FIREBALL && restFrames == 0 && (userPose == Thalmic.Myo.Pose.FingersSpread || userPose == Thalmic.Myo.Pose.WaveOut))
        {
            fireballNum++;
            restFrames = FRAMES_BETWEEN_ATTACK;
            Debug.Log("FIREBALL " + fireballNum + "   " + dax);
            rb.AddForce(0, 0, 10);
        }
        else if (day > 0.8 && restFrames == 0 && userPose == Thalmic.Myo.Pose.Fist)
        // Make a fist and accelerate down to 
        {
            meteorNum++;
            restFrames = FRAMES_BETWEEN_ATTACK;
            Debug.Log("METEOR " + meteorNum);
            rb.AddForce(0, 10, 0);
        }


        if (restFrames > 0)
            restFrames--;
    }
}

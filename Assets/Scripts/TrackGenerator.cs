using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackGenerator : MonoBehaviour
{

    public Transform trackPrefab;
    List<TrackPoint> trackList;
    List<Transform> trackSpriteList;

    // Use this for initialization
    void Start()
    {
        trackList = new List<TrackPoint>();
        trackSpriteList = new List<Transform>();
        GenerateTrackPoints();
        DisplayTrack();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateTrackPoints()
    {
        float prevX = -25f;
        float prevY = -25f;
        float displace = 0f;
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 50; i++)
            {
                if (Random.value > 0.7)
                {
                    displace = Random.Range(-5, 5);
                }
                else
                {
                    displace = 0f;
                }
                if (j == 0)
                {
                    TrackPoint horz = new TrackPoint(prevX + i, 25 + displace);
                    trackList.Add(horz);
                }
                else if (j == 1)
                {
                    TrackPoint vert = new TrackPoint(25 + displace, -prevY - i);
                    trackList.Add(vert);
                }
                else if (j == 2)
                {
                    TrackPoint horz2 = new TrackPoint(-prevX - i, -25 + displace);
                    trackList.Add(horz2);
                }
                else
                {
                    TrackPoint vert2 = new TrackPoint(-25 + displace, prevY + i);
                    trackList.Add(vert2);
                }
            }
        }

    }

    void DisplayTrack()
    {
        TrackPoint next;
        for (int i = 0; i < trackList.Count; i++)
        {

            TrackPoint current = trackList[i];
            Transform trackSprite = (Transform)Instantiate(trackPrefab);
            if (i != trackList.Count - 1)
            {
                next = trackList[i + 1];
            }
            else
            {
                next = trackList[0];
            }
            //Set point as midpoint
            trackSprite.position = new Vector3((current.X + next.X) / 2, (current.Y + next.Y) / 2, 0f);
            //trackSprite.position = new Vector3 (current.X, current.Y, 0f);

            //Scale point appropriately
            float distance = Vector2.Distance(new Vector2(current.X, current.Y), new Vector2(next.X, next.Y)) / 2;
            trackSprite.localScale = new Vector3(trackSprite.localScale.x, trackSprite.localScale.y * distance, trackSprite.localScale.z);

            //Set angle to rotate
            Vector3 angle = new Vector3(next.X - current.X, next.Y - current.Y, 0f);
            float degrees = Vector3.Angle(Vector3.up, angle);
            trackSprite.Rotate(0f, 0f, degrees);
            trackSpriteList.Add(trackSprite);

        }
    }

    class TrackPoint
    {
        public float X, Y;

        public TrackPoint(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}

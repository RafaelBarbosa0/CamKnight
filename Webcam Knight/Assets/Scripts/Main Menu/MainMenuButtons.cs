using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace CamKnight
{
    public class MainMenuButtons : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField]
        private Button play;
        [SerializeField]
        private Button calibration;
        [SerializeField]
        private Button back;

        [Header("Canvases")]
        [SerializeField]
        private GameObject menuCanvas;
        [SerializeField]
        private GameObject calibrationCanvas;

        private GameObject cam;
        private MeshRenderer camRenderer;
        private BlobDetection blobs;

        private void Start()
        {
            cam = GameObject.FindGameObjectWithTag("Cam");
            camRenderer = cam.GetComponent<MeshRenderer>();
            blobs = cam.GetComponent<BlobDetection>();

            play.onClick.AddListener(StartGame);
            calibration.onClick.AddListener(EnterCalibration);
            back.onClick.AddListener(ExitCalibration);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void EnterCalibration()
        {
            menuCanvas.SetActive(false);
            calibrationCanvas.SetActive(true);

            camRenderer.enabled = true;
        }

        private void ExitCalibration()
        {
            calibrationCanvas.SetActive(false);
            menuCanvas.SetActive(true);

            camRenderer.enabled = false;
            if(!blobs.ImageProcessing) blobs.ImageProcessing = true;
        }
    }
}

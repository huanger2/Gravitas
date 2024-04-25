using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public static bool Stage1;
    public static bool Stage2;
    public static bool Stage3;
    public static bool Stage4;
    public static bool Stage5;


    public GameObject Stage1UI;
    public GameObject Stage2UI;
    public GameObject Stage3UI;
    public GameObject Stage4UI;
    public GameObject Stage5UI;


    public GameObject downArrow;

    public static float wait;
    public static float Stage3Threshold = 150;
    public static float Stage3Clicks = 0;
    public static float DEFAULT_WAIT = 3f;
    public static bool inStage;
    public static bool completionCond;

    public GameObject player_0;
    public GameObject player_1;



    private void Awake()
    {
        Stage1 = false;
        Stage2 = false;
        Stage3 = false;
        Stage4 = false;
        completionCond = false;
        Resume();
    }

    private void Update()
    {
        if (!inStage && wait > 0)
        {
            wait = wait - Time.deltaTime;

        } else if (!Stage1)
        {
            TutorialStage1();

        } else if (!Stage2)
        {
            TutorialStage2();

        } else if (!Stage3)
        {
            TutorialStage3();

        } else if (!Stage4)
        {
            TutorialStage4();
        } else if (!Stage5) {
            TutorialStage5();
        }
    }

    public void Resume()
    {
        deactivateStages();
        Time.timeScale = 1f;
        wait = DEFAULT_WAIT;
        inStage = false;
    }

    /** Stage 1 of the tutorial. Has player move Newt with WASD. */
    public void TutorialStage1()
    {
        activateStageUI(Stage1UI);
        inStage = true;

        // poll for requested behavior
        if (!completionCond)
        {
            completionCond = player_0.GetComponent<PlayerController>().is_exit();
        } else
        {
            Stage1 = true;
            completionCond = false;
            Resume();
        }
    }

    /** Stage 2 of the tutorial. Has player rotate the cube. */
    public void TutorialStage2()
    {
        activateStageUI(Stage2UI);
        Time.timeScale = 0f;
        downArrow.GetComponent<Image>().color = Color.red;
        inStage = true;

        // poll for requested behavior
        if (completionCond)
        {
            downArrow.GetComponent<Image>().color = Color.white;
            Stage2 = true;
            completionCond = false;
            Resume();
        }
    }

    /** Stage 3 of the tutorial. Has player change camera orientation (kinda, has player click twice so that
     * the buttons are still usable). */
    public void TutorialStage3()
    {
        activateStageUI(Stage5UI);
        inStage = true;

        // poll for requested behavior
        if (!completionCond)
        {
            completionCond = player_1.GetComponent<PlayerController>().is_exit();
        } else
        {
            Stage3 = true;
            completionCond = false;
            Resume();
        }
    }

    /** Stage 4 of the tutorial. Prompts the player to win the game, press WASD to continue. */
    public void TutorialStage4()
    {
        activateStageUI45(Stage3UI);
        Time.timeScale = 0f;
        inStage = true;
        StartCoroutine(wait4());


        // poll for requested behavior
        if (!completionCond)
        {
            if (Input.GetMouseButton(0))
            {
                Stage3Clicks += 1;
            }
            completionCond = Stage3Clicks >= Stage3Threshold;
        }
        else
        {
            Stage4 = true;
            completionCond = false;
            Resume();
        }
    }

    public void TutorialStage5()
    {
        activateStageUI45(Stage4UI);
        Time.timeScale = 0f;
        inStage = true;
        // poll for requested behavior
        if (!completionCond)
        {
            completionCond = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);
        }
        else
        {
            StartCoroutine(wait4secondsreal());
            Stage5 = true;
            completionCond = false;
            Resume();
        }
    }

    /** Blanket deactivates the stage UIs. */
    private void deactivateStages()
    {
        Stage1UI.SetActive(false);
        Stage2UI.SetActive(false);
        Stage3UI.SetActive(false);
        Stage4UI.SetActive(false);
        Stage5UI.SetActive(false);

    }

    IEnumerator wait4() {
        yield return new WaitForSeconds(4);
    }

    IEnumerator wait4secondsreal() {
        yield return new WaitForSecondsRealtime(6);
    }

    /** Activates this stage's UI and disables all others. Freezes time. */
    private void activateStageUI(GameObject stage)
    {
        deactivateStages();
        stage.SetActive(true);
        StartCoroutine(wait4());
    }

    private void activateStageUI45(GameObject stage)
    {
        deactivateStages();
        stage.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(wait4());
    }

    /** Method called on click by the buttons in stage 2. */
    public void Stage2Condition()
    {
        if (inStage && Stage1 && !Stage2)
        {
            completionCond = true;
        }
    }

    /** Skips the current stage. */
    public void Skip()
    {
        downArrow.GetComponent<Image>().color = Color.white;
        completionCond = true;
        Stage1 = true;
        Stage2 = true;
        Stage3 = true;
        Stage4 = true;
        Stage5 = true;
        Resume();
    }

    /** Restarts the tutorial. */
    public void Restart()
    {
        Stage1 = false;
        Stage2 = false;
        Stage3 = false;
        Stage4 = false;
        Stage5 = false;
        inStage = true;
        completionCond = false;
        Stage3Clicks = 0;
    }
}

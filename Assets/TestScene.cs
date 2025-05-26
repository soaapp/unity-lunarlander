using UnityEngine;

public class TestScene : MonoBehaviour
{
    // Serialized Field is exposing it to the editor although its private
    [SerializeField] private PlanetScriptable[] testPlanets;
    private int selectedPlanet = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            selectedPlanet = (selectedPlanet + 1) % testPlanets.Length;
            PlanetScriptable selected = testPlanets[selectedPlanet];
            Debug.Log("Selected Planet: " + selected.PlanetName);
            Physics2D.gravity = new Vector2(0, selected.GravityInGs * -9.81f);
        }


        // Rotate right
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        // }

        // // Apply thrust
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     Debug.Log("Up Arrow Pressed");
        //     rb.AddForce(transform.up * thrustPower, ForceMode2D.Force);
        // }
    }
}

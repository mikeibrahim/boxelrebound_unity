using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	[SerializeField] private Texture2D map;
	[SerializeField] private ColorToPrefab[] colorMappings;

    private void Start() { GenerateLevel(); }

	private void GenerateLevel() {
		for (int x = 0; x < map.width; x++) {
			for (int y = 0; y < map.height; y++) {
				GenerateTile(x, y);
			}
		}
	}
	private void GenerateTile(int x, int y) {
		Color pixelColor = map.GetPixel(x, y);
		
		if (pixelColor.a == 0) { return; }

		foreach (ColorToPrefab colorMapping in colorMappings) {
			if (colorMapping.color.Equals(pixelColor)) {
				Vector2 pos = new Vector2(x, y);
				Instantiate(colorMapping.prefab, pos, Quaternion.identity, transform);
			}
		}
	}
}


[System.Serializable]
public class ColorToPrefab {
	public Color color;
	public GameObject prefab;
}
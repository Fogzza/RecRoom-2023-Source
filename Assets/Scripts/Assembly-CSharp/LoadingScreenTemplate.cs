using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LoadingScreenTemplate
{
	public GameObject template;

	public TextMeshProUGUI titleText;

	public TextMeshProUGUI messageText;

	public RawImage backgroundImage;

	public TextMeshProUGUI nextRoomName;

	public TextMeshProUGUI loadingText;
}

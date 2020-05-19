
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;

public class DiscordController : MonoBehaviour
{

	public Discord.Discord discord;

	[Header("Discord")]
	public string state;
	public string details;
	public string largeImage;
	public string largeImageText;
	public string smallImage;
	public string smallImageText;

	// Use this for initialization
	void Start()
	{
		discord = new Discord.Discord(712295658131947520, (System.UInt64)Discord.CreateFlags.Default);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			State = state,
			Details = details,
			Timestamps =
			{
				Start = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
			},
			Assets =
			{
				LargeImage = largeImage,
				LargeText = largeImageText,
				SmallImage = smallImage,
				SmallText = smallImageText,
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});
	}

	// Update is called once per frame
	void Update()
	{
		discord.RunCallbacks();
	}
}
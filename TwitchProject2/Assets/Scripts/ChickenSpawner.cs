﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

public class ChickenSpawner : MonoBehaviour
{
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    public string username, password, channelName;

    public Transform[] spawnpoints;
    public int spawnnum;
    public GameObject theChicken;

    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        username = LoginInfo.instance.username;
        channelName = LoginInfo.instance.displayname;
        password = LoginInfo.instance.password;
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        username = LoginInfo.instance.username;
        channelName = LoginInfo.instance.displayname;
        password = LoginInfo.instance.password;

        if (!twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();
    }

    private void ReadChat()
    {
        if (twitchClient.Available > 0)
        {
            var message = reader.ReadLine();
            Debug.Log("logged in!");

            if (message.Contains("PRIVMSG"))
            {
                //get name
                var splitpoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitpoint);
                chatName = chatName.Substring(1);

                //get message
                splitpoint = message.IndexOf(":", 1);
                message = message.Substring(splitpoint + 1);
                print(String.Format("{0}: {1}", chatName, message));

                GameInputs(message, chatName);
            }
        }
    }

    private void GameInputs(string ChatInputs, string chattername)
    {
        if (ChatInputs.Contains("!join"))
        {
            Debug.Log("joined!");
            if (spawnnum < 12)
            {
                GameObject newchick = Instantiate(theChicken, spawnpoints[spawnnum].position, Quaternion.identity);
                spawnnum += 1;
                CostumePicker costumepick = newchick.GetComponent<CostumePicker>();
                costumepick.chickinfo(ChatInputs, chattername);
                animator.SetTrigger("joined");
            }
            
            if(spawnnum == 12)
            {
                animator.SetBool("full", true);
            }
        }
    }
}

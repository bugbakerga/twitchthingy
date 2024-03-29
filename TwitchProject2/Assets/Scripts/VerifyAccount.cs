﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

public class VerifyAccount : MonoBehaviour
{
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    public string username, password, channelName;

    public bool realAccount;
    public bool Checking;

    bool checkfailsafe = true;

    public void Check()
    {
        if(checkfailsafe == true)
        {
            checkfailsafe = false;
            username = LoginInfo.instance.username;
            channelName = LoginInfo.instance.displayname;
            password = LoginInfo.instance.password;
            Connect();
            Checking = true;
        }
    }

    public void reCheck()
    {
        Checking = false;
        checkfailsafe = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Checking == true)
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
            realAccount = true;
        }
        else
        {
            realAccount = false;
        }
    } 
}

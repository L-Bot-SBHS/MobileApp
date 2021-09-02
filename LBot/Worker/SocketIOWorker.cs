﻿using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;
using LBot.Models;
using LBot;

namespace LBot.Worker {
    public class SocketIOWorker {

        public async void Start() {
            getEvents();
            await client.ConnectAsync();
        }

        public SocketIO client = new SocketIO("http://192.168.137.1:2910/", new SocketIOOptions {
            EIO = 4
        });

        public async void getEvents() {
            List<Event> events = new List<Event>();
            client.On("events", response => {
                string text = response.ToString();
                text= text.Substring(1, text.Length-2);
                events = JsonSerializer.Deserialize<List<Event>>(text);
                (Application.Current as App).eventslist = events;
                MessagingCenter.Send<object>(this, "Event");
            });
        }

    }
}
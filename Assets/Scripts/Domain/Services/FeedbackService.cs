using System;
using UnityEngine;

public class FeedbackService : IFeedbackService
{
    public Action<string> OnMessage { get; set; }

    public void ShowMessage(string message)
    {
        OnMessage?.Invoke(message);
    }
}

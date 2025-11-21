using UnityEngine;
using System;

public interface IFeedbackService
{
    Action<string> OnMessage { get; set; }
    void ShowMessage(string message);
}

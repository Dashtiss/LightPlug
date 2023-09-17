using Exiled.API.Interfaces;
using System.ComponentModel;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }
    public string RLDisabledMessage { get; set; } = "Round Lock is off";
    public string RLEnabledMessage { get; set; } = "Round lock is on";
}
namespace TrafficControlService.Actors;

public class VehicleActor : Actor, IVehicleActor, IRemindable
{
    public readonly ISpeedingViolationCalculator _speedingViolationCalculator;
    private readonly string _roadId;
    private readonly DaprClient _daprClient;

    public VehicleActor(ActorHost host, DaprClient daprClient, ISpeedingViolationCalculator speedingViolationCalculator) : base(host)
    {
        _daprClient = daprClient;
        _speedingViolationCalculator = speedingViolationCalculator;
        _roadId = _speedingViolationCalculator.GetRoadId();
    }

    public async Task RegisterEntryAsync(VehicleRegistered msg)
    {
        try
        {
            Logger.LogInformation($"ENTRY detected in lane {msg.Lane} at " +
                $"{msg.Timestamp.ToString("hh:mm:ss")} " +
                $"of vehicle with license-number {msg.LicenseNumber}.");

            // store vehicle state
            // TODO

            // register a reminder for cars that enter but don't exit within 20 seconds
            // (they might have broken down and need road assistence)
            // TODO
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error in RegisterEntry");
        }
    }

    public async Task RegisterExitAsync(VehicleRegistered msg)
    {
        try
        {
            Logger.LogInformation($"EXIT detected in lane {msg.Lane} at " +
                $"{msg.Timestamp.ToString("hh:mm:ss")} " +
                $"of vehicle with license-number {msg.LicenseNumber}.");

            // remove lost vehicle timer
            await UnregisterReminderAsync("VehicleLost");

            // get vehicle state
            // TODO

            // handle possible speeding violation
            int violation = _speedingViolationCalculator.DetermineSpeedingViolationInKmh(
                vehicleState.EntryTimestamp, vehicleState.ExitTimestamp.Value);
            if (violation > 0)
            {
                Logger.LogInformation($"Speeding violation detected ({violation} KMh) of vehicle " +
                    $"with license-number {vehicleState.LicenseNumber}.");

                var speedingViolation = new SpeedingViolation
                {
                    VehicleId = msg.LicenseNumber,
                    RoadId = _roadId,
                    ViolationInKmh = violation,
                    Timestamp = msg.Timestamp
                };

                // publish speedingviolation (Dapr publish / subscribe)
                // TODO
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error in RegisterExit");
        }
    }

    public async Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
    {
        if (reminderName == "VehicleLost")
        {
            // remove lost vehicle timer
            // TODO

            // get vehicle state
            // TODO

            Logger.LogInformation($"Lost track of vehicle with license-number {vehicleState.LicenseNumber}. " +
                "Sending road-assistence.");

            // send road assistence ...
        }
    }
}

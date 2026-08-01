using SSMP.Api.Client;

namespace SsmpVoiceChat.Client;

/// <summary>
/// The client-side voice chat addon class.
/// </summary>
public class VoiceChatClientAddon : OptionalClientAddon {
    public static bool Enabled { get; private set; } = true;

    public static bool Connected { get; private set; } = false;

    /// <inheritdoc />
    public override void Initialize(IClientApi clientApi) {
        new ClientVoiceChat(this, clientApi, Logger).Initialize();
        VoiceChatMod.ChatBox = clientApi.UiManager.ChatBox;

        clientApi.ClientManager.ConnectEvent += () => Connected = true;
        clientApi.ClientManager.DisconnectEvent += () => Connected = false;
    }

    protected override void OnEnable()
    {
        Logger.Info("Voice Chat Enabled");
        Enabled = true;
    }

    protected override void OnDisable()
    {
        Logger.Info("Voice Chat Disabled");
        Enabled = false;
    }

    /// <inheritdoc />
    protected override string Name => Identifier.AddonName;
    /// <inheritdoc />
    protected override string Version => Identifier.AddonVersion;
    /// <inheritdoc />
    public override uint ApiVersion => Identifier.ApiVersion;
    /// <inheritdoc />
    public override bool NeedsNetwork => true;
}
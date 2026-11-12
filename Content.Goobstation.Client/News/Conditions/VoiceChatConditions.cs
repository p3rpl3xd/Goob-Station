using Content.VoiceChat.Client;
using Content.VoiceChat.Shared;
using Robust.Shared.Configuration;

namespace Content.Goobstation.Client.News.Conditions;

public sealed partial class VoiceChatAvailable : NewsCondition
{
    public override bool Check(IDependencyCollection deps)
    {
        return deps.Resolve<IConfigurationManager>().GetCVar(VoiceCVars.VoiceChatEnabled);
    }
}

public sealed partial class VoiceMicDisconnected : NewsCondition
{
    public override bool Check(IDependencyCollection deps)
    {
        return !deps.Resolve<VoiceChatManager>().WebConnected;
    }
}

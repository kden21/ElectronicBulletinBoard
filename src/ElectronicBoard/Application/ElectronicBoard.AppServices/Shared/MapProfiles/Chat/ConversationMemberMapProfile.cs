using AutoMapper;
using ElectronicBoard.Contracts.Chat.ConversationMember;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Shared.MapProfiles.Chat;

public class ConversationMemberMapProfile:Profile
{
    public ConversationMemberMapProfile()
    {
        CreateMap<ConversationMemberEntity, ConversationMemberDto>();

        CreateMap<ConversationMemberDto, ConversationMemberEntity>()
            .ForMember(c => c.User, o => o.Ignore())
            .ForMember(c => c.Conversation, o => o.Ignore())
            .ForMember(c => c.CreateDate, o => o.Ignore())
            .ForMember(c => c.ModifyDate, o => o.Ignore());
    }
}
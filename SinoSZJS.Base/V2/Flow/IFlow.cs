
namespace SinoSZJS.Base.V2.Flow
{
    public interface IFlow
    {
        FlowEntity GetFlowByFlowId(string flowId);

        FlowEntity GetFlowByStateId(string stateId);

        FlowEntity GetFlowByActionId(string actionId);
    }
}

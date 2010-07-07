namespace EvolutionNet.MVP.View
{
    public interface ICrudView : IControlView
    {
        object GridDataSource { get; set; }
        bool IsPostBack { get; }
    }
}
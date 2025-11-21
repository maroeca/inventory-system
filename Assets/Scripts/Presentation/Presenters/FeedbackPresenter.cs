public class FeedbackPresenter
{
    private readonly FeedbackView _view;
    private readonly IFeedbackService _service;

    public FeedbackPresenter(FeedbackView view, IFeedbackService service)
    {
        _view = view;
        _service = service;

        _service.OnMessage += _view.Show;
    }
}
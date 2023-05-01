namespace NodeTree.API.Handlers
{
    public interface IRequestWithSkipAndTakeHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, int skip, int take);
    }
}

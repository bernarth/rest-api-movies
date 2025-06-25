namespace Movies.Contracts.Responses;

public class MoviesReponse
{
    public IEnumerable<MovieResponse> Items { get; init; } = [];
}

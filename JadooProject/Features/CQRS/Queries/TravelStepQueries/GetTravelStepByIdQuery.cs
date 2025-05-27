namespace JadooProject.Features.CQRS.Queries.TravelStepQueries
{
    public class GetTravelStepByIdQuery
    {
        public int Id { get; set; }

        public GetTravelStepByIdQuery(int id)
        {
            Id = id;
        }
    }
}

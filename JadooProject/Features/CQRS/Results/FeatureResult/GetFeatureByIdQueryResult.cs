﻿namespace JadooProject.Features.CQRS.Results.FeatureResult
{
    public class GetFeatureByIdQueryResult
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

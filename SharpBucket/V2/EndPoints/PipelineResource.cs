using System;
using System.Collections.Generic;
using SharpBucket.V2.Pocos;

namespace SharpBucket.V2.EndPoints
{
    public class PipelineResource : EndPoint
    {
        internal PipelineResource(RepositoryResource repositoryResource) :
            base(repositoryResource, "pipelines/",false)
        {

        }

        public List<Pipeline> ListPipelines()
            => ListPipelines(new ListParameters());
        
        public List<Pipeline> ListPipelines(ListParameters parameters)
        {
            _ = parameters ?? throw new ArgumentNullException(nameof(parameters));
            return GetPaginatedValues<Pipeline>(BaseUrl, parameters.Max, parameters.ToDictionary());
        }


    }
}